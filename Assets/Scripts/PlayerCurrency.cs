using UnityEngine;
using UnityEngine.Events;

public class PlayerCurrency : MonoBehaviour
{
    [SerializeField] private int _currency = 100;
    public int Currency { get { return _currency; } set {  _currency = value; OnCurrencyChanged?.Invoke(_currency); } }
    [SerializeField] public UnityEvent<int> OnCurrencyChanged;

    private void Start()
    {
        OnCurrencyChanged?.Invoke(_currency);
    }
    public void UseCurrency(int amountToUse)
    {
        Currency -= amountToUse;
    }
    [ContextMenu("use currency")]
    public void UseCurrencyTest()
    {
        Currency -= 5;
    }
    public void SetCurrency(int amountToAdd)
    {
        Currency += amountToAdd;

        Debug.Log(Currency);
    }

    public int GetCurrency()
    {
        return Currency;
    }


}
