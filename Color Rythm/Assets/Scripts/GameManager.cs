using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ScoreManager scoreManager;
    public Audio audioFX;
    public RedLane redLane;
    public BlueLane blueLane;
    public GreenLane greenLane;
    public YellowLane yellowLane;
    private void Awake()
    {
        instance = this;
    }
}
