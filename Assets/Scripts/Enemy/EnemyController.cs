using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Скорость движения противника
    public float attackDistance = 1.5f; // Расстояние для атаки
    public float attackDelay = 0.4f; // Задержка перед атакой
    private TextMeshProUGUI healthText; // Ссылка на текст с здоровьем игрока

    private Transform player; // Ссылка на игрока
    private bool isAttacking = false; // Флаг для определения, идет ли атака
    private float attackTimer = 0.0f; // Таймер для задержки атаки
    private bool playerInSight = false; // Флаг для определения, видит ли зомби игрока
    private Vector3 previousPosition; // Предыдущая позиция зомби
    private bool isMovingRight = false; // Флаг для определения направления движения (вправо по умолчанию)
    [SerializeField] private GameObject movingLeft;
    [SerializeField] private GameObject movingRight;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока по тегу

        GameObject textObject = GameObject.FindGameObjectWithTag("HP");

        if (textObject != null)
        {
            healthText = textObject.GetComponent<TextMeshProUGUI>();

            if (healthText == null)
            {
                Debug.LogError("The object with tag 'HP' does not have a TextMeshProUGUI component.");
            }
        }
        else
        {
            Debug.LogError("No object with tag 'HP' found in the scene.");
        }

        previousPosition = transform.position; // Инициализируем предыдущую позицию
    }

    private void Update()
    {
        // Если игрок не существует (например, он умер), то не продолжаем обновление
        if (player == null)
            return;

        // Вычисляем расстояние до игрока
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Определяем направление движения зомби
        if (transform.position.x > previousPosition.x)
        {
            isMovingRight = true;
            movingRight.SetActive(true);
            movingLeft.SetActive(false);
        }
        else if (transform.position.x < previousPosition.x)
        {
            isMovingRight = false;
            movingRight.SetActive(false);
            movingLeft.SetActive(true);
        }

        // Сохраняем текущую позицию как предыдущую
        previousPosition = transform.position;

        // Если противник находится на расстоянии для атаки
        if (distanceToPlayer <= attackDistance)
        {
            // Запускаем таймер атаки
            attackTimer += Time.deltaTime;

            // Если таймер достиг задержки перед атакой, атакуем
            if (attackTimer >= attackDelay)
            {
                AttackPlayer();
                attackTimer = 0.0f; // Сбрасываем таймер
            }
        }
        else
        {
            // Противник следит за игроком, если он находится в поле видимости
            if (playerInSight)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void AttackPlayer()
    {
        // Можно добавить звук или анимацию атаки здесь, если необходимо

        // Отнимаем у игрока 20 единиц здоровья
        int playerHealth = int.Parse(healthText.text);
        playerHealth -= 20;

        // Обновляем текст с здоровьем игрока
        healthText.text = playerHealth.ToString();

        // Устанавливаем флаг атаки
        isAttacking = true;

        // Через 0.4 секунды сбрасываем флаг атаки
        StartCoroutine(ResetAttackFlag());
    }

    private IEnumerator ResetAttackFlag()
    {
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Если игрок вошел в зону видимости зомби
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PlayerEntered");
            playerInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Если игрок вышел из зоны видимости зомби
        if (collision.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }
}

