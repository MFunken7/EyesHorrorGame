using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera view; //player view point
    [SerializeField] private GameObject player;
    [SerializeField][Range(1, 10)] float sensitivity = 5;

    private void OnLook(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        Vector2 delta = new Vector3(movement.y * -1, movement.x);
        Vector2 rotation = view.transform.localEulerAngles;

        rotation.x += delta.x;
        
        Vector3 playerRotation = new Vector3(0, delta.y, 0);
        Quaternion quatX = Quaternion.AngleAxis(rotation.x, Vector3.right);


        player.transform.Rotate(playerRotation);
        view.transform.localRotation = Quaternion.RotateTowards(view.transform.localRotation, quatX, 1 * sensitivity);
    }
}
