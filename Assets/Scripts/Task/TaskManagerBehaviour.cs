using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    /// <summary>
    /// Example behaviour that uses the <see cref="TextTaskManager"/>.
    /// </summary>
    public class TaskManagerBehaviour : MonoBehaviour
    {
        private TextTaskManager _manager = new TextTaskManager();
        private Text _text;

        /// <summary>
        /// Input handler.
        /// </summary>
        public void HandleOnInput()
        {
            if (_manager == null)
                return;

            _manager.HandleOnInput();

            // example for getting nbacktask properties
            if (_manager.RunningTask is NBackTask nbackTask)
            {
                if (!nbackTask.IsCorrect)  // possibility to show that nbacktask answer is wrong.
                    StartCoroutine(ChangeTextColor(nbackTask.CharacterRemainingTime));

                Debug.Log(nbackTask.ReactionTime); // get reaction time
            }

        }

        #region Unity methods
        private void Start()
        {
            _text = GetComponentInChildren<Text>(); // get UI element for text based tasks

            var taskBehaviours = GetComponentsInChildren<TextTaskBehaviour>(); // get all text based tasks behaviours

            _manager.OnTaskFinished += HandleOnTaskFinished; // possibility to save data after tasks are finished
            _manager.EnqueueTasks(taskBehaviours.Select(x => x.Task).ToArray()); // extract tasks
            _manager.PrepareTask(); // begin with first task
        }

        private void Update() => _text.text = _manager.Run(Time.deltaTime);
        #endregion

        #region Private methods
        private void HandleOnTaskFinished(ATask<string> task)
        {
            if (!(task is NBackTask nBackTask))
                return;
            Debug.Log(nBackTask.ErrorRate); // for example save error rate
        }

        private IEnumerator ChangeTextColor(float wait)
        {
            _text.color = Color.red;
            yield return new WaitForSeconds(wait);
            _text.color = Color.black;
        }
        #endregion
    }
}
