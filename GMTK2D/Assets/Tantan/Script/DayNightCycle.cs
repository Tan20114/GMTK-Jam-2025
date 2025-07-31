using Unity.VisualScripting;
using UnityEngine;

public enum TimeState
{
    Day,Night
}

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] TimeState state = TimeState.Day;
    [SerializeField] GameObject stateVisual;

    // Update is called once per frame
    void Update()
    {
        StateVisualize();
        if(Input.GetKey(KeyCode.E))
        {

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
    }
}
