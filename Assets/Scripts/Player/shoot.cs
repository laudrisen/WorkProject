using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shoot : MonoBehaviour
{
    [SerializeField] private AudioSource glockShot;
    [SerializeField] private AudioSource noBullets;
    [SerializeField] private TextMeshProUGUI bullets;
    [SerializeField] private int bulletStartAmount = 12;
    [SerializeField] private float fireRate = 0.1f; 
    [SerializeField] private playerShooting playerShot;
    private float lastFireTime;

    private void Start()
    {
        lastFireTime = -fireRate; 
        bullets.text = bulletStartAmount.ToString();
    }

    public void ToShoot()
    {
        float currentTime = Time.time;

        if (currentTime - lastFireTime >= fireRate)
        {
            if (bulletStartAmount > 0)
            {
                glockShot.Play();
                bulletStartAmount--;
                bullets.text = bulletStartAmount.ToString();
                lastFireTime = currentTime;
                playerShot.Shoot();
            }
            else
            {
                noBullets.Play();
            }
        }
    }
}

