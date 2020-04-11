using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimeHandler : MonoBehaviour
    {
        public static Text timer;
        public static Text wave;

        public static int waveCounter;
        public static int timePerWave;
        public static int startTime;

        public static float waveTime;

        public static bool timerStarted = false;

        void Update()
        {
            if (timerStarted)
            {
                TimerTick();
            }
        }

        private static void TickUpWaveCounter()
        {
            waveCounter++;
            wave.text = "Wave " + waveCounter;
            SetTimer();
        }

        private static void SetTimer()
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

        public static void StartTimer()
        {
            timerStarted = true;
            TickUpWaveCounter();
        }
    }
}
