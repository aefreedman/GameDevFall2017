using System;

namespace ScriptableObject
{
    // you need to use the Serializable property to be able to edit these values in Unity
    [Serializable]
    public class TunerSettings
    {
        // you can put variables here
        //public float TestFloat = 0;
        // you can also nest serializable classes
        [Serializable]
        public class CarSettings
        {
            public float AccelerationForce = 0;
            public float MaxAccelerationForce = 0;
            public float AngularDrag = 0;
            public float BrakeStrength = 0;
            public float LinearDrag = 0;
            public float Mass = 0;
            public float TurningRate = 0;
        }
    }
}