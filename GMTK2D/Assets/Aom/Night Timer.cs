using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pro : MonoBehaviour
{
    bool isTimeOut = false;

    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();

    public TextMeshProUGUI numTxt;
    public float countdownTime = 5f;
    public Color startColor = Color.green;
    public Color endColor = Color.red;
    private float timeLeft;

    private void Start()
    {
        ResetTimer();
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
                numTxt.text = ((int)timeLeft).ToString();

                // ????????????????????????????????
                float t = 1f - (timeLeft / countdownTime); // 0 → 1 เมื่อเวลาใกล้หมด
                numTxt.color = Color.Lerp(startColor, endColor, t);
            }
            else
            {
                numTxt.text = "0";
                Debug.Log("Timeout");
                isTimeOut = true;
            }
        }  
    }

    public void ResetTimer()
    {
        timeLeft = countdownTime;
        isTimeOut = false;
    } 
    public float GetTime() => timeLeft;
    public bool TimeOuted() => isTimeOut;
}
