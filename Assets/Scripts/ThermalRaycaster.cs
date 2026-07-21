using UnityEngine;
using TMPro;
using BatterySystem.Data;

public class ThermalRaycaster : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private TMP_Text infoText;

    [Header("Settings")]
    [SerializeField] private float maxDistance = 5f;

    // Yazı rengi (Açık Yeşil)
    private const string TEXT_COLOR = "#7CFC00";

    private void OnEnable()
    {
        if (lineRenderer != null)
            lineRenderer.enabled = false;

        if (infoText != null)
            infoText.text = "";
    }

    private void OnDisable()
    {
        if (lineRenderer != null)
            lineRenderer.enabled = false;

        if (infoText != null)
            infoText.text = "";
    }

    private void Update()
    {
        Ray ray = new Ray(firePoint.position, firePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);

            BatteryCell cell = hit.collider.GetComponent<BatteryCell>();

            if (cell != null)
            {
                infoText.text =
                    $"<color={TEXT_COLOR}>CELL {cell.CellID:00}\n\n" +
                    $"{cell.CurrentTemperature:0.0}°C\n\n" +
                    $"{cell.CurrentStatus.ToString().ToUpper()}</color>";
            }
            else
            {
                infoText.text = "";
            }
        }
        else
        {
            lineRenderer.enabled = false;
            infoText.text = "";
        }
    }
}