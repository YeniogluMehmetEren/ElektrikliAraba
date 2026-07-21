using System.Collections.Generic;
using UnityEngine;
using BatterySystem.Managers;
using BatterySystem.Data;
using BatterySystem.Utils;

namespace BatterySystem.Thermal
{
    public class ThermalDisplay : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private BatteryManager batteryManager;

        private readonly List<MeshRenderer> thermalRenderers = new();

        private void Awake()
        {
            thermalRenderers.Clear();

            foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>(true))
            {
                if (renderer.name.StartsWith("T_Cube"))
                {
                    thermalRenderers.Add(renderer);
                }
            }

            thermalRenderers.Sort((a, b) => a.name.CompareTo(b.name));

            Debug.Log($"Thermal Renderer Count : {thermalRenderers.Count}");
        }

        private void Start()
        {
            RefreshThermal();
        }

        public void RefreshThermal()
        {
            if (batteryManager == null)
                return;

            int count = Mathf.Min(batteryManager.Cells.Count, thermalRenderers.Count);

            for (int i = 0; i < count; i++)
            {
                BatteryCell cell = batteryManager.Cells[i];
                MeshRenderer renderer = thermalRenderers[i];

                Material material = renderer.material;

                Color targetColor = StatusCalculator.GetThermalColor(cell.CurrentTemperature);

                if (material.HasProperty("_BaseColor"))
                    material.SetColor("_BaseColor", targetColor);

                if (material.HasProperty("_Color"))
                    material.color = targetColor;

                Color appliedColor = material.HasProperty("_BaseColor")
                    ? material.GetColor("_BaseColor")
                    : material.color;

                Debug.Log("========================================");
                Debug.Log($"INDEX               : {i}");
                Debug.Log($"BatteryCell Object  : {cell.gameObject.name}");
                Debug.Log($"Renderer Object     : {renderer.gameObject.name}");
                Debug.Log($"CellID              : {cell.CellID}");
                Debug.Log($"Temperature         : {cell.CurrentTemperature}");
                Debug.Log($"Status              : {cell.CurrentStatus}");
                Debug.Log($"Applied Color       : {GetColorName(appliedColor)}");
                Debug.Log($"RGB                 : ({appliedColor.r:0.00}, {appliedColor.g:0.00}, {appliedColor.b:0.00})");
            }
        }

        private string GetColorName(Color color)
        {
            if (Approximately(color, Color.blue))
                return "BLUE";

            if (Approximately(color, Color.green))
                return "GREEN";

            if (Approximately(color, Color.yellow))
                return "YELLOW";

            if (Approximately(color, Color.red))
                return "RED";

            if (Mathf.Abs(color.r - 1f) < 0.01f &&
                Mathf.Abs(color.g - 0.5f) < 0.01f &&
                Mathf.Abs(color.b - 0f) < 0.01f)
                return "ORANGE";

            return "UNKNOWN";
        }

        private bool Approximately(Color a, Color b)
        {
            return Mathf.Abs(a.r - b.r) < 0.01f &&
                   Mathf.Abs(a.g - b.g) < 0.01f &&
                   Mathf.Abs(a.b - b.b) < 0.01f;
        }
    }
}