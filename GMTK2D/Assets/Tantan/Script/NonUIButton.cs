using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NonUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] UnityEvent onClick;
    bool canClick = false;

    public void OnPointerClick(PointerEventData eventData) => onClick?.Invoke();

    public void OnPointerEnter(PointerEventData eventData) => canClick = true;

    public void OnPointerExit(PointerEventData eventData) => canClick = false;
}
