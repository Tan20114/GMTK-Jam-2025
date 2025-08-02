using UnityEngine;
using UnityEngine.Events; // เพิ่ม namespace นี้เพื่อใช้ UnityEvent

public class PortalManager : MonoBehaviour
{
    // คลาสสำหรับเก็บข้อมูลการตั้งค่าแต่ละเฟส
    [System.Serializable]
    public class PortalPhase
    {
        public int requiredCP;          // CP ที่ต้องใช้เพื่อไปยังเฟสถัดไป
        public float requiredEnergy;    // Energy ที่ต้องใช้เพื่อไปยังเฟสถัดไป
        public float suspicionRate;     // อัตราการเพิ่มความน่าสงสัยในเฟสนี้
    }

    [Header("Phase Settings")]
    public PortalPhase[] phases; // Array ของการตั้งค่าแต่ละเฟส
    public EnergySystemUI energySystem; // อ้างอิงถึงระบบ Energy ที่เราทำกันไป

    [Header("Portal Progression")]
    public int currentPhase = 0;
    public int currentCP = 0;
    public float currentSuspicion = 0f;

    // Events สำหรับแจ้งเตือนเมื่อมีการเปลี่ยนแปลง
    [Header("Events")]
    public UnityEvent onPhaseComplete;
    public UnityEvent onAllPhasesComplete;

    void Update()
    {
        // ถ้าไม่มี EnergySystem หรือทุกเฟสเสร็จสิ้นแล้ว ก็ไม่ต้องทำอะไร
        if (energySystem == null || currentPhase >= phases.Length)
        {
            return;
        }

        // เพิ่มค่าความน่าสงสัยตามอัตราของเฟสปัจจุบัน
        currentSuspicion += phases[currentPhase].suspicionRate * Time.deltaTime;

        // ตรวจสอบว่ามี CP และ Energy พอที่จะเปลี่ยนเฟสหรือยัง
        if (currentCP >= phases[currentPhase].requiredCP && energySystem.GetEnergy() >= phases[currentPhase].requiredEnergy)
        {
            AdvancePhase();
        }
    }

    public void AddCP(int amount)
    {
        currentCP += amount;
    }

    private void AdvancePhase()
    {
        // หัก Energy ที่ใช้ไป
        energySystem.RemoveEnergy(phases[currentPhase].requiredEnergy);

        currentPhase++;
        currentCP = 0;

        if (currentPhase < phases.Length)
        {
            Debug.Log($"Portal Phase {currentPhase} started!");
            onPhaseComplete.Invoke();
        }
        else
        {
            Debug.Log("All portal phases are complete!");
            onAllPhasesComplete.Invoke();
        }
    }
}