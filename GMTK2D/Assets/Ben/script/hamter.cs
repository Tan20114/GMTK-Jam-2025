using UnityEngine;
using System.Collections;

public class hamter : MonoBehaviour
{
    public int cp = 0;
    private int sus = 0;
    public int ap = 3;

    public int SUS
    {
        get => sus;
        private set
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

    public void IncreaseSus(int amount)
    {
        if (susCoroutine != null) StopCoroutine(susCoroutine);
        susCoroutine = StartCoroutine(IncreaseSusSmooth(amount));
    }

    public void DecreaseSus(int amount)
    {
        if (susCoroutine != null) StopCoroutine(susCoroutine);
        susCoroutine = StartCoroutine(DecreaseSusSmooth(amount));
    }

    public void stat(int minCp, int maxCp, int susIncrease)
    {
        if (AP <= 0) return;

        int increaseAmount = Random.Range(minCp, maxCp + 1);
        cp += increaseAmount;
        AP -= 1;

        if (susIncrease > 0)
            IncreaseSus(susIncrease);
        else if (susIncrease < 0)
            DecreaseSus(-susIncrease);
    }

    private IEnumerator IncreaseSusSmooth(int amount)
    {
        int targetSus = SUS + amount;
        targetSus = Mathf.Clamp(targetSus, 0, 100);

        while (SUS < targetSus)
        {
            SUS += 1;
            onStatChanged?.Invoke();
            yield return new WaitForSeconds(0.02f);
        }

        susCoroutine = null;
    }

    private IEnumerator DecreaseSusSmooth(int amount)
    {
        int targetSus = SUS - amount;
        targetSus = Mathf.Clamp(targetSus, 0, 100);

        while (SUS > targetSus)
        {
            SUS -= 1;
            onStatChanged?.Invoke();
            yield return new WaitForSeconds(0.02f);
        }

        susCoroutine = null;
    }
}