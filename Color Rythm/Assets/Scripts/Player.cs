using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int health;
    public int damage;
    Animator animator;
    public LifeEnergyHandler energyHandler;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
       animator = GetComponent<Animator>();
    }
    public void Update()
    {
      if(energyHandler.currentEnergy == energyHandler.myEnergy)
        {
            energyHandler.ReduceEnergy(energyHandler.myEnergy);
            DoAttack();
        }
    }
    public void DoAttack()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4f, gameObject.transform.position.y, gameObject.transform.position.z);

        //play animation
        Debug.Log("attacking");
        animator.Play("Attack");
        

        yield return new WaitForSeconds(1f);
        //back to position
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 4f, gameObject.transform.position.y, gameObject.transform.position.z);
        animator.Play("Idle");
    }
    public bool LoseHealth(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }
    public void Die()
    {
        Debug.Log("dragon is dead");
        Destroy(gameObject);
    }
    IEnumerator BlinkRed()
    {
        //change the spriterender color to red
        GetComponent<SpriteRenderer>().color = Color.red;
        //wait for small amount of time
        yield return new WaitForSeconds(0.2f);
        //revert to default color
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
