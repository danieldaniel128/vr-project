using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleImpactAbility : Ability
{
    [SerializeField] GameObject _abilityActivator;
    [SerializeField] GameObject _impactVFX;
    CountdownTimer AttackDuration;
    private void OnEnable()
    {
        AttackDuration = new CountdownTimer(1f);
        AttackDuration.OnTimerStop += DeactivateAbility;
    }
    private void OnDisable()
    {
        AttackDuration.OnTimerStop -= DeactivateAbility;
    }
    private void Update()
    {
        AttackDuration.Tick(Time.deltaTime);
    }
    void ActivateAbility()
    {
        if (!AttackDuration.IsRunning)
        {
            AttackDuration.Start();
            _abilityActivator.SetActive(true);
        }
    }
    void DeactivateAbility()
    {
        _abilityActivator.SetActive(false);
    }

    public override void UseAbility()
    {
        ActivateAbility();
    }
}
