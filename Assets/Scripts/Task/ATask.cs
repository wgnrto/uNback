using System;

namespace Task
{
    /// <summary>
    /// Base class for time dependent tasks with input capability.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ATask<T>
    {
        /// <summary>
        /// Input flag.
        /// </summary>
        public bool IsInputTriggered { get; set; }

        /// <summary>
        /// Is invoked when task is finished.
        /// Invoke includes the <see cref="ATask{T}"/> that is finished.
        /// </summary>
        public Action<ATask<T>> OnTaskFinished;

        /// <summary>
        /// Runs a time dependent task.
        /// </summary>
        /// <param name="deltaTime">The time passed since the last frame.</param>
        /// <returns>Returns generic value.</returns>
        public abstract T Run(float deltaTime);
    }
}
