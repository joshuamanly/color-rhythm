using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeText : MonoBehaviour
{
    public Text text;
    void Start()
    {
        int slimeCount = FindObjectOfType<SlimeCounter>().GetSlimeCount();
        text.text = slimeCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
