using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergySystemUI : MonoBehaviour
{
    public Slider energySlider;
    public Text energyText;
    public float maxEnergy = 50f;

    private float currentEnergy = 0f;

    void Start()
    {
        // กำหนดค่าเริ่มต้นของ UI เมื่อเริ่มเกม
        InitializeUI();
    }

    void Update()
    {
        // เรียกใช้ฟังก์ชันนี้ในทุกเฟรมเพื่อให้ UI อัปเดตตลอดเวลา
        UpdateUI();
    }

    // ฟังก์ชันสำหรับเพิ่มพลังงาน
    public void AddEnergy(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);
    }
    public void RemoveEnergy(float amount)
    {
        currentEnergy -= amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);
    }

    // ฟังก์ชันสำหรับดึงค่าพลังงานปัจจุบัน
    public float GetEnergy()
    {
        return currentEnergy;
    }

    // ฟังก์ชันสำหรับตรวจสอบว่าพลังงานเต็มแล้วหรือยัง
    public bool IsEnergyFull()
    {
        return currentEnergy >= maxEnergy;
    }

    private void InitializeUI()
    {
        if (energySlider != null)
        {
            energySlider.minValue = 0f;
            energySlider.maxValue = maxEnergy;
            energySlider.value = currentEnergy;
        }

        if (energyText != null)
        {
            energyText.text = "Energy: " + currentEnergy + " / " + maxEnergy;
        }
    }

    private void UpdateUI()
    {
        if (energySlider != null)
            energySlider.value = currentEnergy;

        if (energyText != null)
            // ใช้ string.Format เพื่อจัดรูปแบบข้อความให้ดูสวยงามขึ้น
            energyText.text = $"Energy: {Mathf.Floor(currentEnergy)} / {maxEnergy}";
    }
}