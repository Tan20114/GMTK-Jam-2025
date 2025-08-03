using UnityEngine;

public class PortalShow : MonoBehaviour
{
    PortalManager pm => FindAnyObjectByType<PortalManager>();
    EnergySystemUI es => FindAnyObjectByType<EnergySystemUI>();
    [SerializeField] GameObject[] portalPhase;
    [SerializeField] float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        if (pm.currentPhase <= 4)
        {
            switch (pm.currentPhase)
            {
                case 0:
                    foreach (GameObject p in portalPhase)
                        p.SetActive(false);
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    foreach (GameObject p in portalPhase)
                        p.SetActive(false);
                    portalPhase[pm.currentPhase - 1].SetActive(true);
                    break;
            }
        }

        if(pm.currentPhase==4)
        {
            portalPhase[4].SetActive(true);
            portalPhase[4].transform.Rotate(new Vector3(0, 0, spinSpeed * Time.deltaTime));
            portalPhase[4].transform.localScale = Vector3.Lerp(Vector2.zero, new Vector2(.68f,.68f), es.GetEnergy()/es.maxEnergy);
        }
    }
}
