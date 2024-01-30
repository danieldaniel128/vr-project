using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty picnchAnimationAction;
    public Animator animator;

    private void Update()
    {
        float triggerValue = picnchAnimationAction.action.ReadValue<float>();
        Debug.Log(triggerValue);
        animator.SetFloat("Grip", triggerValue);
    }
}
