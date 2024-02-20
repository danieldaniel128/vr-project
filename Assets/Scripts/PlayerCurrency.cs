using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCurrency : MonoBehaviour
{
    [SerializeField] private int currency = 100;

    [SerializeField] private UnityEvent OnCurrencyChanged;

    public void UseCurrency(int amountToUse)
    {
        currency -= amountToUse;
    }

    public void SetCurrency(int amountToAdd)
    {
        currency += amountToAdd;

        Debug.Log(currency);
    }

    public int GetCurrency()
    {
        return currency;
    }


}
