using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisikCounter : MonoBehaviour
{
    private int sisikCount = 0;
    private string playerPrefsKey = "SisikCount";

    public static SisikCounter instance;

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
        LoadSisikCount();
    }

    public int GetSisikCount()
    {
        return sisikCount;
    }

    public void SetSisikCount(int count)
    {
        sisikCount = count;
        SaveSisikCount();
    }

    public void AddSisik()
    {
        sisikCount++;
        SaveSisikCount();
    }

    private void SaveSisikCount()
    {
        PlayerPrefs.SetInt(playerPrefsKey, sisikCount);
        PlayerPrefs.Save();
    }

    private void LoadSisikCount()
    {
        sisikCount = PlayerPrefs.GetInt(playerPrefsKey, 0);
    }
}
