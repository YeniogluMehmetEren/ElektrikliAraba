using UnityEngine;
using BatterySystem.Utils;

namespace BatterySystem.Data
{
    public class BatteryCell : MonoBehaviour
    {
        [Header("Cell Info")]
        [SerializeField] private int cellID;

        [Header("Scenario")]
        [SerializeField] private bool isFaulty;

        [Header("Temperatures")]
        [SerializeField] private float day1Temperature;
        [SerializeField] private float day2Temperature;
        [SerializeField] private float day3Temperature;

        [Header("Runtime")]
        [SerializeField] private float currentTemperature;
        [SerializeField] private CellStatus currentStatus;

        public int CellID
        {
            get => cellID;
            set => cellID = value;
        }

        public bool IsFaulty
        {
            get => isFaulty;
            set => isFaulty = value;
        }

        public float Day1Temperature
        {
            get => day1Temperature;
            set => day1Temperature = value;
        }

        public float Day2Temperature
        {
            get => day2Temperature;
            set => day2Temperature = value;
        }

        public float Day3Temperature
        {
            get => day3Temperature;
            set => day3Temperature = value;
        }

        public float CurrentTemperature
        {
            get => currentTemperature;
            private set => currentTemperature = value;
        }

        public CellStatus CurrentStatus
        {
            get => currentStatus;
            private set => currentStatus = value;
        }

        public float GetTemperature(int day)
        {
            return day switch
            {
                1 => Day1Temperature,
                2 => Day2Temperature,
                3 => Day3Temperature,
                _ => Day1Temperature
            };
        }

        public void SetCurrentDay(int day)
        {
            CurrentTemperature = GetTemperature(day);
            CurrentStatus = StatusCalculator.Calculate(CurrentTemperature);
        }

        public void SetTemperature(int day, float temperature)
        {
            switch (day)
            {
                case 1:
                    Day1Temperature = temperature;
                    break;

                case 2:
                    Day2Temperature = temperature;
                    break;

                case 3:
                    Day3Temperature = temperature;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Cell {CellID} | {CurrentTemperature:0.0}°C | {CurrentStatus}";
        }
    }
}