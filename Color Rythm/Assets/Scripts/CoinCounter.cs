using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private int coinCount = 0;
    private string playerPrefsKey = "CoinCount";

    public static CoinCounter instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadCoinCount();
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void SetCoinCount(int count)
    {
        coinCount = count;
        SaveCoinCount();
    }

    public void AddCoin()
    {
        coinCount++;
        SaveCoinCount();
    }

    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt(playerPrefsKey, coinCount);
        PlayerPrefs.Save();
    }

    private void LoadCoinCount()
    {
        coinCount = PlayerPrefs.GetInt(playerPrefsKey, 0);
    }
}
