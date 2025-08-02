using Unity.VisualScripting;
using UnityEngine;

public enum TimeState
{
    Day,Night
}

public class DayNightCycle : MonoBehaviour
{
    SpeedSelector ss => FindAnyObjectByType<SpeedSelector>();
    hamter player => FindAnyObjectByType<hamter>();
    [Header("Reference")]
    [SerializeField] Pro nightTimer;

    int dayCount = 1;
    public int DayCount
    {
        get => dayCount;
    }
    [Header("State")]
    [SerializeField] TimeState state = TimeState.Day;
    public TimeState State
    {
        get => state;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.AP <= 0 && Input.GetKeyDown(KeyCode.Space))
            EndDay();

        if(nightTimer.GetTime() <= 0)
            EndNight();
    }

    void EndDay()
    {
        player.ResetAP();
        player.SUS -= 10f;
        state = TimeState.Night;
    }

    void EndNight()
    {
        state = TimeState.Day;
        nightTimer.ResetTimer();
        ss.currentSpeed = SpeedType.Slow;
        dayCount++;
    }
}
