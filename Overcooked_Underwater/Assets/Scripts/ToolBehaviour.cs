using UnityEngine;

public class ToolBehaviour : MonoBehaviour
{

    public Tools localTool;
    public int toolNumber;

    private void Start()
    {
        switch (localTool)
        {
            case Tools.None:
                toolNumber = 0;
                break;
            case Tools.Tool1:
                toolNumber = 1;
                break;
            case Tools.Tool2:
                toolNumber = 2;
                break;

        }
    }
}
