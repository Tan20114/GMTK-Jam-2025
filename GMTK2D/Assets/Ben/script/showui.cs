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
    public float smoothSpeed = 30f;

    void Start()
    {
        player.onStatChanged += UpdateTextInstant;
        UpdateTextInstant();
    }

    void Update()
    {
        currentSusValue = Mathf.MoveTowards(currentSusValue, player.SUS, smoothSpeed * Time.deltaTime);
        susBar.value = currentSusValue;
    }

    void UpdateTextInstant()
    {
        cpText.text = "CP: " + player.cp;
        apText.text = "AP: " + ((player.AP >= 0) ? player.AP : 0);
    }
}