using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text coinText;
    void Start()
    {
        int coinCount = FindObjectOfType<CoinCounter>().GetCoinCount();
        coinText.text = coinCount.ToString();
    }
    void Update()
    {
        
    }
}
