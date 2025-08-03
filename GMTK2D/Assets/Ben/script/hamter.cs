using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class hamter : MonoBehaviour
{
    EventTrigger et => FindAnyObjectByType<EventTrigger>();
    PortalManager pm => FindAnyObjectByType<PortalManager>();
    EnergySystemUI es => FindAnyObjectByType<EnergySystemUI>(); 

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

    private void Update()
    {
        SUSFull();
    }

    public void IncreaseSus(int amount) => SUS += amount;

    public void DecreaseSus(int amount) => SUS -= amount;
    public void stat(int minCp, int maxCp, int susIncrease)
    {
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
            et.SUS();
            if(pm.currentPhase > 0)
            {
                if(!es.IsEnergyFull())
                {
                    if(CP >= 10)
                        CP -= 10;
                    else
                        pm.currentPhase--;
                }
                else
                {
                    es.RemoveEnergy(es.GetEnergy());
                }
            }
            es.RemoveEnergy(es.GetEnergy());
            SUS = 0;
        }
    }
}