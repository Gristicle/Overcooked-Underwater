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

    void Update()
    {
        Rigidbody.AddForce(movementVector.x/5, movementVector.y/5, 0, ForceMode.Impulse);
        if (currentInteraction != null)
        {
            if (currentInteraction.GetComponent<Interactive>() != null)
            {
                if (currentInteraction != null && currentInteraction.GetComponent<Interactive>().interactionTime > 1.9f)
                {
                    currentInteraction = null;
                }
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>() * Time.deltaTime * 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Algae"))
        {
            other.GetComponent<Algae>().Caught(this.gameObject);
        }
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
            if(other.gameObject.GetComponent<Interactive>() != null)
            {
                other.gameObject.GetComponent<Interactive>().interacted = false;
            }
            Interactive = false;
            currentInteraction = null;
        }
        if (other.CompareTag("Algae"))
        {
            other.GetComponent<Algae>().Released(this.gameObject);
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (Interactive && currentInteraction != null)
        {
            if(currentInteraction.GetComponent<Interactive>() != null)
            {
                if (currentInteraction.GetComponent<Interactive>().requiredTool == 0 || currentInteraction.GetComponent<Interactive>().requiredTool == currentTool)
                {
                    currentInteraction.GetComponent<Interactive>().interacted = true;
                }
            }
            else if (currentInteraction.gameObject.GetComponent<SharkBehaviour>() != null)
            {
                currentInteraction.gameObject.GetComponent<SharkBehaviour>().Reject();
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
            tool.GetComponent<SphereCollider>().enabled = false;
            Destroy(tool.GetComponent<Rigidbody>());
            tool = null;
        }
        else if (holding && context.ReadValueAsButton())
        {
            tool = GetComponentInChildren<ToolBehaviour>().gameObject;
            holding = false;
            tool.AddComponent<Rigidbody>();
            tool.transform.SetParent(null, true);
            tool.GetComponent<SphereCollider>().enabled = true;
            tool = null;
        }
    }
}
