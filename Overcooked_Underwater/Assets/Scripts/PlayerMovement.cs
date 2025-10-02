using UnityEngine;
using UnityEngine.InputSystem;

public enum Tools
{
    None,
    Tool1,
    Tool2
}

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementVector;
    Rigidbody Rigidbody;
    bool Interactive;
    GameObject currentInteraction;
    [SerializeField] GameObject interactionManager;
    GameObject tool;
    int currentTool;
    bool holding;

    private void Awake()
    {
        holding = false;
        Rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.AddForce(movementVector.x/5, movementVector.y/5, 0, ForceMode.Impulse);
        Debug.Log(holding);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Interactive = true;
            currentInteraction = other.gameObject;
        }
        else if (other.CompareTag("Tool"))
        {
            Interactive = true;
            tool = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            other.gameObject.GetComponent<Interactive>().interacted = false;
            Interactive = false;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (Interactive && currentInteraction != null)
        {
            if(currentInteraction.GetComponent<Interactive>().requiredTool == 0 || currentInteraction.GetComponent<Interactive>().requiredTool == currentTool)
            {
                currentInteraction.GetComponent<Interactive>().interacted = true;
            }
        }
    }

    public void Tool(InputAction.CallbackContext context)
    {
        if(Interactive && tool != null && !holding && context.ReadValueAsButton())
        {
            holding = true;
            currentTool = tool.GetComponent<ToolBehaviour>().toolNumber;
            tool.transform.SetParent(this.gameObject.transform, true);
            Destroy(tool.GetComponent<Rigidbody>());
        }
        else if (holding && context.ReadValueAsButton())
        {
            holding = false;
            tool.AddComponent<Rigidbody>();
            tool.transform.SetParent(null, true);
        }
    }
}
