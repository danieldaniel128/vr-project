using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityActivator : MonoBehaviour
{
    public InputActionProperty useAbilityAction;
    [SerializeField] Ability currentAbility;
    [SerializeField] Ability[] abilities;

    private void Update()
    {
        float triggerValue = useAbilityAction.action.ReadValue<float>();
        if (triggerValue == 1)
            UseAbility();
    }

    void UseAbility()
    {
        currentAbility.UseAbility();
    }

    void SwitchAbilities()
    {
        
    }

}
