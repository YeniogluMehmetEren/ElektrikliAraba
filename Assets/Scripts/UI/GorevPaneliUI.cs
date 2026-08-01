using System.Collections;
using TMPro;
using UnityEngine;

public class GorevPaneliUI : MonoBehaviour
{
    public GameObject gorevSatiriPrefab;
    public Transform panel;
    public TextMeshProUGUI baslikText;

    private ChestTrigger chestTrigger;
    private GloveWear gloveTrigger;
    private FeetTrigger feetTrigger;
    private LiftMovement liftMovement;
    private LiftTemasKontrol kucukLiftTemas;
    private SoketTakmaCýkartma soketTakmaCýkartma;
    private BoltRemover boltRemover;
    private LiftAnimationController kucukLiftMovement;
    private FLIRController fLIRController;
    private UIBataryaVeriGirisi uiBataryaVeriGirisi;

    [SerializeField] private NesneGorevVurgulama onluk;
    [SerializeField] private NesneGorevVurgulama eldiven;
    [SerializeField] private NesneGorevVurgulama ayakkabi;
    void Start()
    {
        chestTrigger = FindAnyObjectByType<ChestTrigger>();
        gloveTrigger = FindAnyObjectByType<GloveWear>();
        feetTrigger = FindAnyObjectByType<FeetTrigger>();

        liftMovement = FindAnyObjectByType<LiftMovement>();

        kucukLiftTemas = FindAnyObjectByType<LiftTemasKontrol>();

        soketTakmaCýkartma = FindAnyObjectByType<SoketTakmaCýkartma>();
        boltRemover = FindAnyObjectByType<BoltRemover>();

        fLIRController = FindAnyObjectByType<FLIRController>();
        uiBataryaVeriGirisi = FindAnyObjectByType<UIBataryaVeriGirisi>();


        StartCoroutine(SetGorevGiysiGiy());
        
        //StartCoroutine(SetGorevSoketleriVeVidalariCikartBataryayiIndir());
        /*
        SetGorevGiysiGiy();
        SetGorevAracýYukarýKaldýr();
        SetGorevKucukLiftiGetirYukarýKaldýr();
        SetGorevSoketleriVeVidalariCýkartBataryayýIndir();
        SetGorevSýcaklýkKontolEtVerileriGir();
        */
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

        onluk.GorevBasladi();

        while (!chestTrigger.giysiGiyildiMi)
        {
            yield return null;
        }

        satirKoduOnluk.toggleTamamlandiMi.isOn = true;
        onluk.GorevBitti();

        eldiven.GorevBasladi();

        while (!gloveTrigger.eldivenGiyildiMi)
        {
            yield return null;
        }

        satirKoduEldiven.toggleTamamlandiMi.isOn = true;
        eldiven.GorevBitti();

        ayakkabi.GorevBasladi();

      
        while (!feetTrigger.ayakkabiGiyildiMi)
        {
            yield return null;
        }

        satirKoduAyakkabi.toggleTamamlandiMi.isOn = true;
        ayakkabi.GorevBitti();

        yeniPrefebOnluk.SetActive(false);
        yeniPrefebAyakkabi.SetActive(false);
        yeniPrefebEldiven.SetActive(false);

        StartCoroutine(SetGorevAracýYukarýKaldýr());
    }

    IEnumerator SetGorevAracýYukarýKaldýr()
    {
        GameObject yeniPrefebAracKaldýrma = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduAracKaldýrma = yeniPrefebAracKaldýrma.GetComponent<GorevSatiriRowUI>();
        satirKoduAracKaldýrma.gorevYazisi.text = "Aracý, tuþlarý kullanarak yukarý kaldýr.";
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

        StartCoroutine(SetGorevKucukLiftiGetirYukarýKaldýr());
    }

