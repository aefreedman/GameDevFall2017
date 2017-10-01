using Movement;
using ScriptableObject;
using UnityEngine;

namespace Tuning
{
    public class CarTuner : MonoBehaviour
    {
        public Car MyCar;
        public CarController MyCarController;
        public TunerSettingsObject SettingsObject;

        private void Start()
        {
            SendTuningValues();
        }

        /// <summary>
        /// </summary>
        public void SendTuningValues()
        {
            MyCarController.SetTuningValues(
                SettingsObject.CarSettings.Acceleration,
                SettingsObject.CarSettings.MaxAcceleration,
                SettingsObject.CarSettings.BrakeStrength,
                SettingsObject.CarSettings.Mass,
                SettingsObject.CarSettings.LinearDrag,
                SettingsObject.CarSettings.TurningRate,
                SettingsObject.CarSettings.AngularDrag,
                SettingsObject.CarSettings.MaxAngularVelocity);
        }
    }
}