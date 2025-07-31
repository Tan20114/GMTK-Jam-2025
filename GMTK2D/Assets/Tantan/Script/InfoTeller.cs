using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InfoTeller : MonoBehaviour
{

    [Header("References")]
    [SerializeField] Canvas canvas;
    [SerializeField] RectTransform textBox;
    [SerializeField] TMP_Text infoTxt;
    [SerializeField] GraphicRaycaster uiCaster;

    [Header("Settings")]
    [SerializeField] Vector2 screenOffset = new Vector2(12f, -12f);

    void Awake()
    {
        if (canvas != null)
            if (textBox != null)
                textBox.gameObject.SetActive(false);
    }

    void Update()
    {
        if(!UICheck())
            GameObjCheck();
        FollowMouse();
    }

    void GameObjCheck()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 origin = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

        transform.position = origin;

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Infoable") && Input.GetKey(KeyCode.LeftShift))
            {
                InfoVisual infoVisual = hit.collider.gameObject.GetComponent<InfoVisual>();
                if (infoVisual != null)
                    infoTxt.text = infoVisual.GetInfo();

                textBox.gameObject.SetActive(true);
            }
            else
                textBox.gameObject.SetActive(false);
        }
        else
            textBox.gameObject.SetActive(false);
    }

    bool UICheck()
    {
        InfoVisual infoVisual = GetUIUnderCursor();
        if (infoVisual != null && Input.GetKey(KeyCode.LeftShift))
        {
            infoTxt.text = infoVisual.GetInfo();
            textBox.gameObject.SetActive(true);
            return true;   
        }
        else
        {
            textBox.gameObject.SetActive(false);
            return false;
        }
    }

    void FollowMouse()
    {
        if (textBox == null || !textBox.gameObject.activeSelf || canvas == null)
            return;

        Vector2 anchoredPos;
        Vector2 screenPos = (Vector2)Input.mousePosition + screenOffset;

        RectTransform canvasRect = canvas.transform as RectTransform;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPos,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
                out anchoredPos))
        {
            textBox.anchoredPosition = anchoredPos;
        }
    }

    InfoVisual GetUIUnderCursor()
    {
        if (EventSystem.current == null || uiCaster == null)
            return null;

        PointerEventData ped = new PointerEventData(EventSystem.current) { position = Input.mousePosition };

        List<RaycastResult> results = new List<RaycastResult>();
        uiCaster.Raycast(ped, results);

        foreach (var uiElem in results)
        {
            GameObject go = uiElem.gameObject;
            if (go == textBox.gameObject || go.transform.IsChildOf(textBox))
                continue;

            InfoVisual infoVisual = go.GetComponent<InfoVisual>()
                                    ?? go.GetComponentInParent<InfoVisual>()
                                    ?? go.GetComponentInChildren<InfoVisual>();

            if (infoVisual != null)
            {
                if (infoVisual.transform.IsChildOf(textBox))
                    continue;

                return infoVisual;
            }
        }
        return null;
    }
}
