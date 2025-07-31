using UnityEngine;
using UnityEngine.UI;

public class desmth : MonoBehaviour
{
    public hamter player;
    public int minCp = 3;
    public int maxCp = 7;
    public int susIncrease = 25;
    public Button button;


    public void statup() => player.stat(minCp, maxCp, susIncrease);
}