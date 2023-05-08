using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    RagdollManager ragdollManager;
    [HideInInspector] public bool isDead;
    WaveManager waveManager;

    private void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;

            if (health <= 0) EnemyDeath();
            else Debug.Log("Hit");
        }
    }

    void EnemyDeath()
    {
        ragdollManager.TriggerRagdoll();
        Debug.Log("Death");
        Destroy(this.gameObject);
        
        waveManager.EnemyDefeated();


    }
}
