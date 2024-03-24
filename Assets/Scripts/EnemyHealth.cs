using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Value = 100;
    public PlayerProgress playerProgress;

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);
        Value -= damage;
        if(Value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
