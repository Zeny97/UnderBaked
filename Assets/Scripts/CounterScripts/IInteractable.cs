using UnityEngine;

public interface IInteractable
{
    // Interface is for Interactable Objects
    void Interact();
}

public abstract class CounterObject : MonoBehaviour, IInteractable
{
    // implements Interactable interface and adds specific interaction method for counterobjects 
    public void Interact()
    {
        InteractWithCounter();
    }

    public abstract void InteractWithCounter();
}
