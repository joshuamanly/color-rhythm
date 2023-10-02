using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    

    int spawnIndex = 0;
    int inputIndex = 0;
    public GameObject lineJudgement;
    void Start()
    {
        
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (Input.GetKeyDown(input))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    print($"Hit on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    //Red Lane
                    if (lineJudgement.CompareTag("Red") && notePrefab.CompareTag("RedNote"))
                    {
                        GameManager.instance.redLane.ColorToRed();
                    }
                    if (lineJudgement.CompareTag("Green") && notePrefab.CompareTag("RedNote"))
                    {
                        GameManager.instance.redLane.ColorToYellow();
                    }
                    if (lineJudgement.CompareTag("Blue") && notePrefab.CompareTag("RedNote"))
                    {
                        GameManager.instance.redLane.ColorToMagenta();
                    }
                    //Green Lane
                    if (lineJudgement.CompareTag("Red") && notePrefab.CompareTag("GreenNote"))
                    {
                        GameManager.instance.greenLane.ColorToYellow();
                    }
                    if (lineJudgement.CompareTag("Green") && notePrefab.CompareTag("GreenNote"))
                    {
                        GameManager.instance.greenLane.ColorToGreen();
                    }
                    if (lineJudgement.CompareTag("Blue") && notePrefab.CompareTag("GreenNote"))
                    {
                        GameManager.instance.greenLane.ColorToCyan();
                    }
                    //Blue Lane
                    if (lineJudgement.CompareTag("Red") && notePrefab.CompareTag("BlueNote"))
                    {
                        GameManager.instance.blueLane.ColorToMagenta();
                    }
                    if (lineJudgement.CompareTag("Green") && notePrefab.CompareTag("BlueNote"))
                    {
                        GameManager.instance.blueLane.ColorToCyan();
                    }
                    if (lineJudgement.CompareTag("Blue") && notePrefab.CompareTag("BlueNote"))
                    {
                        GameManager.instance.blueLane.ColorToBlue();
                    }
                    //Yellow
                    if (lineJudgement.CompareTag("Red") && notePrefab.CompareTag("YellowNote"))
                    {
                        GameManager.instance.yellowLane.ColorToOrange();
                    }
                    if (lineJudgement.CompareTag("Green") && notePrefab.CompareTag("YellowNote"))
                    {
                        GameManager.instance.yellowLane.ColorToChartreuse();
                    }
                    if (lineJudgement.CompareTag("Blue") && notePrefab.CompareTag("YellowNote"))
                    {
                        GameManager.instance.yellowLane.ColorToGreen();
                    }
                    inputIndex++;
                    if(GameManager.instance.redLane.GetComponent<SpriteRenderer>().color == Color.magenta)
                    { 
                        GameManager.instance.scoreManager.IncreaseScoreCount();
                        
                        

                    }
                    if (GameManager.instance.blueLane.GetComponent<SpriteRenderer>().color == Color.magenta)
                    {
                        GameManager.instance.scoreManager.IncreaseScoreCount();
                    }

                    Player.Instance.energyHandler.GainEnergy(1f);
                }
                else
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                print($"Missed {inputIndex} note");
                inputIndex++;
            }
        }

    }
    private void Hit()
    {
        GameManager.instance.scoreManager.IncreaseComboScore();
    }
    private void Miss()
    {
        GameManager.instance.scoreManager.ResetComboScore();
    }
}
