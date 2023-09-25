using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public int damageAmount = 20; // Урон от выстрела
    public LayerMask enemyLayer; // Слой, на котором находятся враги
    public float shootingRange = 10f; // Дальность выстрела
    [SerializeField] private playerController playerController; // Ссылка на скрипт playerController

    public void Shoot()
    {
        // Создаем луч, который будет выпущен от позиции игрока
        Vector2 rayDirection = playerController.IsFacingLeft() ? -transform.right : transform.right;
        Ray2D ray = new Ray2D(transform.position, rayDirection);

        // Отображаем луч на сцене в редакторе Unity
        Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.red, 1.0f); // 1.0f - продолжительность отображения луча

        // Проверяем, попал ли луч во что-то на слое врагов в указанной дальности
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, shootingRange, enemyLayer);

        // Если луч попал во что-то на слое врагов
        if (hit.collider != null)
        {
            // Получаем компонент EnemyHealth из объекта, в который попал луч
            enemyHealth eNemyHealth = hit.collider.GetComponent<enemyHealth>();

            // Если у объекта есть компонент EnemyHealth, наносим урон
            if (eNemyHealth != null)
            {
                eNemyHealth.TakeDamage(damageAmount);
            }
        }
    }
}

