using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kulitCounter : MonoBehaviour
{
    private int kulitCount = 0;
    private string playerPrefsKey = "KulitCount";

    public static kulitCounter instance;

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
        LoadKulitCount();
    }

    public int GetKulitCount()
    {
        return kulitCount;
    }

    public void SetKulitCount(int count)
    {
        kulitCount = count;
        SaveKulitCount();
    }

    public void AddKulit()
    {
        kulitCount++;
        SaveKulitCount();
    }

    private void SaveKulitCount()
    {
        PlayerPrefs.SetInt(playerPrefsKey, kulitCount);
        PlayerPrefs.Save();
    }

    private void LoadKulitCount()
    {
        kulitCount = PlayerPrefs.GetInt(playerPrefsKey, 0);
    }
}
