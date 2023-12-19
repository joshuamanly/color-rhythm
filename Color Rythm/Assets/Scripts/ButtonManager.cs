using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("StoryMode");
    }
    public void GotoUpgrade()
    {
        SceneManager.LoadScene("Upgrade");
    }
}
