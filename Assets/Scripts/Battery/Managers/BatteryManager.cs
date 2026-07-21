using System.Collections.Generic;
using UnityEngine;
using BatterySystem.Data;

namespace BatterySystem.Managers
{
    public class BatteryManager : MonoBehaviour
    {
        [SerializeField]
        private List<BatteryCell> cells = new();

        public IReadOnlyList<BatteryCell> Cells => cells;

        private void Awake()
        {
            Debug.Log("===== BatteryManager Awake =====");

            RefreshCells();
        }

        [ContextMenu("Refresh Cells")]
        public void RefreshCells()
        {
            cells.Clear();

            BatteryCell[] found = GetComponentsInChildren<BatteryCell>(true);

            Debug.Log($"Bulunan BatteryCell Sayısı : {found.Length}");

            foreach (BatteryCell cell in found)
            {
                Debug.Log($"Bulundu -> {cell.gameObject.name}");

                cells.Add(cell);
            }

            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].CellID = i + 1;
            }

            Debug.Log($"BatteryManager -> {cells.Count} Cell bulundu.");
        }
    }
}