using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text timer;
    public Text wave;

    public int waveCounter;
    public int timePerWave;
    public int startTime;

    public float waveTime;

    void Start()
    {
        TickUpWaveCounter();
    }

    void Update()
    {
        TimerTick();
    }

    public void TickUpWaveCounter()
    {
        waveCounter++;
        wave.text = "Wave " + waveCounter;
        SetTimer();
    }

    public void SetTimer()
    {
        waveTime = 0;
        waveTime = startTime + (waveCounter * timePerWave) + 0.2f;
        timer.text = "" + (int)waveTime;
    }

    private void TimerTick()
    {
        if (waveTime <= 0)
        {
            TickUpWaveCounter();
        }
        else
        {
            waveTime -= Time.deltaTime;
            timer.text = "" + (int)waveTime;
        }
    }

}
