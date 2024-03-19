using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI waveCountText;
    [SerializeField] private TextMeshProUGUI WavetimerText;

    public void CurrencyChange(int CurrenctChange) 
    {
        currencyText.text = "Currency: " + $"{CurrenctChange}";
    }

    public void WaveCount(int waveCount)
    {
        waveCountText.text = "Wave: " + $"{waveCount}";
    }

    public void WaveTimer(int timer)
    {
        WavetimerText.text = $"{timer}";
    }
}
