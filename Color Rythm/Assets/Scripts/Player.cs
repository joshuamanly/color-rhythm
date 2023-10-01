using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int damage;
    public Animator animator;

    IEnumerator Attack()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 3f, gameObject.transform.position.y, gameObject.transform.position.z);
        animator.Play("Attack",0,0);
        
        yield return new WaitForSeconds(0.3f);    
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
