    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

     public int health = 100;
     public HealthBar healthbar;
     public GameObject GameOverPanel;
     public bool gameoverpanel=false;
    //  public GameManager Gamemanager;
    public AudioSource source;
    public ParticleSystem damageParticles;
     
     public void Start()
     {
        source= GetComponent<AudioSource>();
        // Gamemanager=GameObject.Find("GameManager").GetComponent<GameManager>();
            healthbar.SetMaxHealth(health);

     }
    public void TakeDamage(int damage)
    {
        if (health >0)
        {
            health-=damage;
            Debug.Log(health);
            healthbar.SetHealth(health);
            if (damageParticles != null)
        {
            damageParticles.Play();
        }
        }
        else if (health <=0){
            Debug.Log("PLAYER DEAD");
            GameOverPanel.SetActive(true);
            gameoverpanel=true;
            source.Play();
            // Time.timeScale=0;
            Destroy(gameObject);
        }
    
    }
}
