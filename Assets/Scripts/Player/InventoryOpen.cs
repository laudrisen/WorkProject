using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    [SerializeField] private AudioSource open;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject ammoText;

    public void Inventory()
    {
        open.Play();
        if (inventoryItem.ammoAmount > 1)
        {
            ammo.SetActive(true);
            ammoText.SetActive(true);
        }
        else if (inventoryItem.ammoAmount == 1)
        {
            ammo.SetActive(true);
            ammoText.SetActive(false);
        }
        else if (inventoryItem.ammoAmount == 0)
        {
            ammo.SetActive(false);
            ammoText.SetActive(false);
        }
    }
}
