using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public bool destroyOnHealth;

    public int currentHealth = maxHealth;
    public bool isEnemy = false;

    public RectTransform healthBar;
    public RectTransform background;

    public bool isLocalPlayer;

    void Start()
    {
        isLocalPlayer = GetComponent<PlayerController>().isLocalPlayer;
    }

    public void TakeDamage(GameObject playerFrom, int amount)
    {
        currentHealth -= amount;
        OnChangeHealth();
        // TODO: Networking Stuff
    }

    public void OnChangeHealth()
    {
        healthBar.sizeDelta = new Vector2(((float)currentHealth) / maxHealth * background.sizeDelta.x, healthBar.sizeDelta.y);
        if(currentHealth <= 0)
        {
            if(destroyOnHealth)
                Destroy(gameObject);
            else
            {
                currentHealth = maxHealth;
                healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
                Respawn();
            }
        } 
    }

    public void Respawn()
    {
        if(isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;
            Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);
            transform.position = spawnPoint;
            transform.rotation = spawnRotation;
        }
    }

    void Update()
    {
        
    }
}
