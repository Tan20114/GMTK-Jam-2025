using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DayNightUI : MonoBehaviour
{
    EventTrigger et => FindAnyObjectByType<EventTrigger>();
    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();
    SpecialEventCheck sec => FindAnyObjectByType<SpecialEventCheck>();
    hamter player => FindAnyObjectByType<hamter>();

    bool isGameStart = false;

    [SerializeField] Animator a;

    [Header("UI Elem")]
    [SerializeField] TextMeshProUGUI dayTxt;
    [SerializeField] GameObject dayUI;
    [SerializeField] GameObject exploreButt;
    [SerializeField] GameObject destroyButt;
    [SerializeField] GameObject ActNormButt;
    [SerializeField] GameObject ActNoButt;
    [SerializeField] GameObject nightUI;
    [SerializeField] GameObject SpaceToEnd;

    [Header("BG Elem")]
    [SerializeField] Image[] BG;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActNormalEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStart)
        {
            StateVisualize();
            ButtonVisualize();
        }

        if(player.AP <= 0)
        {
            SpaceToEnd.SetActive(true);
        }
        else
        {
            SpaceToEnd.SetActive(false);
        }
    }

    void ButtonVisualize()
    {
        if(player.AP <= 0 || et.isEvent)
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
                foreach (Image i in BG)
                    i.color = Color.white;
                break;
            case TimeState.Night:
                dayUI.SetActive(false);
                nightUI.SetActive(true);
                foreach (Image i in BG)
                    i.color = new Color(.15f,.3f,.65f,1);
                ActNormalEvent();
                break;
        }

        dayTxt.text = $"Day : {dnc.DayCount}";
    }

    public void ActNormalEvent()
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

    void StartGame() => isGameStart = true;

    public void OnStart() => StartCoroutine(StartAnim());

    IEnumerator StartAnim()
    {
        a.SetTrigger("start");
        yield return new WaitForSeconds(1);
        StartGame();
    }
}
