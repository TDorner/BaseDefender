using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimeHandler : MonoBehaviour
    {
        public Text timer;
        public Text wave;

        public int waveCounter;
        public int timePerWave;
        public int startTime;

        public float waveTime;

        public bool timerStarted = false;

        void Update()
        {
            if (timerStarted)
            {
                TimerTick();
            }
        }

        private void TickUpWaveCounter()
        {
            waveCounter++;
            wave.text = "Wave " + waveCounter;
            SetTimer();
        }

        private void SetTimer()
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

        public void StartTimer()
        {
            timerStarted = true;
            TickUpWaveCounter();
        }
    }
}
