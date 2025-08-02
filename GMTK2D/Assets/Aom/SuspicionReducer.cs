using UnityEngine;

public class SuspicionReducer : MonoBehaviour
{
    hamter player => FindAnyObjectByType<hamter>();
    DayNightCycle dnc => FindAnyObjectByType<DayNightCycle>();

    [Header("Reduction Settings")]
    public float susReductionInterval = 5f; // ลด SUS ทุกๆ 5 วินาที
    public float susReductionAmount = 5f;   // ลดครั้งละ 5 หน่วย

    [Header("System References")]
    // ตัวแปรสำหรับอ้างอิงถึงระบบที่จะเก็บค่า Suspicion
    // ในที่นี้เราจะใช้ PortalManager ซึ่งมีตัวแปร suspicion อยู่
    public PortalManager portalManager;

    private float susReductionTimer = 0f;

    void Start()
    {
        if (portalManager == null)
        {
            Debug.LogError("PortalManager is not assigned to SuspicionReducer!");
        }
    }

    void Update()
    {
        if (dnc.State == TimeState.Night)
            SUSReduction();
    }

    void SUSReduction()
    {
        // เราจะลดค่า SUS ก็ต่อเมื่อค่า SUS ยังมากกว่า 0
        if (player.SUS > 0)
        {
            susReductionTimer += Time.deltaTime;

            if (susReductionTimer >= susReductionInterval)
            {
                player.SUS -= susReductionAmount;
                player.SUS = Mathf.Max(0, player.SUS); // ป้องกันค่าติดลบ
                susReductionTimer -= susReductionInterval;
            }
        }
        else
        {
            // ถ้าค่า SUS เป็น 0 หรือติดลบ ให้รีเซ็ต Timer
            susReductionTimer = 0;
        }
    }    
}