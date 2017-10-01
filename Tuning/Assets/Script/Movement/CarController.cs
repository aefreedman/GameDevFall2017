using ScriptableObject;
using UnityEngine;

namespace Movement
{
    public class CarController : MonoBehaviour
    {
        private float _acceleration;
        private float _brakeForce;
        private float _force;
        private float _maxAccel;
        private float _turnForce;
        public Transform RearWheelTransform;
        public Transform FrontWheelTransform;
        public Rigidbody2D CenterOfMassRigidbody;

        public TunerSettingsObject SettingsObject;

        // for debugging
        private float _drivetrainForce;
        private float _steeringForce;

        private float _terminalVelocity;

        private void Start()
        {
            if (!RearWheelTransform || !FrontWheelTransform || !CenterOfMassRigidbody)
                Debug.LogError("You must assign rigidbodies to the wheels!");
            SetTuningValues(SettingsObject.CarSettings);
            
            // Calculate terminal velocity
            // Vmax = F / (mass * drag)
            _terminalVelocity = _maxAccel / (CenterOfMassRigidbody.mass * CenterOfMassRigidbody.drag);
        }

        private void Reset()
        {
            SetTuningValues(SettingsObject.CarSettings);
        }

        private void SetTuningValues(TunerSettings.CarSettings settings)
        {
            SetTuningValues(
                settings.AccelerationForce,
                settings.MaxAccelerationForce,
                settings.BrakeStrength,
                settings.Mass,
                settings.LinearDrag,
                settings.TurningRate,
                settings.AngularDrag
                );
        }

        private void SetTuningValues(float accel, float maxForce, float brake, float mass, float linearDrag,
            float turnForce,
            float angularDrag)
        {
            _acceleration = accel;
            _brakeForce = brake;
            CenterOfMassRigidbody.drag = linearDrag;
            CenterOfMassRigidbody.mass = mass;
            _maxAccel = maxForce;
            _turnForce = turnForce;
            CenterOfMassRigidbody.angularDrag = angularDrag;
        }

        private float Drivetrain()
        {
            var vertical = Input.GetAxis("Vertical");
            if (vertical > 0)
                if (_force < _maxAccel) _force += _acceleration;
                else _force = _maxAccel;
            else if (vertical < 0 && CenterOfMassRigidbody.velocity.y > 0)
                _force = Mathf.Clamp(-_brakeForce, 0, CenterOfMassRigidbody.velocity.magnitude);
            else
                _force = 0;
            return _force;
        }

        /// <summary>
        /// Returns amount of horizontal axix input multipied by turning force parameter.
        /// Amount of steering is proportional to velocity.
        ///  +HOR is right, -HOR is left
        /// </summary>
        /// <returns></returns>
        private float Steering()
        {
            return Input.GetAxis("Horizontal") * _turnForce * (1.0f - CenterOfMassRigidbody.velocity.magnitude / _terminalVelocity / 2);
        }

        private void FixedUpdate()
        {
            _drivetrainForce = Drivetrain();
            _steeringForce = Steering();
            var forward = new Vector2(transform.up.x, transform.up.y);
            var left = new Vector2(transform.up.y, transform.up.x);
            CenterOfMassRigidbody.AddForceAtPosition(forward * _drivetrainForce, RearWheelTransform.position);
            CenterOfMassRigidbody.AddTorque(-_steeringForce);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            var forward = new Vector3(transform.up.x, transform.up.y, 0);
            Gizmos.DrawLine(RearWheelTransform.transform.position,
                RearWheelTransform.transform.position +
                forward * _drivetrainForce);
            
//            Gizmos.color = Color.red;
//            Gizmos.DrawLine(FrontWheelTransform.transform.position,
//                FrontWheelTransform.transform.position +
//                FrontWheelTransform.transform.forward * _steeringForce);
        }
    }
}