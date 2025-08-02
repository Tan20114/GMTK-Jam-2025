using UnityEngine;
using UnityEngine.UI;

public class SUSSystem : MonoBehaviour
{
    public Text susText;           // ตัวแสดงค่า SUS บน UI
    public float currentSUS = 0f;  // ค่าสะสม SUS ปัจจุบัน
    public float maxSUS = 100f;    // ค่า SUS สูงสุด
    public float decayAmount = 5f; // SUS ที่จะลดลง
    public float decayInterval = 5f; // ทุกๆ กี่วินาทีจะลด SUS

    private float decayTimer = 0f;

    void Update()
    {
        decayTimer += Time.deltaTime;

        if (decayTimer >= decayInterval)
        {
            currentSUS -= decayAmount;
            currentSUS = Mathf.Clamp(currentSUS, 0f, maxSUS);
            decayTimer = 0f;
            UpdateSUSUI();
        }
    }

    public void AddSUS(float amount)
    {
        currentSUS += amount;
        currentSUS = Mathf.Clamp(currentSUS, 0f, maxSUS);
        UpdateSUSUI();
    }

    private void UpdateSUSUI()
    {
        if (susText != null)
            susText.text = "SUS: " + Mathf.RoundToInt(currentSUS);
    }

    public float GetSUS()
    {
        return currentSUS;
    }
}