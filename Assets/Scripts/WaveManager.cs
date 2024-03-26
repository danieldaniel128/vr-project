using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public UnityEvent<int> OnWaveCountChanged;
    public int WaveAmount { get { return wavesAmountNumber; } set { wavesAmountNumber = value; OnWaveCountChanged?.Invoke(wavesAmountNumber); } }

    [SerializeField] public UnityEvent<int> OnWaveTimeChange;
    public int WaveTimer { get { return WaveTimeNumber; } set { WaveTimeNumber = value;  OnWaveTimeChange?.Invoke(WaveTimeNumber); } }
    public int WaveTimeNumber { get => (int)(waveTimer.Progress * waveTimeCooldown); private set { } }

    [SerializeField] private UnityEvent OnWaveEnded;
    [SerializeField] private UnityEvent OnWaveStarted;
    [SerializeField] private int restTimerCoolDown = 0;
    [SerializeField] private float waveTimeCooldown = 4;
    [SerializeField] private PlayerCurrency playerCurrency;
    private int playerCurrencyNum = 100;
    private bool IsInWave = false;
    private int wavesAmountNumber = 0;
    public CountdownTimer waveTimer;
    private CountdownTimer restTimer;


    private void Start()
    {
        OnWaveCountChanged?.Invoke(wavesAmountNumber);
        waveTimer = new CountdownTimer(waveTimeCooldown);
        restTimer = new CountdownTimer(restTimerCoolDown);
        waveTimer.OnTimerStart += StartWave;
        waveTimer.OnTimerStop += EndWave;
        waveTimer.Start();
    }
    private void OnEnable()
    {
        if (waveTimer == null)
            return;
        waveTimer.OnTimerStart += StartWave;
        waveTimer.OnTimerStop += EndWave;
        waveTimer.Start();
    }
    [ContextMenu("start a wave")]
    void StartTimerTest()
    {
        waveTimer.Start();
    }
    private void OnDisable()
    {
        waveTimer.OnTimerStart -= StartWave;
        waveTimer.OnTimerStop -= EndWave;
    }

    private void Update()
    {
        waveTimer.Tick(Time.deltaTime);

        OnWaveTimeChange?.Invoke(WaveTimer);
    }

    public void StartWave()
    {
        OnWaveCountChanged?.Invoke(wavesAmountNumber);
        OnWaveTimeChange?.Invoke(WaveTimer);
        IsInWave = true;
    }
    public void EndWave()
    {
        waveTimer.Reset();
        waveTimer.Start();
        OnWaveTimeChange?.Invoke(WaveTimer);
        IsInWave = false;
        WaveAmount++;
    }

}
