using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    [HideInInspector] public Transform endPoint;
    public string itemName;
    public float speed = 0.001f;

    private float t = 0f;
    private void Start()
    {
       endPoint = GameObject.FindGameObjectWithTag("endPoint").transform;
        
    }
    void Update()
    {
        MoveToPoint();
        
    }

    void MoveToPoint()
    {
        t += speed * Time.deltaTime;

        // Use Vector3.Lerp to interpolate between start and end points
        transform.position = Vector3.Lerp(transform.position, endPoint.position, t);
        if (t >= 1.0f)
        {
            t = 0f;
        }
        StartCoroutine(DestroyAndScore());
    }

    IEnumerator DestroyAndScore()
    {
        yield return new WaitForSeconds(1.5f);
        ItemVerification();
        Destroy(gameObject);
    }

    void ItemVerification()
    {
        if(gameObject.tag == "coin")
        {
            CoinCounter.instance.AddCoin();
        }
        if (gameObject.tag == "slime")
        {
            SlimeCounter.instance.AddSlime();
        }
        if (gameObject.tag == "kulit")
        {
            kulitCounter.instance.AddKulit();
        }
        if (gameObject.tag == "sisik")
        {
            SisikCounter.instance.AddSisik();
        }

    }
}
