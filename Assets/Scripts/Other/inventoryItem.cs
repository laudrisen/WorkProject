using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryItem : MonoBehaviour
{
    public static int ammoAmount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Если игрок вошел в зону видимости зомби
        if (collision.CompareTag("Player"))
        {
            ammoAmount += 1;
            Destroy(gameObject);
        }
    }
}

