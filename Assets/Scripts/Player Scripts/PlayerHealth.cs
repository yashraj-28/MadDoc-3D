using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float playerHealth = 100f;
    private PlayerMovement playerMovement;
    [SerializeField] private Slider playerHealthSlider;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float damageAmount)
    {
        if(playerHealth <= 0)
            return;

        playerHealth -= damageAmount;
        if(playerHealth <= 0)
        {
            playerHealth = 0f;

            playerMovement.PlayerDied();

            GameplayController.instance.RestartGame();
        }

        playerHealthSlider.value = playerHealth;
    }
}
