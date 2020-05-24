using System;

namespace Task
{
    public class InfoTask : ATask<string>
    {
        public string Text { get; private set; } = string.Empty;

        public InfoTask(string text)
        {
            Text = text;
        }

        public override string Run(float deltaTime)
        {
            CheckForInput();

            return Text;
        }

        private void CheckForInput()
        {
            if (!IsInputTriggered)
                return;

            Text = string.Empty;
            OnTaskFinished?.Invoke(this);
        }
    }
}
