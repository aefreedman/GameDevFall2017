using Tuning;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimerDisplay : MonoBehaviour
    {
        private Text _text;

        public TunerGame TunerGame;

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            _text.text = TunerGame.Time.ToString("##.000");
        }
    }
}