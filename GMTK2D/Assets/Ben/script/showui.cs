using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class showui : MonoBehaviour
{
    public hamter player;
    public TextMeshProUGUI cpText;
    public TextMeshProUGUI apText;
    public Slider susBar;

    private float currentSusValue = 0f;
    public float smoothSpeed = 100f;

    void Update()
    {
        currentSusValue = Mathf.MoveTowards(currentSusValue, player.SUS, smoothSpeed * Time.deltaTime);
        susBar.value = currentSusValue;
        UpdateTextInstant();
    }

    void UpdateTextInstant()
    {
        cpText.text = player.CP.ToString();
        apText.text = ((player.AP >= 0) ? player.AP : 0).ToString();
    }
}