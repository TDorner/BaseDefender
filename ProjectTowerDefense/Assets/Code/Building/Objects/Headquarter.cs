using UnityEngine;
using UI;

namespace Building
{
    public class Headquarter : MonoBehaviour
    {
        private void Awake()
        {
            StartTimer();
        }

        private void StartTimer()
        {
            TimeHandler.StartTimer();
        }
    }
}