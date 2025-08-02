using UnityEngine;
using UnityEngine.UI;
using TMPro; // ถ้าใช้ TextMeshPro

public class PortalUI : MonoBehaviour
{
    hamter player => FindAnyObjectByType<hamter>();

    [Header("UI References")]
    public Slider progressBar;
    public TextMeshProUGUI cpText; // ใช้ TextMeshProUGUI ถ้าใช้ TextMeshPro
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI suspicionText;

    [Header("System References")]
    public PortalManager portalManager;

    void Start()
    {
        // ตรวจสอบว่า portalManager ถูกกำหนดค่าไว้หรือไม่
        if (portalManager == null)
        {
            Debug.LogError("PortalManager is not assigned to PortalUI!");
            return;
        }

        // กำหนดค่าเริ่มต้นของ Progress Bar
        InitializeUI();
    }

    void Update()
    {
        // อัปเดต UI ทุกๆ เฟรม
        UpdateUI();
    }

    private void InitializeUI()
    {
        // กำหนดค่า Max Value ของ Slider ตาม CP ที่ต้องใช้ในเฟสแรก
        if (portalManager.phases.Length > 0 && progressBar != null)
        {
            progressBar.value = 0;
        }
    }

    private void UpdateUI()
    {
        if (portalManager == null)
            return;

        // ดึงข้อมูลเฟสปัจจุบัน
        int currentPhaseIndex = portalManager.currentPhase;

        if (currentPhaseIndex < portalManager.phases.Length)
        {
            PortalManager.PortalPhase currentPhaseData = portalManager.phases[currentPhaseIndex];

            // อัปเดต Progress Bar
            if (progressBar != null)
            {
                progressBar.value = portalManager.currentCP/currentPhaseData.requiredCP;
            }

            // อัปเดต Text ของ CP
            if (cpText != null)
            {
                cpText.text = $"{portalManager.currentCP} / {currentPhaseData.requiredCP} CP";
            }

            // อัปเดต Text ของ Phase
            if (phaseText != null)
            {
                // แสดงผลให้ผู้ใช้เข้าใจง่าย เช่น Phase 1, 2, 3...
                phaseText.text = $"Phase: {currentPhaseIndex + 1}";
            }

            // อัปเดต Text ของ Suspicion
            if (suspicionText != null)
            {
                // ใช้ Mathf.Floor เพื่อให้แสดงผลเป็นจำนวนเต็ม
                suspicionText.text = $"Suspicion: {Mathf.Floor(player.SUS)}";
            }
        }
        else // ถ้าเฟสเสร็จสมบูรณ์หมดแล้ว
        {
            if (cpText != null) cpText.text = "All CP Collected!";
            if (phaseText != null) phaseText.text = "Portal Complete!";
        }
    }
}