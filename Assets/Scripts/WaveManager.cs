using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
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

        Debug.Log(waveTimer.Progress * waveTimeCooldown);
    }

    public void StartWave()
    {
        //OnWaveStarted?.invoke
        IsInWave = true;
    }

    public void EndWave()
    {
        IsInWave = false;
        waveTimer.Reset();
        wavesAmount++;
    }

}
