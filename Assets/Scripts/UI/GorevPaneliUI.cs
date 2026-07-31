using System.Collections;
using UnityEngine;

public class GorevPaneliUI : MonoBehaviour
{
    public GameObject gorevSatiriPrefab;
    public Transform panel;

    private ChestTrigger chestTrigger;
    private GloveWear gloveTrigger;
    private FeetTrigger feetTrigger;
    private LiftMovement liftMovement;
    void Start()
    {
        chestTrigger = FindAnyObjectByType<ChestTrigger>();
        gloveTrigger = FindAnyObjectByType<GloveWear>();
        feetTrigger = FindAnyObjectByType<FeetTrigger>();

        liftMovement = FindAnyObjectByType<LiftMovement>();


        StartCoroutine(SetGorevGiysiGiy());

        /*SetGorevGiysiGiy();
        SetGorevAracýYukarýKaldýr();
        SetGorevVidalariCýkart();
        SetGorevKucukLiftiGetirBataryaIndir();
        SetGorevSýcaklýkKontolEtVerileriGir();*/
    }

    IEnumerator SetGorevGiysiGiy()
    {
        GameObject yeniPrefebOnluk = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduOnluk = yeniPrefebOnluk.GetComponent<GorevSatiriRowUI>();
        satirKoduOnluk.gorevYazisi.text = "Önlük Giy.";
        satirKoduOnluk.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebEldiven = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduEldiven = yeniPrefebEldiven.GetComponent<GorevSatiriRowUI>();
        satirKoduEldiven.gorevYazisi.text = "Eldivenleri Giy.";
        satirKoduEldiven.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebAyakkabi = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduAyakkabi = yeniPrefebAyakkabi.GetComponent<GorevSatiriRowUI>();
        satirKoduAyakkabi.gorevYazisi.text = "Ayakkabýlarý Giy.";
        satirKoduAyakkabi.toggleTamamlandiMi.isOn = false;

        while (!chestTrigger.giysiGiyildiMi || !gloveTrigger.eldivenGiyildiMi || !feetTrigger.ayakkabiGiyildiMi)
        {
            if (chestTrigger.giysiGiyildiMi)
            {
                satirKoduOnluk.toggleTamamlandiMi.isOn = true;
            }

            if (gloveTrigger.eldivenGiyildiMi)
            {
                satirKoduEldiven.toggleTamamlandiMi.isOn = true;
            }

            if (feetTrigger.ayakkabiGiyildiMi)
            {
                satirKoduAyakkabi.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduOnluk.toggleTamamlandiMi.isOn = true;
        satirKoduEldiven.toggleTamamlandiMi.isOn = true;
        satirKoduAyakkabi.toggleTamamlandiMi.isOn = true;

        yeniPrefebOnluk.SetActive(false);
        yeniPrefebAyakkabi.SetActive(false);
        yeniPrefebEldiven.SetActive(false);

        StartCoroutine(SetGorevAracýYukarýKaldýr());
    }

    IEnumerator SetGorevAracýYukarýKaldýr()
    {
        GameObject yeniPrefebAracKaldýrma = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduAracKaldýrma = yeniPrefebAracKaldýrma.GetComponent<GorevSatiriRowUI>();
        satirKoduAracKaldýrma.gorevYazisi.text = "Aracý tuþlarý kullanarak yukarý kaldýr.";
        satirKoduAracKaldýrma.toggleTamamlandiMi.isOn = false;

        while (!liftMovement.liftEnYukardaMi)
        {
            if (liftMovement.liftEnYukardaMi)
            {
                satirKoduAracKaldýrma.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduAracKaldýrma.toggleTamamlandiMi.isOn = true;

        yeniPrefebAracKaldýrma.SetActive(false);
    }
}
