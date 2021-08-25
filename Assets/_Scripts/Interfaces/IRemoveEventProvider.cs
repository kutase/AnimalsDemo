using UnityEngine.Events;

namespace AnimalsDemo
{
    public interface IRemoveEventProvider
    {
        UnityEvent OnRemoveEvent { get; }
    }
}
