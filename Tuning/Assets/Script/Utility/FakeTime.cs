using UnityEngine;

namespace Utility
{
    public class FakeTime : MonoBehaviour
    {
        private float _time;

        private void Start()
        {
            _time = Random.Range(0, 10f);
        }

        private void Update()
        {
            _time -= Time.deltaTime;
        }
    }
}