using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected string interactMessage;
    protected bool interacting = false;

    public bool GetInteracting()
    {
        return interacting;
    }

    public void SetInteracting(bool input)
    {
        interacting = input;
    }

    public string GetMessage()
    {
        return interactMessage;
    }

    public abstract void Interact();
}
