using UnityEngine;
using UI;

namespace Building
{
    public class Headquarter : MonoBehaviour
    {
        TimeHandler timeHandler;
        private void Awake()
        {
            timeHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeHandler>();
            timeHandler.StartTimer();
        }
    }
}