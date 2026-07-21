using System.Collections.Generic;
using UnityEngine;
using BatterySystem.Data;
using BatterySystem.Utils;
using BatterySystem.Thermal;

namespace BatterySystem.Managers
{
    public class TemperatureGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private BatteryManager batteryManager;

        [Header("Scenario")]
        [SerializeField] private BatteryScenario scenario = BatteryScenario.AutoRandom;

        [Header("Healthy Battery")]
        [SerializeField] private Vector2 healthyRange = new Vector2(24f, 30f);

        [Header("Warning Battery")]
        [SerializeField] private Vector2 warningStart = new Vector2(36f, 42f);

        [Header("Critical Battery")]
        [SerializeField] private Vector2 criticalStart = new Vector2(45f, 50f);

        private void Start()
        {
            Generate();
        }

        public void Generate()
        {
            SelectScenario();

            GenerateHealthyCells();

            GenerateFaultyCells();

            Debug.Log($"Temperature generation completed. Scenario : {scenario}");

            // ===== EN ÖNEMLİ KISIM =====
            SimulationManager simulation = FindFirstObjectByType<SimulationManager>();

            if (simulation != null)
            {
                simulation.SetDay(1);
            }
            else
            {
                foreach (BatteryCell cell in batteryManager.Cells)
                {
                    cell.SetCurrentDay(1);
                }

                FindFirstObjectByType<ThermalDisplay>()?.RefreshThermal();
            }
        }

        private void SelectScenario()
        {
            if (scenario == BatteryScenario.AutoRandom)
            {
                scenario = (BatteryScenario)Random.Range(1, 4);
            }
        }

        private void GenerateHealthyCells()
        {
            foreach (BatteryCell cell in batteryManager.Cells)
            {
                cell.IsFaulty = false;

                float baseTemp = Random.Range(healthyRange.x, healthyRange.y);

                cell.Day1Temperature = Round(baseTemp);
                cell.Day2Temperature = Round(baseTemp + Random.Range(-0.4f, 0.4f));
                cell.Day3Temperature = Round(baseTemp + Random.Range(-0.4f, 0.4f));

                cell.SetCurrentDay(1);
            }
        }

        private void GenerateFaultyCells()
        {
            int faultyCount = scenario switch
            {
                BatteryScenario.HealthyBattery => 0,
                BatteryScenario.WarningBattery => Random.Range(1, 3),
                BatteryScenario.CriticalBattery => Random.Range(3, 6),
                _ => 0
            };

            List<int> selectedIndexes = new();

            while (selectedIndexes.Count < faultyCount)
            {
                int index = Random.Range(0, batteryManager.Cells.Count);

                if (selectedIndexes.Contains(index))
                    continue;

                selectedIndexes.Add(index);

                BatteryCell cell = batteryManager.Cells[index];

                cell.IsFaulty = true;

                if (scenario == BatteryScenario.WarningBattery)
                {
                    float start = Random.Range(warningStart.x, warningStart.y);

                    cell.Day1Temperature = Round(start);
                    cell.Day2Temperature = Round(start + Random.Range(5f, 8f));
                    cell.Day3Temperature = Round(cell.Day2Temperature + Random.Range(4f, 7f));
                }
                else if (scenario == BatteryScenario.CriticalBattery)
                {
                    float start = Random.Range(criticalStart.x, criticalStart.y);

                    cell.Day1Temperature = Round(start);
                    cell.Day2Temperature = Round(start + Random.Range(8f, 12f));
                    cell.Day3Temperature = Round(cell.Day2Temperature + Random.Range(8f, 12f));
                }

                cell.SetCurrentDay(1);
            }
        }

        private float Round(float value)
        {
            return Mathf.Round(value * 10f) / 10f;
        }
    }
}