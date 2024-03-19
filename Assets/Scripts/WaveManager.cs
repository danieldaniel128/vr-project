using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public UnityEvent<int> OnWaveCountChanged;
    public int WaveAmount { get { return wavesAmount; } set { wavesAmount = value; OnWaveCountChanged?.Invoke(wavesAmount); } }

    [SerializeField] public UnityEvent<int> OnWaveTimeChange;
    public int WaveTimer { get { return WaveTimeAmount; } set { WaveTimeAmount = value;  OnWaveTimeChange?.Invoke(WaveTimeAmount); } }
    public int WaveTimeAmount { get => (int)(waveTimer.Progress * waveTimeCooldown); private set { } }

    [SerializeField] private UnityEvent OnWaveEnded;
    [SerializeField] private UnityEvent OnWaveStarted;
    [SerializeField] private int restTimerCoolDown = 0;
    [SerializeField] private float waveTimeCooldown = 4;
    [SerializeField] private PlayerCurrency playerCurrency;
    private int playerCurrencyNum = 100;
    private bool IsInWave = false;
    private int wavesAmount = 0;
    private CountdownTimer waveTimer;
    private CountdownTimer restTimer;


    private void Start()
    {
        OnWaveCountChanged?.Invoke(wavesAmount);
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
        //OnWaveStarted?.invoke
        OnWaveTimeChange?.Invoke(WaveTimer);
        IsInWave = true;
    }
    public void EndWave()
    {
        OnWaveCountChanged?.Invoke(wavesAmount);
        IsInWave = false;
        waveTimer.Reset();
        wavesAmount++;
    }

}
