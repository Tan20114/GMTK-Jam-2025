using UnityEngine;
using UnityEngine.UI;

public class actnormal : MonoBehaviour
{
    hamter player => FindAnyObjectByType<hamter>();
    public int minCp = 0;
    public int maxCp = 0;
    public int susIncrease = -10;

    public void statup() => player.stat(minCp, maxCp, susIncrease);

    public void StatDown() => player.stat(0, 0, 10);
}