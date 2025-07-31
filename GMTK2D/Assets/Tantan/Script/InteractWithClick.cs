using UnityEngine;

public class InteractWithClick : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 mouseOnWorld;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector2 origin = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Hit 2D object: " + hit.collider.name);
            }
            else
            {
                Debug.Log("No 2D object hit.");
            }
        }
    }
}
