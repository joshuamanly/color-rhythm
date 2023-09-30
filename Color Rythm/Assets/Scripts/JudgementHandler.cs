using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.tag = "Red";
        }
        if (Input.GetKey(KeyCode.K))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            gameObject.tag = "Green";
        }
        if (Input.GetKey(KeyCode.L))
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1.0f, 1.0f);
            gameObject.tag = "Blue";
        }
       
    }
} 

