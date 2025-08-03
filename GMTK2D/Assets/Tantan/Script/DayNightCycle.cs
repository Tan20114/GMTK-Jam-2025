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

    [SerializeField] Animator wheel;

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

        if(nightTimer.TimeOuted())
            EndNight();
    }

    void EndDay()
    {
        Debug.Log("EndDay");
        player.ResetAP();
        player.SUS -= 10f;
        state = TimeState.Night;
        wheel.SetBool("isNight", true);
    }

    void EndNight()
    {
        Debug.Log("EndNight");
        state = TimeState.Day;
        nightTimer.ResetTimer();
        ss.currentSpeed = SpeedType.Slow;
        wheel.SetBool("isNight", false);
        dayCount++;
    }
}
