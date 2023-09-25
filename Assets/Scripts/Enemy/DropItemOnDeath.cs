using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    public GameObject itemPrefab; // Префаб предмета для выпадения
    public Transform dropPoint; // Место, где должен появиться предмет

    public void DropItem()
    {
        if (itemPrefab != null)
        {
            // Создаем экземпляр предмета и размещаем его на месте dropPoint
            Instantiate(itemPrefab, dropPoint.position, Quaternion.identity);
        }
    }
}
