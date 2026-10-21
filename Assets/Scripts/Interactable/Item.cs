using UnityEngine;

public class Item : InteractableObject
{
    [SerializeField] private int reset = 0;
    [SerializeField] private int pickUpTime = 5;
    private int interact = 0;

    string origionalIM;


    private void Start()
    {
        origionalIM = interactMessage;
    }

    private void FixedUpdate()
    {
        if (!interacting)
        {
            reset++;
            if(reset == 60)
            {
                interact = 0;
                reset = 0;
                interactMessage = origionalIM;
            }
        }
        else
        {       
            reset = 0;
        }
    }



    public override void Interact()
    {  
        interact++;
        interactMessage = interactMessage + " " + interact;
        if (interact == pickUpTime)
        {
            PickUp();
        }
    }


    private void PickUp()
    {
        GameManager.Instance.GetItemPickUp().Invoke();
        //send event to game manager to keep track of number collected
        gameObject.SetActive(false);
    }
}
