using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    Vector2 movementVector;
    Rigidbody Rigidbody;
    bool Interactive;
    PlayerInput input;
    GameObject currentInteraction;
    [SerializeField] GameObject interactionManager;
    MeshCollider ROV;

    private void Awake()
    {
        //interactionManager = FindAnyObjectByType<GameObject>().name.CompareTo("InteractionManager");
        Rigidbody = this.GetComponent<Rigidbody>();
        input = this.GetComponent<PlayerInput>();
        ROV = this.GetComponentInChildren<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.AddForce(movementVector.x/5, 0, movementVector.y/5, ForceMode.Impulse);
    }

    public void Move(InputAction.CallbackContext context)
    {

        Vector3 move = new Vector3(movementVector.x / 5, 0, movementVector.y / 5);
    
        movementVector = context.ReadValue<Vector2>();
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
