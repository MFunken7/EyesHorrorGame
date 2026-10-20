using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed = 1;
    private Vector2 input;


    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        Debug.Log(value.Get<Vector2>().ToString());
        Vector3 force = new Vector3(input.x, 0, input.y);
        Vector3 forward = player.transform.localRotation.eulerAngles;


        Vector3 finalMove = (Quaternion.Euler(forward) * force) * playerSpeed;

        rb.linearVelocity = finalMove;
        //rb.AddForce(finalMove, ForceMode.Force);
        //player.transform.Translate(force);
        //rb.MovePosition(finalMove);
    }

    private void OnSleep()
    {
        Debug.Log("sleep");
    }

    
}
