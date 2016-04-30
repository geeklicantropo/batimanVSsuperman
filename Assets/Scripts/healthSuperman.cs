using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthSuperman : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private float timer;

    [SerializeField]
    private Slider healthBar;   

    [SerializeField]
    private int life = 3;

    private bool dead;
    private Vector3 spawn;

    void Start()
    {
        spawn = transform.position;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0 && dead == false)
        {
            dead = true;
            //timer = Time.time + 3;
            currentHealth = 0;
        }
        //else if(currentHealth <= 0)
        //{
        //    currentHealth = 0;
        //}

        if(dead == true)
        {
            if(timer < Time.time)
            {
                dead = false;
                currentHealth = maxHealth;
                transform.position = spawn;

                life = life - 1;
                if (life == 0)
                {
                    Destroy(gameObject);
                }
                   
            }
        }
    }
    
    public void Damage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
            healthBar.value = maxHealth;

        //if(life == 0)
        //{
        //    Destroy(healthBar);
        //}
    }    
}
