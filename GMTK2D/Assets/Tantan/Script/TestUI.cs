using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();

    [SerializeField] TextMeshProUGUI dayTxt;

    // Update is called once per frame
    void Update()
    {
        dayTxt.text = $"Day {dnc.GetDay()}";
    }
}
