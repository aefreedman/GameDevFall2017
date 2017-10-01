using UnityEngine;

namespace Tuning
{
    public class CarBoundaryCheck : MonoBehaviour
    {
        public void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.name != "Track") return;
            Debug.Log("Out of bounds!");
            GetComponentInParent<Car>().Reset();
        }
    }
}