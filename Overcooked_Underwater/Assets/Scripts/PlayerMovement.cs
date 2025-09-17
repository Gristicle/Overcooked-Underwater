using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementVector;
    Rigidbody Rigidbody;
    bool Interactive;
    PlayerInput input;
    GameObject currentInteraction;
    [SerializeField] GameObject interactionManager;

    private void Awake()
    {
        //interactionManager = FindAnyObjectByType<GameObject>().name.CompareTo("InteractionManager");
        Rigidbody = this.GetComponent<Rigidbody>();
        input = this.GetComponent<PlayerInput>();
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
        Interactive = false;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (Interactive && currentInteraction != null)
        {
            currentInteraction.GetComponent<Interactive>().interacted = true;
        }
    }
}
