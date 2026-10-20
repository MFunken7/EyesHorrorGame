using UnityEngine;

public class Item : InteractableObject
{
    [SerializeField] private int reset = 0;
    [SerializeField] private int pickUpTime = 5;
    private int interact = 0;


    private void FixedUpdate()
    {
        Debug.Log("Interacting: " + interacting + " " + interact);
        Debug.Log("Reset: " + reset);
        if (!interacting)
        {
            reset++;
            if(reset == 60)
            {
                interact = 0;
                reset = 0;
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

        if (interact == pickUpTime)
        {
            PickUp();
        }
    }


    private void PickUp()
    {
        //send event to game manager to keep track of number collected
        Destroy(gameObject);
    }
}
