using UnityEngine;
using BatterySystem.Data;
using BatterySystem.Thermal;

namespace BatterySystem.Managers
{
    public class SimulationManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private BatteryManager batteryManager;
        [SerializeField] private ThermalDisplay thermalDisplay;

        [Header("Simulation")]
        [SerializeField]
        [Range(1, 3)]
        private int currentDay = 1;

        public int CurrentDay => currentDay;

        private void Start()
        {
            ApplyDay(currentDay);
        }

        public void NextDay()
        {
            if (currentDay >= 3)
            {
                Debug.Log("Simulation already at Day 3.");
                return;
            }

            currentDay++;

            ApplyDay(currentDay);

            Debug.Log($"Day changed -> Day {currentDay}");
        }

        public void PreviousDay()
        {
            if (currentDay <= 1)
            {
                Debug.Log("Simulation already at Day 1.");
                return;
            }

            currentDay--;

            ApplyDay(currentDay);

            Debug.Log($"Day changed -> Day {currentDay}");
        }

        public void SetDay(int day)
        {
            day = Mathf.Clamp(day, 1, 3);

            currentDay = day;

            ApplyDay(currentDay);

            Debug.Log($"Simulation set to Day {currentDay}");
        }

        private void ApplyDay(int day)
        {
            Debug.Log($"================ DAY {day} ================");

            foreach (BatteryCell cell in batteryManager.Cells)
            {
                cell.SetCurrentDay(day);

                Debug.Log(
                    $"Cell {cell.CellID} | " +
                    $"Day1={cell.Day1Temperature} | " +
                    $"Day2={cell.Day2Temperature} | " +
                    $"Day3={cell.Day3Temperature} | " +
                    $"Current={cell.CurrentTemperature} | " +
                    $"Status={cell.CurrentStatus}"
                );
            }

            if (thermalDisplay != null)
            {
                thermalDisplay.RefreshThermal();
            }
        }
    }
}