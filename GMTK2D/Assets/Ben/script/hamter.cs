using UnityEngine;
using System.Collections;

public class hamter : MonoBehaviour
{

    [SerializeField] int cp;
    public int CP
    {
        get => cp;
        set
        {
            cp = Mathf.Max(value,0);
        }
    }
    [SerializeField] private float sus = 0;
    public int ap = 3;

    public float SUS
    {
        get => sus;
        set
        {
            sus = Mathf.Clamp(value, 0, 100);
        }
    }

    public int AP
    {
        get => ap;
        set
        {
            ap = Mathf.Clamp(value, 0, 3);
            onStatChanged?.Invoke();
        }
    }

    public delegate void OnStatChanged();
    public event OnStatChanged onStatChanged;

    private Coroutine susCoroutine = null;

    private void Update()
    {
        SUSFull();
    }

    public void IncreaseSus(int amount) => SUS += amount;

    public void DecreaseSus(int amount) => SUS -= amount;
    public void stat(int minCp, int maxCp, int susIncrease)
    {
        if (AP <= 0) return;

        int increaseAmount = Random.Range(minCp, maxCp + 1);
        CP += increaseAmount;
        AP -= 1;

        if (susIncrease > 0)
            IncreaseSus(susIncrease);
        else if (susIncrease < 0)
            DecreaseSus(-susIncrease);
    }

    public void ResetAP() => AP = 3;

    private void SUSFull()
    {
        if(SUS >= 100)
        {
            Debug.Log("reset");
            SUS = 0;
            CP -= 10;
        }
    }
}