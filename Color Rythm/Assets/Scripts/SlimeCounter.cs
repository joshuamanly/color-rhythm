using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCounter : MonoBehaviour
{
    private int slimeCount = 0;
    private string playerPrefsKey = "SlimeCount";

    public static SlimeCounter instance;

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
        LoadSlimeCount();
    }

    public int GetSlimeCount()
    {
        return slimeCount;
    }

    public void SetSlimeCount(int count)
    {
        slimeCount = count;
        SaveSlimeCount();
    }

    public void AddSlime()
    {
        slimeCount++;
        SaveSlimeCount();
    }

    private void SaveSlimeCount()
    {
        PlayerPrefs.SetInt(playerPrefsKey, slimeCount);
        PlayerPrefs.Save();
    }

    private void LoadSlimeCount()
    {
        slimeCount = PlayerPrefs.GetInt(playerPrefsKey, 0);
    }
}
