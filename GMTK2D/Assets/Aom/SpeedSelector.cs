using UnityEngine;

// สคริปต์สำหรับจัดการความเร็วและเพิ่มพลังงาน
public class SpeedSelector : MonoBehaviour
{
    hamter player => FindAnyObjectByType<hamter>();
    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();

    // กำหนดประเภทความเร็ว
    public enum SpeedType { Slow, Fast, Super }

    [Header("ตั้งค่าหลัก")]
    [Tooltip("ความเร็วปัจจุบันที่ใช้ในการสร้างพลังงาน")]
    public SpeedType currentSpeed = SpeedType.Slow;

    [Tooltip("ระบบ UI ที่ใช้แสดงและจัดการพลังงาน")]
    public EnergySystemUI energySystem;

    // คลาสสำหรับเก็บข้อมูลการตั้งค่าความเร็วแต่ละประเภท
    
    public class SpeedSetting
    {
        public float energyInterval; // ระยะเวลาในการเพิ่มพลังงาน 1 หน่วย
        public float suspicionPerSecond; // ค่าความน่าสงสัยที่เพิ่มขึ้นต่อวินาที
    }

    [Header("ตั้งค่าความเร็ว")]
    public SpeedSetting slowSpeed = new SpeedSetting { energyInterval = 4f, suspicionPerSecond = 1f };
    public SpeedSetting fastSpeed = new SpeedSetting { energyInterval = 3f, suspicionPerSecond = 2f };
    public SpeedSetting superSpeed = new SpeedSetting { energyInterval = 2f, suspicionPerSecond = 4f };

    private float timer = 0f;

    // Awake() จะทำงานก่อน Start() และเหมาะสำหรับการตั้งค่าเริ่มต้น
    void Awake()
    {
        // ตรวจสอบว่า EnergySystemUI ถูกกำหนดไว้ใน Inspector หรือไม่
        if (energySystem == null)
        {
            Debug.LogWarning("ไม่ได้กำหนด EnergySystemUI ให้กับ SpeedSelector! จะไม่สามารถสร้างพลังงานได้");
        }
    }

    void Update()
    {
        if(dnc.State == TimeState.Night)
            SpeedUpdate();
    }

    void SpeedUpdate()
    {
        // ถ้าไม่มี EnergySystemUI ก็ไม่ต้องทำอะไรต่อ
        if (energySystem == null)
            return;

        timer += Time.deltaTime;

        // ดึงการตั้งค่าของความเร็วปัจจุบัน
        SpeedSetting activeSetting;
        switch (currentSpeed)
        {
            case SpeedType.Fast: activeSetting = fastSpeed; break;
            case SpeedType.Super: activeSetting = superSpeed; break;
            case SpeedType.Slow:
            default: activeSetting = slowSpeed; break;
        }

        float interval = activeSetting.energyInterval;

        // ตรวจสอบว่าถึงเวลาที่จะเพิ่มพลังงานแล้วหรือยัง
        if (timer >= interval)
        {
            // เพิ่มพลังงาน 1 หน่วย ถ้าพลังงานยังไม่เต็ม
            if (energySystem.GetEnergy() < energySystem.maxEnergy)
            {
                energySystem.AddEnergy(1f);
            }
            // รีเซ็ตตัวจับเวลา และลบส่วนเกินที่เหลืออยู่ เพื่อความแม่นยำ
            timer -= interval;
        }

        // เพิ่มค่าความน่าสงสัยตามที่กำหนดไว้
        player.SUS += activeSetting.suspicionPerSecond * Time.deltaTime;
    }

    // ฟังก์ชันสำหรับเปลี่ยนความเร็วจากภายนอก (เช่น จากปุ่ม UI)
    public void SetSpeed(int index)
    {
        try
        {
            currentSpeed = (SpeedType)index;
        }
        catch
        {
            // แสดงข้อผิดพลาดใน Console ถ้า index ไม่ถูกต้อง
            Debug.LogError("Index ความเร็วไม่ถูกต้อง! กรุณาตรวจสอบว่า index ตรงกับ SpeedType หรือไม่");
        }
    }
}