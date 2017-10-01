using Managers;
using Movement;
using UnityEngine;

namespace Objects.Car
{
    [RequireComponent(typeof(CarController))]
    public class Car : MonoBehaviour
    {
        private Quaternion _originQuaternion;
        private Vector3 _originVector3;

        private int _pickups;
        private readonly int _pickupsNeeded = 3;
        public TunerGame GameManager;

        private void Start()
        {
            _originVector3 = transform.position;
            _originQuaternion = transform.rotation;
        }

        public void Reset()
        {
            transform.position = _originVector3;
            transform.rotation = _originQuaternion;
            var rbody = GetComponent<Rigidbody2D>();
            rbody.angularVelocity = 0;
            rbody.velocity = Vector2.zero;
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.name == "StartFinish")
                if (_pickups >= _pickupsNeeded) GameManager.EndGameEvent.Invoke();
                else GameManager.StartGameEvent.Invoke();

            if (collider.name.Contains("Pickup"))
            {
                _pickups++;
                collider.gameObject.SetActive(false);
            }
        }
    }
}