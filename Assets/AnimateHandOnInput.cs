using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty picnchAnimationAction;

    private void Start()
    {
        
    }

    private void Update()
    {
        float triggerValue = picnchAnimationAction.action.ReadValue<float>();

        Debug.Log(triggerValue);
    }
}
