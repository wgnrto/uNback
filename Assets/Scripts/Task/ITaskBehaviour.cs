using UnityEngine.UI;

namespace Task
{
    interface ITaskBehaviour<T>
    {
        ATask<T> Task { get; }
        Text Text { get; }
    }
}
