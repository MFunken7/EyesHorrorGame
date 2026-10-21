using UnityEngine;

public class Door : InteractableObject
{

    private bool locked = true;

    public override void Interact()
    {
        if (!locked)
        {
            //Scene manager call
            Debug.Log("Win");
        }
    }


    public void Unlock()
    {
        locked = false;
        interactMessage = "This Door is unlocked.";
    }

    public void Lock()
    {
        locked = true;
        interactMessage = "This Door is locked.";

    }

}
