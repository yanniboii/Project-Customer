using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int hitPoints;
    public int maxHitPoints;

    GameManager gameManager;

    [SerializeField] Healthbar healthbar;

    private void Start()
    {
        healthbar.UpdateHealthbar(hitPoints, maxHitPoints);
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hitPoints = hitPoints - damage;
        healthbar.UpdateHealthbar(hitPoints, maxHitPoints);
        if(hitPoints <= 0)
        {
            Destroy(healthbar);
            Destroy(gameObject);
            gameManager.TestUpdate();
        }
    }

}
