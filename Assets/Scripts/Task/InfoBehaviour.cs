using UnityEngine;

namespace Task
{
    class InfoBehaviour : TextTaskBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private string _text = string.Empty;

        private void Start() => Task = new InfoTask(_text);
    }
}
