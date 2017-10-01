using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class ReloadScene : MonoBehaviour
    {
        public string ReloadButtonName;

        private void Update()
        {
            if (Input.GetButton(ReloadButtonName))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}