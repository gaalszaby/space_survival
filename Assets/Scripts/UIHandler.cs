using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Text health;
    [SerializeField] private Text gameOver;

    void Update()
    {
        // Kiirja a jelenlegi HP-t
        health.text = "Health: " + Player.currentHealth.ToString();
        // Ha elfogyott az életünk felhozza a game over szöveget
        if (Player.currentHealth <= 0)
        {
            gameOver.enabled = true;
        }
    }
}
