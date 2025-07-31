using UnityEngine;
using UnityEngine.UI;

public class desmth : MonoBehaviour
{
    hamter player => FindAnyObjectByType<hamter>();
    public int minCp = 3;
    public int maxCp = 7;
    public int susIncrease = 25;


    public void statup() => player.stat(minCp, maxCp, susIncrease);
}