using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementVector;
    Rigidbody Rigidbody;
    bool Interactive;
    GameObject currentInteraction;

    private void Awake()
    {
        Rigidbody = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.AddForce(movementVector.x/5, movementVector.y/5, 0, ForceMode.Impulse);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Interactive = true;
            currentInteraction = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Interactive = false;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (Interactive)
        {
            //currentInteraction.GetComponent<>
        }
    }
}
