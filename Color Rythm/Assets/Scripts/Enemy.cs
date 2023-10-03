using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    
    public float attackPower;
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
        if (energyHandler.currentEnergy == energyHandler.myEnergy)
        {
            energyHandler.ReduceEnergy(energyHandler.myEnergy);
            DoAttack();
        }
    }
    public void InflictDamage()
    {
        Player.Instance.energyHandler.Damage(attackPower);
        if(Player.Instance.energyHandler.currentLife <= 0 )
        {
            Player.Instance.Die();
        }
        Player.Instance.StartBlink();
    }
    public void DoAttack()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 4f, gameObject.transform.position.y, gameObject.transform.position.z);

        //play animation
        Debug.Log("attacking");
        animator.Play("Attack");


        yield return new WaitForSeconds(1f);
        //back to position
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4f, gameObject.transform.position.y, gameObject.transform.position.z);
        animator.Play("Idle");
    }
    
    public void Die()
    {
        Debug.Log("enemy is dead");
        Destroy(gameObject);
        
        
    }
    public void StartBlink()
    {
        StartCoroutine(BlinkRed());
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
