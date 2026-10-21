using System;
using System.Linq;
using System.Security;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] pickUps;
    [SerializeField] private GameObject door;

    private int locks;
    private int unlocks = 0;

    UnityEvent itemPickUp;

    public UnityEvent GetItemPickUp()
    {
        return itemPickUp;
    }

    


    private void Start()
    {
        locks = pickUps.Count();

        if (itemPickUp == null)
        { 
            itemPickUp = new UnityEvent();
        }

        itemPickUp.AddListener(OnItemPickUp);


    }

    private void OnItemPickUp()
    {
        unlocks++;
        Debug.Log("Unlocks: " + unlocks);
        Debug.Log("Locks: " + locks);
        Debug.Log("Unlocked: " + (unlocks == locks));
        if(unlocks == locks)
        {
            door.GetComponent<Door>().Unlock();
        }
    }
}
