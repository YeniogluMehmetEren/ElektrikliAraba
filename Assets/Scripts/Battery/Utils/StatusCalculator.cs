using BatterySystem.Data;
using UnityEngine;

namespace BatterySystem.Utils
{
    public static class StatusCalculator
    {
        // Durum hesaplama sınırları
        public const float HealthyMinTemperature = 20f;
        public const float HealthyMaxTemperature = 35f;

        public const float WarningMinTemperature = 35f;
        public const float WarningMaxTemperature = 55f;

        public const float CriticalMinTemperature = 55f;

        public static CellStatus Calculate(float temperature)
        {
            if (temperature <= HealthyMaxTemperature)
                return CellStatus.Healthy;

            if (temperature <= WarningMaxTemperature)
                return CellStatus.Warning;

            return CellStatus.Critical;
        }

        public static bool IsHealthy(float temperature)
        {
            return temperature <= HealthyMaxTemperature;
        }

        public static bool IsWarning(float temperature)
        {
            return temperature > HealthyMaxTemperature &&
                   temperature <= WarningMaxTemperature;
        }

        public static bool IsCritical(float temperature)
        {
            return temperature > WarningMaxTemperature;
        }

        /// <summary>
        /// Termal kamera renkleri
        /// </summary>
        public static Color GetThermalColor(float temperature)
        {
            // 20 - 28 °C
            if (temperature < 28f)
                return new Color(0.15f, 0.45f, 1f); // Mavi

            // 28 - 35 °C
            if (temperature < 35f)
                return Color.green;

            // 35 - 45 °C
            if (temperature < 45f)
                return Color.yellow;

            // 45 - 55 °C
            if (temperature < 55f)
                return new Color(1f, 0.5f, 0f); // Turuncu

            // 55+ °C
            return Color.red;
        }

        public static string GetStatusText(CellStatus status)
        {
            return status switch
            {
                CellStatus.Healthy => "Healthy",
                CellStatus.Warning => "Warning",
                CellStatus.Critical => "Critical",
                _ => "Unknown"
            };
        }
    }
}