using System;

namespace Task
{
    /// <summary>
    /// The n-back class contains methods to initialize an n-back task and to run it. 
    /// It returns for a given <see cref="StimulusDuration"/> the <see cref="Character"/> of a <see cref="CharacterSet"/>.
    /// After that an <see cref="string.Empty"/> is returned for a given <see cref="InterStimulusDuration"/>.
    /// Once all <see cref="Character"/> are returned, the <see cref="OnTaskFinished"/> event is fired and 
    /// the <see cref="ErrorRate"/> is calculated. 
    /// </summary>
    class NBackTask : ATask<string>
    {
        #region Properties
        public string[] CharacterSet { get; private set; }
        public int Index { get; private set; }
        public int N { get; private set; }
        public string Character { get; private set; } = string.Empty;
        public float StimulusDuration { get; private set; }
        public float InterStimulusDuration { get; private set; }
        public int NumberOfCorrectAnswers { get; private set; }
        public float ErrorRate { get; private set; }
        public bool IsCorrect => IsCorrectAnswer();
        public float ReactionTime { get; private set; }
        public float CharacterRemainingTime { get; private set; }
        #endregion

        #region Private variables
        private Util.Timer _timer = new Util.Timer(0f);
        #endregion

        #region Public methods
        /// <summary>
        /// Initializes a new n-back task with given parameters.
        /// Call <see cref="Run(float)"/> to iterate over the <see cref="CharacterSet"/>.
        /// </summary>
        /// <param name="characterSet">The set of characters to enumerate.</param>
        /// <param name="n">The number of characters to memorize.</param>
        /// <param name="stimulusDuration">The stimulus duration in seconds.</param>
        /// <param name="interStimulusDuration">The interstimulus duration in seconds.</param>
        public NBackTask(string[] characterSet, int n, float stimulusDuration = 0.5f, float interStimulusDuration = 2.5f)
        {
            CharacterSet = characterSet;
            N = n;
            StimulusDuration = stimulusDuration;
            InterStimulusDuration = interStimulusDuration;
            Character = characterSet[Index];

            _timer = new Util.Timer(stimulusDuration);
            CharacterRemainingTime = _timer.RemainingTime;
            _timer.OnTimerEnd += HandleOnTimerEnd;
        }

        /// <summary>
        /// Runs the n-back task until all <see cref="Character"/> in the
        /// <see cref="CharacterSet"/> are returned.
        /// </summary>
        /// <param name="deltaTime">The elapsed time since the last unity update.</param>
        /// <returns>The stimulus as <see cref="Character"/>.</returns>
        public override string Run(float deltaTime)
        {
            _timer.Tick(deltaTime);
            CharacterRemainingTime = _timer.RemainingTime;

            ReactionTime = StimulusDuration - CharacterRemainingTime;

            return Character;
        }
        #endregion

        #region Handler
        private void HandleOnTimerEnd()
        {
            if (string.IsNullOrEmpty(Character))
            {
                if (IsTaskFinished())
                    return;

                if (IsCorrectAnswer())
                    NumberOfCorrectAnswers++;

                NextCharacter();

                _timer = new Util.Timer(StimulusDuration);
                _timer.OnTimerEnd += HandleOnTimerEnd;
            }
            else
            {
                Character = string.Empty;
                _timer = new Util.Timer(InterStimulusDuration);
                _timer.OnTimerEnd += HandleOnTimerEnd;
            }
        }
        #endregion

        #region Private methods
        private void NextCharacter()
        {
            IsInputTriggered = false;

            Character = CharacterSet[++Index];
        }

        private bool IsCorrectAnswer()
        {
            if ((IsInputTriggered && IsCorrectCharacter()) ||
                (!IsInputTriggered && !IsCorrectCharacter()))
                return true;
            return false;
        }

        private bool IsTaskFinished()
        {
            if (Index < CharacterSet.Length - 1)
                return false;

            ErrorRate = Math.Abs((float)NumberOfCorrectAnswers - CharacterSet.Length) / CharacterSet.Length;

            OnTaskFinished?.Invoke(this);
            return true;
        }

        private bool IsCorrectCharacter()
        {
            if (N == 0 && CharacterSet[Index].Equals("X"))
                return true;

            if (Index < N)
                return false;
            else if (N > 0 && CharacterSet[Index].Equals(CharacterSet[Index - N]))
                return true;

            return false;
        }
        #endregion
    }
}

