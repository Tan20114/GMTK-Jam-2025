using UnityEngine;
using UnityEngine.UI;

public class Pro : MonoBehaviour
{
    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();

    public Slider timeBar;
    public float countdownTime = 5f;
    public Color startColor = Color.green;
    public Color endColor = Color.red;
    private float timeLeft;
    private Image fillImage;

    void Start()
    {
        fillImage = timeBar.fillRect.GetComponent<Image>();
        fillImage.color = startColor;
        timeLeft = countdownTime;
        timeBar.maxValue = countdownTime;
        timeBar.value = countdownTime;
    }
    void Update()
    {
        StartTimer();
    }

    void StartTimer()
    {
        if(dnc.State == TimeState.Night)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timeBar.value = timeLeft;

                // ????????????????????????????????
                float t = 1f - (timeLeft / countdownTime); // 0 → 1 เมื่อเวลาใกล้หมด
                fillImage.color = Color.Lerp(startColor, endColor, t);
            }
            else
            {
                timeBar.value = 0;
                Debug.Log("Timeout");
            }
        }  
    }

    public void ResetTimer() => timeLeft = countdownTime;
    public float GetTime() => timeLeft;
}
