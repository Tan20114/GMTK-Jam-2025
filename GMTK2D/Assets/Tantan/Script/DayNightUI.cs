using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNightUI : MonoBehaviour
{
    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();
    SpecialEventCheck sec => FindAnyObjectByType<SpecialEventCheck>();
    hamter player => FindAnyObjectByType<hamter>();

    [Header("UI Elem")]
    [SerializeField] TextMeshProUGUI dayTxt;
    [SerializeField] GameObject dayUI;
    [SerializeField] GameObject exploreButt;
    [SerializeField] GameObject destroyButt;
    [SerializeField] GameObject ActNormButt;
    [SerializeField] GameObject ActNoButt;
    [SerializeField] GameObject nightUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActNormalEvent();
    }

    // Update is called once per frame
    void Update()
    {
        StateVisualize();
        ButtonVisualize();
    }

    void ButtonVisualize()
    {
        if(player.AP <= 0)
        {
            exploreButt.GetComponent<Button>().interactable = false;
            destroyButt.GetComponent<Button>().interactable = false;
            ActNormButt.GetComponent<Button>().interactable = false;
            ActNoButt.GetComponent<Button>().interactable = false;
        }
        else
        {
            exploreButt.GetComponent<Button>().interactable = true;
            destroyButt.GetComponent<Button>().interactable = true;
            ActNormButt.GetComponent<Button>().interactable = true;
            ActNoButt.GetComponent<Button>().interactable = true;
        }
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
                ActNormalEvent();
                break;
        }

        dayTxt.text = $"Day : {dnc.DayCount}";
    }

    void ActNormalEvent()
    {
        if (sec.RandomNormalAction())
        {
            ActNoButt.SetActive(true);
            ActNormButt.SetActive(false);
        }
        else
        {
            ActNoButt.SetActive(false);
            ActNormButt.SetActive(true);
        }
    }
}
