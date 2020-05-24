using UnityEngine;

namespace Task
{
    /// <summary>
    /// Base class for all text based task behaviours.
    /// </summary>
    public class TextTaskBehaviour : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="ATask{T}"/> of the behaviour.
        /// </summary>
        public ATask<string> Task { get; protected set; }
    }
}
