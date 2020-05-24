using System;

namespace Task
{
    /// <summary>
    /// The focus class contains all methods to run a focus task for a given <see cref="StimulusDuration"/>.
    /// It returns a given <see cref="Character"/> until the <see cref="StimulusDuration"/> expires. 
    /// Then a <see cref="string.Empty"/> is returned and the <see cref="OnTaskFinished"/> is invoked with
    /// a <see cref="TaskFinishedEventArgs"/>.
    /// </summary>
    class FocusTask : ATask<string>
    {
        #region Properties
        public float StimulusDuration { get; private set; }
        public string Character { get; private set; } = string.Empty;
        #endregion

        #region Private variables
        private Util.Timer _timer = new Util.Timer(0f);
        #endregion

        #region Public methods
        /// <summary>
        /// Initializes a new focus task with given parameters.
        /// </summary>
        /// <param name="stimulusDuration">The runtime of the task.</param>
        /// <param name="character">The returned character.</param>
        public FocusTask(float stimulusDuration, string character)
        {
            StimulusDuration = stimulusDuration;
            Character = character;

            _timer = new Util.Timer(stimulusDuration);
            _timer.OnTimerEnd += HandleTimerEnd;
        }

        /// <summary>
        /// Runs the focus task until <see cref="StimulusDuration"/> expires.
        /// </summary>
        /// <param name="deltaTime">The elapsed time since the last unity update.</param>
        /// <returns>The <see cref="Character"/>.</returns>
        public override string Run(float deltaTime)
        {
            _timer.Tick(deltaTime);
            return Character;
        }
        #endregion

        #region Handler
        private void HandleTimerEnd()
        {
            Character = string.Empty;

            OnTaskFinished?.Invoke(this);
        }
        #endregion
    }
}
