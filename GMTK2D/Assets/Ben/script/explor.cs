using UnityEngine;
using UnityEngine.UI;

public class explor : MonoBehaviour
{
    public hamter player;
    public int minCp = 2;
    public int maxCp = 6;
    public int susIncrease = 10;
    public Button button;

    public void statup() => player.stat(minCp, maxCp, susIncrease);

}