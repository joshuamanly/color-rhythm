using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLane : MonoBehaviour
{
    public void ColorToOrange()
    {
       StartCoroutine(BlinkOrange());
    }
    public void ColorToChartreuse()
    {
        StartCoroutine (BlinkChartreuse());
    }
    public void ColorToGreen()
    {
        StartCoroutine(BlinkGreen());
    }
    IEnumerator BlinkOrange()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.647f, 0.0f,0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkChartreuse()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.498f, 1.0f, 0.0f,0.9f); ;

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
    IEnumerator BlinkGreen()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 0.9f);

        yield return new WaitForSeconds(0.05f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1764706f);
    }
}
