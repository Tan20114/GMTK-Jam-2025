using System.Collections;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    Animator trigger => GetComponent<Animator>();
    hamter player => FindAnyObjectByType<hamter>();
    public bool isEvent = false;
    [SerializeField] AnimationClip[] outClip;
    [SerializeField] float animTime = 0;
    [SerializeField] AudioClip[] sClip;

    public void Des() => StartCoroutine(DestroyTrigger());
    public void Ex() => StartCoroutine(ExploreTrigger());
    public void No() => StartCoroutine(NoTrigger());
    public void Nor() => StartCoroutine(NorTrigger());
    public void SUS() => StartCoroutine(SUSTrigger());

    IEnumerator DestroyTrigger()
    {
        if(player.SUS < 75)
        {
            trigger.SetTrigger("Des");
            SFXManager.instance.PlaySFXClip(sClip[0]);
            isEvent = true;
            yield return new WaitForSeconds(animTime);
            trigger.SetTrigger("DesOut");
            yield return new WaitForSeconds(outClip[0].length + .5f);
            isEvent = false;
        }
    }

    IEnumerator ExploreTrigger()
    {
        if (player.SUS < 90)
        {
            trigger.SetTrigger("Ex");
            SFXManager.instance.PlaySFXClip(sClip[1]);
            isEvent = true;
            yield return new WaitForSeconds(animTime);
            trigger.SetTrigger("ExOut");
            yield return new WaitForSeconds(outClip[1].length + .5f);
            isEvent = false;
        }
    }

    IEnumerator NoTrigger()
    {
        if (player.SUS < 90)
        {
            trigger.SetTrigger("No");
            SFXManager.instance.PlaySFXClip(sClip[2]);
            isEvent = true;
            yield return new WaitForSeconds(animTime);
            trigger.SetTrigger("NoOut");
            yield return new WaitForSeconds(outClip[2].length + .5f);
            isEvent = false;
        }
    }

    IEnumerator NorTrigger()
    {
        if (player.SUS < 100)
        {
            trigger.SetTrigger("Nor");
            SFXManager.instance.PlaySFXClip(sClip[2]);
            isEvent = true;
            yield return new WaitForSeconds(animTime);
            trigger.SetTrigger("NorOut");
            yield return new WaitForSeconds(outClip[3].length + .5f);
            isEvent = false;
        }
    }

    public IEnumerator SUSTrigger()
    {
        trigger.SetTrigger("SUS");
        isEvent = true;
        yield return new WaitForSeconds(animTime);
        trigger.SetTrigger("SUSOut");
        yield return new WaitForSeconds(outClip[4].length + .5f);
        isEvent = false;
    }
}
