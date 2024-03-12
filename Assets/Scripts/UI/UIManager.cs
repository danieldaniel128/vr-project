using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    public void CurrencyChange(int CurrenctChange) 
    {
        currencyText.text = $"{CurrenctChange}";
    }
}
