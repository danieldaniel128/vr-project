using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private UnityEvent OnWaveStart;
    [SerializeField] private UnityEvent OnWaveEnd;
    [SerializeField] private int restTimer = 0;
    private float waveTimer = 180;
    private bool IsInWave = false;
    private int wavesAmount = 0;

    private CountdownTimer countdownTimer;

    private void Start()
    {
        countdownTimer = new CountdownTimer(waveTimer);
        StartWave();
    }

    private void Update()
    {
        if (IsInWave)
        {
            countdownTimer.Tick(Time.deltaTime);

            Debug.Log(countdownTimer.Progress);

            if (countdownTimer.IsFinished)
            {
                EndWave();
                wavesAmount++;

                Debug.Log(wavesAmount);
            }
        }
    }

    public void StartWave()
    {
        IsInWave = true;
        OnWaveStart.Invoke();
        countdownTimer.Start();
    }

    public void EndWave()
    {
        IsInWave = false;
        countdownTimer.Reset();
        OnWaveEnd.Invoke();
    }

}
