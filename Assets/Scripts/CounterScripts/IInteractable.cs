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

public abstract class Item : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        InteractWithItem();
    }

    public abstract void InteractWithItem();
}
