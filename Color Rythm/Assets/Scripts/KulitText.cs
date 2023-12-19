using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KulitText : MonoBehaviour
{
    public Text text;
    void Start()
    {
        int kulitCount = FindObjectOfType<kulitCounter>().GetKulitCount();
        text.text = kulitCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
