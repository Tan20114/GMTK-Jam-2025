using TMPro;
using UnityEngine;

public class DayNightUI : MonoBehaviour
{
    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();

    [Header("UI Elem")]
    [SerializeField] TextMeshProUGUI dayTxt;
    [SerializeField] GameObject dayUI;
    [SerializeField] GameObject nightUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateVisualize();
    }

    void StateVisualize()
    {
        switch (dnc.State)
        {
            case TimeState.Day:
                dayUI.SetActive(true);
                nightUI.SetActive(false);
                break;
            case TimeState.Night:
                dayUI.SetActive(false);
                nightUI.SetActive(true);
                break;
        }
    }
}
