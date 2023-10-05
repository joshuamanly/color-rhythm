using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    public float attackPower;
    public float ultimatePower;
    Animator animator;
    public LifeEnergyHandler energyHandler;
    public UltimateHandler ultimateHandler;
   


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
    public void DoUltimate()
    {
        StartCoroutine(UltimateAttack());
    }

    IEnumerator UltimateAttack()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4f, gameObject.transform.position.y, gameObject.transform.position.z);
        animator.Play("Ultimate");


        yield return new WaitForSeconds(1f);
        //back to position
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 4f, gameObject.transform.position.y, gameObject.transform.position.z);
        animator.Play("Idle");
    }
    IEnumerator Attack()
    {

        Debug.Log("changed position");
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4f, gameObject.transform.position.y, gameObject.transform.position.z);

        //play animation
        Debug.Log("attacking");
        animator.Play("Attack");
        

        yield return new WaitForSeconds(1f);
        //back to position
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 4f, gameObject.transform.position.y, gameObject.transform.position.z);
        animator.Play("Idle");
    }
    public void InflictUltimate()
    {
        Enemy.Instance.energyHandler.Damage(ultimatePower);
        if (Enemy.Instance.energyHandler.currentLife <= 0)
        {
            Enemy.Instance.Die();
        }
        Enemy.Instance.StartBlink();
    }
    public void InflictDamage()
    {
        Enemy.Instance.energyHandler.Damage(attackPower);
        if(Enemy.Instance.energyHandler.currentLife <= 0)
        {
            Enemy.Instance.Die();
        }
        Enemy.Instance.StartBlink();
    }
    public void Die()
    {
        Debug.Log("player is dead");
        StartCoroutine(Died());  
    }
    public void StartBlink()
    {
        StartCoroutine(BlinkRed());
    }
    IEnumerator Died()
    {
        animator.Play("Died");
        yield return new WaitForSeconds(3.0f);
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
