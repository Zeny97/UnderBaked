using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public abstract class CounterObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        InteractWithCounter();
    }

    public abstract void InteractWithCounter();
}
