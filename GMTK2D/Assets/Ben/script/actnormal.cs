using UnityEngine;
using UnityEngine.UI;

public class actnormal : MonoBehaviour
{
    public hamter player;
    public int minCp = 0;
    public int maxCp = 0;
    public int susIncrease = -10;
    public Button button;

    public void statup() => player.stat(minCp, maxCp, susIncrease);
}