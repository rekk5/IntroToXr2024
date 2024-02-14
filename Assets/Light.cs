using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    private Light pointLight;
    public InputActionReference switchAction;

    void Start()
    {
        pointLight = GetComponent<Light>();
        switchAction.action.Enable();
        switchAction.action.performed += OnSwitchAction;
    }

    void OnSwitchAction(InputAction.CallbackContext context)
    {
        ToggleLightColor();
    }

    void ToggleLightColor()
    {
        if (pointLight.color == Color.red)
        {
            pointLight.color = Color.green;
        }
        else
        {
            pointLight.color = Color.red;
        }
    }
}
