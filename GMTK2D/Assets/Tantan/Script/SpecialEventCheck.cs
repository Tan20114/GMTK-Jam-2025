using System.Collections;
using UnityEngine;

public class SpecialEventCheck : MonoBehaviour
{
    public bool RandomNormalAction() => Random.Range(0, 101) > 90;
}
