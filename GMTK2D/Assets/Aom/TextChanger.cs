using UnityEngine;
using TMPro;

public class TMProChanger : MonoBehaviour
{
    // ตัวแปรที่ใช้เก็บ TextMeshPro Component
    public TextMeshProUGUI targetText;

    // ฟังก์ชันสำหรับเปลี่ยนข้อความ
    public void ChangeText(string newText)
    {
        // ตรวจสอบว่า targetText ถูกกำหนดค่าไว้หรือไม่
        if (targetText != null)
        {
            // เปลี่ยนข้อความใน Text Component
            targetText.text = newText;
        }
    }
}