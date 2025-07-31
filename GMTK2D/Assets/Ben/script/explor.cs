using UnityEngine;
using UnityEngine.UI;

public class explor : MonoBehaviour
{
    hamter player => FindAnyObjectByType<hamter>();
    public int minCp = 2;
    public int maxCp = 6;
    public int susIncrease = 10;

    public void statup() => player.stat(minCp, maxCp, susIncrease);

}