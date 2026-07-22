using UnityEngine;
using TMPro;

public class ManualVeriGirisiUI : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject numpadPanel;

    [Header("Arayüz (UI)")]
    public TextMeshProUGUI girilenSicaklikText;

    private string sicaklikGirdisi = "";

    public void NumpadTusaBas(string tusDegeri)
    {
        if (sicaklikGirdisi.Length < 5)
        {
            sicaklikGirdisi += tusDegeri;
            girilenSicaklikText.text = sicaklikGirdisi;
        }
    }

    public void NumpadSil()
    {
        if (sicaklikGirdisi.Length > 0)
        {
            sicaklikGirdisi = sicaklikGirdisi.Substring(0, sicaklikGirdisi.Length - 1);
            girilenSicaklikText.text = sicaklikGirdisi;
        }
    }

    public string GirilenSýcaklýðýSatýraYolla()
    {
        return girilenSicaklikText.text;
    }

    public void NumpadPaneliniAcKapa()
    {
        if (numpadPanel.activeInHierarchy)
        {
            numpadPanel.SetActive(false);
        }
        else
        {
            numpadPanel.SetActive(true);

            sicaklikGirdisi = "";
            girilenSicaklikText.text = "";
        }
    }

    public bool NumpadPaneliAcikMi()
    {
        bool acýkMi;
        if (numpadPanel.activeInHierarchy)
        {
            acýkMi = true;
        }
        else
        {
            acýkMi = false;
        }
        return acýkMi;
    }
}