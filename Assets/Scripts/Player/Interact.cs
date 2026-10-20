using TMPro;
using UnityEngine;

using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] LayerMask mask;
    [SerializeField] private int maxDistance = 10;

    [SerializeField] private GameObject ui;

    private InteractableObject target;


    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxDistance, mask))
        {
            Debug.DrawRay(camera.transform.position, camera.transform.forward * hit.distance, Color.green);

            target = hit.collider.gameObject.GetComponent<InteractableObject>();

            ui.SetActive(true);
            TextMeshProUGUI message = ui.transform.GetComponentInChildren<TextMeshProUGUI>();
            message.text = target.GetMessage();
        }
        else
        {
            Debug.DrawRay(camera.transform.position, camera.transform.forward * maxDistance, Color.red);
            ui.SetActive(false);
            if(target != null)
            {
                target.SetInteracting(false);
                target = null;
            }
        }
       
    }

    private void OnInteractCancel()
    {
        if(target != null)
        {
            target.SetInteracting(false);
        }
            
    }

    private void OnInteract()
    {
        
        if (target != null)
        {
            target.SetInteracting(true);
            target.Interact(); 
        }     
    }
}
