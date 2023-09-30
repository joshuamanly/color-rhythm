using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLane : MonoBehaviour
{
    public void ColorToRed()
    {
        StartCoroutine(BlinkRed());
    }
    public void ColorToYellow()
    {
        StartCoroutine(BlinkYellow());
    }
    public void ColorToMagenta()
    {
        StartCoroutine(BlinkMagenta());
    }
    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.9f);
        
        yield return new WaitForSeconds(0.05f);
        
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkYellow()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 0.0f,0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkMagenta()
    {
        GetComponent<SpriteRenderer>().color = Color.magenta;

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
}
