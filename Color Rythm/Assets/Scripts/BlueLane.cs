using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLane : MonoBehaviour
{
   public void ColorToBlue()
    {
        StartCoroutine(BlinkBlue());
    }
    public void ColorToMagenta()
    {
        StartCoroutine (BlinkMagenta());
    }
    public void ColorToCyan()
    {
        StartCoroutine (BlinkCyan());
    }
    IEnumerator BlinkBlue()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f, 0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkMagenta()
    {
        GetComponent<SpriteRenderer>().color = Color.magenta;

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkCyan()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 1.0f, 0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
}
