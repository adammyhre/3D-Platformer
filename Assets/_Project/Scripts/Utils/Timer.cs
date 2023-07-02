using System;

public abstract class Timer {
    protected float initialTime;
    protected float Time { get; set; }
    public bool IsRunning { get; protected set; }
    public Action OnTimerStart = delegate { };
    public Action OnTimerEnd = delegate { };

    protected Timer(float value) {
        initialTime = value;
        IsRunning = false;
    }

    public void StartTimer() {
        Time = initialTime;
        IsRunning = true;
        OnTimerStart.Invoke();
    }

    public void PauseTimer() => IsRunning = false;

    public void ResumeTimer() => IsRunning = true;

    public abstract void UpdateTimer(float deltaTime);
}

public class CountdownTimer : Timer {
    public CountdownTimer(float value) : base(value) { }

    public override void UpdateTimer(float deltaTime) {
        if (IsRunning && Time > 0) {
            Time -= deltaTime;
        }

        if (IsRunning && Time <= 0) {
            OnTimerEnd.Invoke();
            IsRunning = false;
        }
    }

    public bool IsDone => Time <= 0;

    public void ResetTimer() => initialTime = Time;

    public void ResetTimer(float newTime) => initialTime = newTime;
}

public class StopwatchTimer : Timer {
    public StopwatchTimer() : base(0) { }

    public override void UpdateTimer(float deltaTime) {
        if (IsRunning) {
            Time += deltaTime;
        }
    }

    public float GetTime() => Time;

    public void ResetTimer() => Time = 0;
}