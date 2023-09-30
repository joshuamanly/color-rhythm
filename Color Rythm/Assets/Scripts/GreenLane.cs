using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLane : MonoBehaviour
{
    public void ColorToGreen()
    {
        StartCoroutine(BlinkGreen());
    }
    public void ColorToYellow()
    {
        StartCoroutine(BlinkYellow());
    }
    public void ColorToCyan()
    {
        StartCoroutine(BlinkCyan());
    }
    IEnumerator BlinkGreen()
    {
        GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkYellow()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 0.0f, 0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkCyan()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 1.0f,0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
}
