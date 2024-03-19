using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI waveCountText;
    [SerializeField] private TextMeshProUGUI WavetimerText;
    [SerializeField] private Image healthImage;

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
    public void UpdateHealthBar(float currentHealth,float maxHealth)
    {
        healthImage.fillAmount = currentHealth/ maxHealth;
    }
}
