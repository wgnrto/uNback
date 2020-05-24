using System;

namespace Util
{
    public class Timer
    {
        #region Properties
        public float RemainingTime { get; private set; }
        #endregion

        #region Events
        public event Action OnTimerEnd;
        #endregion

        #region Public methods
        /// <summary>
        /// Initializes a new <see cref="Timer"/>.
        /// </summary>
        /// <param name="duration">The <see cref="Timer"/> duration.</param>
        public Timer(float duration)
        {
            RemainingTime = duration;
        }

        /// <summary>
        /// Running <see cref="Timer"/>.
        /// </summary>
        /// <param name="deltaTime">The elapsed time since the last unity update.</param>
        public void Tick(float deltaTime)
        {
            if (RemainingTime == 0f)
                return;

            RemainingTime -= deltaTime;

            CheckForTimerEnd();
        }
        #endregion

        #region Private methods
        private void CheckForTimerEnd()
        {
            if (RemainingTime > 0f)
                return;

            RemainingTime = 0f;
            OnTimerEnd?.Invoke();
        }
        #endregion
    }
}
