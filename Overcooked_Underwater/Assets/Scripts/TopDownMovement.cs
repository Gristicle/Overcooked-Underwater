using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    Vector2 movementVector;
    Rigidbody Rigidbody;
    bool Interactive;
    PlayerInput input;
    GameObject currentInteraction;
    //[SerializeField] GameObject interactionManager;
    BoxCollider ROV;

    private void Awake()
    {
        //interactionManager = FindAnyObjectByType<GameObject>().name.CompareTo("InteractionManager");
        Rigidbody = this.GetComponent<Rigidbody>();
        input = this.GetComponent<PlayerInput>();
        ROV = this.GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.AddForce(movementVector.x/50, 0, movementVector.y/50, ForceMode.Impulse);
    }

    public void Move(InputAction.CallbackContext context)
    {

        Vector2 move = new Vector3(movementVector.x / 50, 0, movementVector.y / 50);
    
        movementVector = context.ReadValue<Vector2>();
        Debug.Log("moving");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Interactive = true;
            currentInteraction = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactive = false;
        if (other.CompareTag("Interactable"))
        {
            other.gameObject.GetComponent<Interactive>().interacted = false;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (Interactive && currentInteraction != null)
        {
            currentInteraction.GetComponent<Interactive>().interacted = true;
        }
    }
}
