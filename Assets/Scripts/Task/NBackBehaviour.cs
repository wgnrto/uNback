using UnityEngine;

namespace Task
{
    [RequireComponent(typeof(TaskManagerBehaviour))]
    public class NBackBehaviour : TextTaskBehaviour
    {
        #region Parameter
        [Header("Parameter")]
        [SerializeField] private string[] _characterSet = new string[] { "S", "P", "D", "X", "F", "X", "S", "X", "J", "X", "D", "T", "X", "V", "N", "C", "T", "X", "H", "F", "G", "M", "X", "F", "N", "K", "K", "X", "F", "C", "X", "X", "G", "D", "V", "K", "R", "X", "X", "H" };
        [SerializeField] private int _n = 0;
        #endregion

        private void Start() => Task = new NBackTask(_characterSet, _n);
    }
}
