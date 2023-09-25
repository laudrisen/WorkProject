using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Максимальное здоровье врага
    private int currentHealth; // Текущее здоровье врага
    [SerializeField] private TextMeshProUGUI healthText; // Ссылка на текст с здоровьем врага

    private void Start()
    {
        currentHealth = maxHealth; // Инициализируем текущее здоровье
        UpdateHealthText();
    }

    // Этот метод вызывается, когда враг получает урон
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0; // Убеждаемся, что здоровье не станет отрицательным
            // Вызываем метод выпадения предмета из скрипта DropItemOnDeath
            DropItemOnDeath dropItemScript = GetComponent<DropItemOnDeath>();
            if (dropItemScript != null)
            {
                dropItemScript.DropItem();
            }

            // Уничтожаем объект врага
            Destroy(gameObject);
        }

        UpdateHealthText();
    }

    // Этот метод обновляет текст с текущим здоровьем врага
    private void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
}

