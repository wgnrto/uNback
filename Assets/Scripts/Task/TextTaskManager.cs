using System;
using System.Collections.Generic;

namespace Task
{
    /// <summary>
    /// Unity independent text based task manager that runs enqueued text tasks.
    /// </summary>
    public class TextTaskManager
    {
        #region Properties
        /// <summary>
        /// Queued <see cref="ATask{T}"/>.
        /// </summary>
        public Queue<ATask<string>> Tasks { get; private set; } = new Queue<ATask<string>>();

        /// <summary>
        /// Current running <see cref="ATask{T}"/>.
        /// </summary>
        public ATask<string> RunningTask { get; private set; }

        /// <summary>
        /// Is invoked when <see cref="ATask{T}"/> is finished.
        /// </summary>
        public Action<ATask<string>> OnTaskFinished;
        #endregion

        #region Private Variables
        private ATask<string> _task;
        #endregion

        #region Public Methods
        /// <summary>
        /// Enqueue <see cref="ATask{T}"/>s.
        /// </summary>
        /// <param name="tasks"><see cref="ATask{T}"/>s that should be enqueued.</param>
        public void EnqueueTasks(ATask<string>[] tasks)
        {
            foreach (var task in tasks)
                Tasks.Enqueue(task);
        }

        /// <summary>
        /// Prepare task for running.
        /// </summary>
        public void PrepareTask()
        {
            _task = Tasks.Dequeue();
            RunningTask = _task;
            _task.OnTaskFinished += HandleTaskFinished;
        }

        /// <summary>
        /// Run <see cref="EnqueueTasks(ATask{string}[])"/>.
        /// </summary>
        /// <param name="deltaTime">Passed time since the last frame.</param>
        /// <returns>Result of text based <see cref="ATask{T}"/>.</returns>
        public string Run(float deltaTime)
        {
            if (_task == null)
                return string.Empty;

            return _task.Run(deltaTime);
        }

        /// <summary>
        /// Input handler.
        /// </summary>
        public void HandleOnInput() => _task.IsInputTriggered = true;
        #endregion

        #region Private Methods
        private void HandleTaskFinished(ATask<string> task)
        {
            _task.OnTaskFinished -= HandleTaskFinished;

            OnTaskFinished?.Invoke(task);

            if (Tasks.Count > 0)
                PrepareTask();
        }
        #endregion
    }
}
