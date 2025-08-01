using Unity.VisualScripting;
using UnityEngine;

public enum TimeState
{
    Day,Night
}

public class DayNightCycle : MonoBehaviour
{
    int dayCount = 1;
    [SerializeField] TimeState state = TimeState.Day;
    [SerializeField] GameObject stateVisual;

    // Update is called once per frame
    void Update()
    {
        StateVisualize();
        if(Input.GetKeyDown(KeyCode.E))
        {
            switch(state)
            {
                case TimeState.Day:
                    EndDay(); 
                    break;
                case TimeState.Night:
                    EndNight();
                    break;
            }
        }
    }

    void StateVisualize()
    {
        switch (state)
        {
            case TimeState.Day:
                stateVisual.GetComponent<SpriteRenderer>().color = Color.yellow; 
                break;
            case TimeState.Night:
                stateVisual.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
    }

    void EndDay()
    {
        state = TimeState.Night;
    }

    void EndNight()
    {
        state = TimeState.Day;
        dayCount++;
    }

    public int GetDay() => dayCount;
}
