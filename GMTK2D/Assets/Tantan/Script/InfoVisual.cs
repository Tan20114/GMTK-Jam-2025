using UnityEngine;

public class InfoVisual : MonoBehaviour
{
    [SerializeField] string info;

    public string GetInfo() => info;
}
