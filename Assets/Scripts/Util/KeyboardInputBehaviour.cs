using UnityEngine;
using UnityEngine.Events;

namespace Util
{
    public class KeyboardInputBehaviour : MonoBehaviour
    {
        public UnityEvent OnButtonDown;

        void Update()
        {
            CheckForButtonDown();
        }

        private void CheckForButtonDown()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                OnButtonDown?.Invoke();
        }
    }
}
