using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textm;
    // Update is called once per frame
    void Update()
    {
        textm.text = inventoryItem.ammoAmount.ToString();
    }
}
