using UnityEngine;

namespace Task
{
    /// <summary>
    /// Example behaviour for the <see cref="FocusTask"/>. 
    /// </summary>
    [RequireComponent(typeof(TaskManagerBehaviour))]
    public class FocusBehaviour : TextTaskBehaviour
    {
        #region Parameter
        [Header("Parameter")]
        [SerializeField] private string _character = "+";
        [SerializeField] private int _duration = 120;
        #endregion

        private void Start() => Task = new FocusTask(_duration, _character);
    }
}
