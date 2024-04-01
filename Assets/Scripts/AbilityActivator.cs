using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AbilityActivator : MonoBehaviour
{
    public InputActionProperty useAbilityAction;
    [SerializeField] Ability currentAbility;
    [SerializeField] Ability[] abilities;
    [SerializeField] private PlayerCurrency playerCurrency;
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

    public void SwitchAbilities(int abilityIndex)
    {
        if (abilityIndex >= 0 && abilityIndex < abilities.Length)
        {
            Ability selectedAbility = abilities[abilityIndex];

            if (selectedAbility != null && selectedAbility.IsPurchased)
            {
                currentAbility = selectedAbility;
            }
            else if (selectedAbility != null && !selectedAbility.IsPurchased && playerCurrency.Currency <= 100)
            {
                playerCurrency.Currency -= 100;
                selectedAbility.IsPurchased = true;
            }
        }
    }

}

