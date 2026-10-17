using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnMove(InputValue value)
    {
        Debug.Log("Move: " + value.Get<Vector2>().ToString());
    }

    private void OnInteract()
    {
        Debug.Log("interact");
    }

    private void OnSleep()
    {
        Debug.Log("sleep");
    }

    
}
