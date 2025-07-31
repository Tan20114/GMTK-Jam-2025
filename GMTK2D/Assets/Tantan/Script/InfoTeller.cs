using TMPro;
using UnityEngine;

public class InfoTeller : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshPro infoTxt;

    // Update is called once per frame
    void Update()
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
                textBox.SetActive(true);
                infoTxt.text = hit.collider.gameObject.GetComponent<InfoVisual>().GetInfo(); 
            }
            else
                textBox.SetActive(false);
        }
        else
            textBox.SetActive(false);
    }
}
