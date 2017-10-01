using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Tuning/Settings")]
    public class TunerSettingsObject : UnityEngine.ScriptableObject
    {
        public TunerSettings.CarSettings CarSettings;
    }
}