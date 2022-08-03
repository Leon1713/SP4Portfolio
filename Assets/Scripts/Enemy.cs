using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject playerObject;
    public Collider collider;
    public Collider attackcollider;
    public Collider PlayerCollider;
    float attacktimer;
    public float moveSpeed;
    public StateMachine sm;
    public ProgressBar healthBar;
    private int maxHealth;

    
    private void Start()
    {
        playerObject = GameObject.Find("Player");
        collider = this.gameObject.GetComponent<Collider>();
        attackcollider = this.gameObject.transform.GetChild(0).GetComponent<Collider>();
        PlayerCollider = playerObject.GetComponent<Collider>();
        sm = new StateMachine("Enemy");
        sm.addState("EnemyChase", new EnemyStateChase(this.gameObject));
        sm.addState("EnemyIdle", new EnemyStateIdle(this.gameObject));
        sm.addState("EnemyWander", new EnemyStateWander(this.gameObject));
        sm.addState("EnemyDead", new EnemyStateDead(this.gameObject)); // cool dissolve animation for dying
        maxHealth = health;
        attacktimer = 0;

    }

    private void Update()
    {
        if(health == maxHealth)
        {
            healthBar.gameObject.SetActive(false);
        }
        else if(health == maxHealth - 1)
        {
            healthBar.gameObject.SetActive(true);
        }
        if (sm != null)
            sm.update();

        if (sm.getCurrState() == "EnemyDead")
            return;

        attacktimer += Time.deltaTime;
        if (attacktimer > 1.0)
        {
            attacktimer = 0;
            if (attackcollider.bounds.Intersects(PlayerCollider.bounds))
            {
                //die player scum
                Debug.Log("Git Gud Scrub");
                playerObject.GetComponent<PlayerStats>().hp--;
                
            }
        }
        healthBar.SetProgressBar(maxHealth, health, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerprojectiles")
        {
            //Use this for hitting
            health--;
            //Destroy(collision.gameObject);
        }
    }

}