    IEnumerator SetGorevKucukLiftiGetirYukarýKaldýr()
    {
        GameObject yeniPrefebLiftiGetir = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduLiftiGetir = yeniPrefebLiftiGetir.GetComponent<GorevSatiriRowUI>();
        satirKoduLiftiGetir.gorevYazisi.text = "Lifti bataryanýn altýna getir.";
        satirKoduLiftiGetir.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebLiftiKaldir = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduLiftiKaldir = yeniPrefebLiftiKaldir.GetComponent<GorevSatiriRowUI>();
        satirKoduLiftiKaldir.gorevYazisi.text = "Lifti yukarý kaldýr.";
        satirKoduLiftiKaldir.toggleTamamlandiMi.isOn = false;

        while (!kucukLiftTemas.Bataryaya_temas_ediyormu) // yeniPrefebLiftiGetir þuanlýk yok çünkü altýna getirildiðini algýlayan kod yok. eklenecek
        {
            if (kucukLiftTemas.Bataryaya_temas_ediyormu)
            {
                satirKoduLiftiKaldir.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduLiftiGetir.toggleTamamlandiMi.isOn = true;
        satirKoduLiftiKaldir.toggleTamamlandiMi.isOn = true;

        yeniPrefebLiftiGetir.SetActive(false);
        yeniPrefebLiftiKaldir.SetActive(false);

        StartCoroutine(SetGorevSoketleriVeVidalariCikartBataryayiIndir());
    }

    IEnumerator SetGorevSoketleriVeVidalariCikartBataryayiIndir()
    {
        GameObject yeniPrefebSoketleriCikart = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduSoketleriCikart = yeniPrefebSoketleriCikart.GetComponent<GorevSatiriRowUI>();
        satirKoduSoketleriCikart.gorevYazisi.text = "Bataryanýn önünde bulunan soketleri çýkart.";
        satirKoduSoketleriCikart.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebMatkapiAl = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduMatkapiAl = yeniPrefebMatkapiAl.GetComponent<GorevSatiriRowUI>();
        satirKoduMatkapiAl.gorevYazisi.text = "Matkapý eline al.";
        satirKoduMatkapiAl.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebVidalariCikart = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduVidalariCikart = yeniPrefebVidalariCikart.GetComponent<GorevSatiriRowUI>();
        satirKoduVidalariCikart.gorevYazisi.text = "Bataryanýn etrafýnda bulunan vidalarý sök.  0/13";
        satirKoduVidalariCikart.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebBataryayiIndir = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduBataryayiIndir = yeniPrefebBataryayiIndir.GetComponent<GorevSatiriRowUI>();
        satirKoduBataryayiIndir.gorevYazisi.text = "Lifti indirerek bataryayý aþaðýya indir.";
        satirKoduBataryayiIndir.toggleTamamlandiMi.isOn = false;

        while (!soketTakmaCýkartma.TumSoketlerSokulduMu || !boltRemover.matkapTutulduMu || !boltRemover.VidalarinHepsiSokulduMu())
        {
            if (soketTakmaCýkartma.TumSoketlerSokulduMu)
            {
                satirKoduSoketleriCikart.toggleTamamlandiMi.isOn = true;
            }
            if (boltRemover.matkapTutulduMu)
            {
                satirKoduMatkapiAl.toggleTamamlandiMi.isOn = true;
            }
            satirKoduVidalariCikart.gorevYazisi.text = "Bataryanýn etrafýnda bulunan vidalarý sök.  " + boltRemover.GetKacVidaSokuldu() + "/13";
            if (boltRemover.VidalarinHepsiSokulduMu())
            {
                satirKoduVidalariCikart.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }

        while (!kucukLiftMovement.BataryaAlýnýpAþaðýyaIndiMi())
        {
            if (kucukLiftMovement.BataryaAlýnýpAþaðýyaIndiMi())
            {
                satirKoduBataryayiIndir.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduSoketleriCikart.toggleTamamlandiMi.isOn = true;
        satirKoduMatkapiAl.toggleTamamlandiMi.isOn = true;
        satirKoduVidalariCikart.toggleTamamlandiMi.isOn = true;
        satirKoduBataryayiIndir.toggleTamamlandiMi.isOn = true;

        yeniPrefebSoketleriCikart.SetActive(false);
        yeniPrefebMatkapiAl.SetActive(false);
        yeniPrefebVidalariCikart.SetActive(false);
        yeniPrefebBataryayiIndir.SetActive(false);

        StartCoroutine(SetGorevSicaklikKontolEtVerileriGir());
    }

    IEnumerator SetGorevSicaklikKontolEtVerileriGir()
    {
        GameObject yeniPrefebTermaliAl = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduTermaliAl = yeniPrefebTermaliAl.GetComponent<GorevSatiriRowUI>();
        satirKoduTermaliAl.gorevYazisi.text = "Termal kamerayý eline al.";
        satirKoduTermaliAl.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebGun2Gec = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduGun2Gec = yeniPrefebGun2Gec.GetComponent<GorevSatiriRowUI>();
        satirKoduGun2Gec.gorevYazisi.text = "Gün 1'in verilerini kaydet ve Gün 2'ye geç.";
        satirKoduGun2Gec.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebGun3Gec = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduGun3Gec = yeniPrefebGun3Gec.GetComponent<GorevSatiriRowUI>();
        satirKoduGun3Gec.gorevYazisi.text = "Gün 2'nin verilerini kaydet ve Gün 3'e geç.";
        satirKoduGun3Gec.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebSonucaGec = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduSonucaGec = yeniPrefebSonucaGec.GetComponent<GorevSatiriRowUI>();
        satirKoduSonucaGec.gorevYazisi.text = "Gün 3'ün verilerini kaydet ve sonuçlarýný gör.";
        satirKoduSonucaGec.toggleTamamlandiMi.isOn = false;

        while (!fLIRController.termalTutulduMu || !uiBataryaVeriGirisi.gun2GecildiMi || !uiBataryaVeriGirisi.gun3GecildiMi || !uiBataryaVeriGirisi.sonucGecildiMi)
        {
            if (fLIRController.termalTutulduMu)
            {
                satirKoduTermaliAl.toggleTamamlandiMi.isOn = true;
            }
            if (uiBataryaVeriGirisi.gun2GecildiMi)
            {
                satirKoduGun2Gec.toggleTamamlandiMi.isOn = true;
            }
            if (uiBataryaVeriGirisi.gun3GecildiMi)
            {
                satirKoduGun3Gec.toggleTamamlandiMi.isOn = true;
            }
            if (uiBataryaVeriGirisi.sonucGecildiMi)
            {
                satirKoduSonucaGec.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduTermaliAl.toggleTamamlandiMi.isOn = true;
        satirKoduGun2Gec.toggleTamamlandiMi.isOn = true;
        satirKoduGun3Gec.toggleTamamlandiMi.isOn = true;
        satirKoduSonucaGec.toggleTamamlandiMi.isOn = true;

        yeniPrefebTermaliAl.SetActive(false);
        yeniPrefebGun2Gec.SetActive(false);
        yeniPrefebGun3Gec.SetActive(false);
        yeniPrefebSonucaGec.SetActive(false);

        baslikText.text = "TEBRÝKLER!\nEðiticiyi Bitirdin";
    }
}
