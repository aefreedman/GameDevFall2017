using UnityEngine;
using UnityEngine.Events;

namespace Tuning
{
    public class TunerGame : MonoBehaviour
    {
        private bool _timeRunning;
        public UnityEvent EndGameEvent;

        public UnityEvent StartGameEvent;
        public float Time { get; private set; }

        private void Start()
        {
            Time = 0;
        }

        private void Update()
        {
            if (_timeRunning) Time += UnityEngine.Time.deltaTime;
        }

        public void StartTimer()
        {
            _timeRunning = true;
        }

        public void EndTimer()
        {
            _timeRunning = false;
        }
    }
}