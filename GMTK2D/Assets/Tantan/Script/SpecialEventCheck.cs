using UnityEngine;

public class SpecialEventCheck : MonoBehaviour
{
    hamter player => FindAnyObjectByType<hamter>();

    [SerializeField] int exploreConsectCount = 0;
    [SerializeField] int destroyConsectCount = 0;
    [SerializeField] int actNormalCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConsecutiveEventTrigger();
    }

    void ConsecutiveEventTrigger()
    {
        if(exploreConsectCount >= 3 ||  destroyConsectCount >= 3 || actNormalCount >= 3)
        {
            player.SUS += 10;
            exploreConsectCount = 0;
            destroyConsectCount = 0;
            actNormalCount = 0;
        }
    }

    public void ExConsecutiveCount()
    {
        if(player.AP <= 0) return;

        exploreConsectCount++;
        destroyConsectCount = 0;
        actNormalCount = 0;
    }

    public void DesConsecutiveCount()
    {
        if(player.AP <= 0) return;

        exploreConsectCount = 0;
        destroyConsectCount++;
        actNormalCount = 0;
    }

    public void ActConsecutiveCount()
    {
        if (player.AP <= 0) return;

        exploreConsectCount = 0;
        destroyConsectCount = 0;
        actNormalCount++;
    }

    public bool RandomNormalAction() => Random.Range(0, 101) > 70;
}
