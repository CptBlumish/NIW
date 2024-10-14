using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //health sliders
    public Slider healthBar;
    public Slider easeHealth;

    //health variable
    public float maxHealth = 100f;
    public float Health;

    //damage
    private float damageMin = 5;
    private float maxDamage = 15;

    public float lerpSpeed = 0.05f;
    private HealthBar UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<Health>();
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Healthstatus();
        //healthDamage();
    }
    void Healthstatus() 
    {
        if (healthBar.value != Health)
        {
            healthBar.value = Health;
        }
        if(healthBar.value != easeHealth.value)
        {
            easeHealth.value = Mathf.Lerp(easeHealth.value,Health,lerpSpeed);
        }
       
        /**if(Input.GetKeyDown(KeyCode.Space))
        {
            --health;
        }*/
    }
    /**void healthDamage() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= Random.Range(damageMin,maxDamage);
        }
    }
    */
}
