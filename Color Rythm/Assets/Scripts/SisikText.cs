using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SisikText : MonoBehaviour
{
    public Text text;
    void Start()
    {
        int sisikCount = FindObjectOfType<SisikCounter>().GetSisikCount();
        text.text = sisikCount.ToString();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
