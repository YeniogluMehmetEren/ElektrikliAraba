using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

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
    private PanelSonucUI panelSonucUI;
    private LiftYuvasi liftYuvasý;

    [SerializeField] private EgitimSesYoneticisi egitim_ses_yoneticisi;

    [SerializeField] private NesneGorevVurgulama onluk;
    [SerializeField] private NesneGorevVurgulama eldiven;
    [SerializeField] private NesneGorevVurgulama ayakkabi;
    [SerializeField] private NesneGorevVurgulama büyükLiftUpBtn;
    [SerializeField] private NesneGorevVurgulama kucukLift;
    [SerializeField] private GameObject kucukLiftHolder;
    [SerializeField] private NesneGorevVurgulama kucukLiftUpBtn;
    [SerializeField] private NesneGorevVurgulama kucukLiftDownBtn;
    [SerializeField] private NesneGorevVurgulama soketler;
    [SerializeField] private NesneGorevVurgulama matkap;
    [SerializeField] private NesneGorevVurgulama termalKamera;
    [SerializeField] private NesneGorevVurgulama[] vidalar;

    void Start()
    {

        if (SimulasyonModuYoneticisi.SeciliModu == SimulasyonModu.Degerlendirme)
        {
            gameObject.SetActive(false);
            return;
        }

        chestTrigger = FindAnyObjectByType<ChestTrigger>();
        gloveTrigger = FindAnyObjectByType<GloveWear>();
        feetTrigger = FindAnyObjectByType<FeetTrigger>();
        liftMovement = FindAnyObjectByType<LiftMovement>();
        kucukLiftMovement = FindAnyObjectByType<LiftAnimationController>();
        liftYuvasý = FindAnyObjectByType<LiftYuvasi>();
        kucukLiftTemas = FindAnyObjectByType<LiftTemasKontrol>();
        soketTakmaCýkartma = FindAnyObjectByType<SoketTakmaCýkartma>();
        boltRemover = FindAnyObjectByType<BoltRemover>();
        fLIRController = FindAnyObjectByType<FLIRController>();
        uiBataryaVeriGirisi = FindAnyObjectByType<UIBataryaVeriGirisi>();
        panelSonucUI = FindAnyObjectByType<PanelSonucUI>(FindObjectsInactive.Include);

        kucukLiftHolder.SetActive(false);

        StartCoroutine(SetGorevGiysiGiy());

        //StartCoroutine(SetGorevSicaklikKontolEtVerileriGir());

        /* GÖREV SIRASI
        SetGorevGiysiGiy();
        SetGorevAracýYukarýKaldýr();
        SetGorevKucukLiftiGetirYukarýKaldýr();
        SetGorevSoketleriVeVidalariCikartBataryayiIndir();
        SetGorevSicaklikKontolEtVerileriGir();
        */
    }

    IEnumerator SetGorevGiysiGiy()
    {
        egitim_ses_yoneticisi.KoruyucuEkipmanGiyme();
        yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());

        baslikText.text = "Equip Protective Gear";
        GameObject yeniPrefebOnluk = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduOnluk = yeniPrefebOnluk.GetComponent<GorevSatiriRowUI>();
        satirKoduOnluk.gorevYazisi.text = "Equip Apron";
        satirKoduOnluk.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebEldiven = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduEldiven = yeniPrefebEldiven.GetComponent<GorevSatiriRowUI>();
        satirKoduEldiven.gorevYazisi.text = "Equip Gloves";
        satirKoduEldiven.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebAyakkabi = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduAyakkabi = yeniPrefebAyakkabi.GetComponent<GorevSatiriRowUI>();
        satirKoduAyakkabi.gorevYazisi.text = "Equip Safety Shoes";
        satirKoduAyakkabi.toggleTamamlandiMi.isOn = false;
        
        onluk.GorevBasladi();
        eldiven.GorevBasladi();
        ayakkabi.GorevBasladi();
        while (!chestTrigger.giysiGiyildiMi || !gloveTrigger.eldivenGiyildiMi || !feetTrigger.ayakkabiGiyildiMi)
        {
            if (chestTrigger.giysiGiyildiMi)
            {
                satirKoduOnluk.toggleTamamlandiMi.isOn = true;
                onluk.GorevBitti();
            }
            if (gloveTrigger.eldivenGiyildiMi)
            {
                satirKoduEldiven.toggleTamamlandiMi.isOn = true;
                eldiven.GorevBitti();
            }
            if (feetTrigger.ayakkabiGiyildiMi)
            {
                satirKoduAyakkabi.toggleTamamlandiMi.isOn = true;
                ayakkabi.GorevBitti();
            }
            yield return null;
        }
        satirKoduOnluk.toggleTamamlandiMi.isOn = true;
        satirKoduEldiven.toggleTamamlandiMi.isOn = true;
        satirKoduAyakkabi.toggleTamamlandiMi.isOn = true;
        ayakkabi.GorevBitti();
        eldiven.GorevBitti();
        onluk.GorevBitti();
        
        yeniPrefebOnluk.SetActive(false);
        yeniPrefebAyakkabi.SetActive(false);
        yeniPrefebEldiven.SetActive(false);

        StartCoroutine(SetGorevAracýYukarýKaldýr());
    }

    IEnumerator SetGorevAracýYukarýKaldýr()
    {
        egitim_ses_yoneticisi.AraciYukariKaldir();
        yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());

        baslikText.text = "Raise Vehicle";
        GameObject yeniPrefebAracKaldýrma = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduAracKaldýrma = yeniPrefebAracKaldýrma.GetComponent<GorevSatiriRowUI>();
        satirKoduAracKaldýrma.gorevYazisi.text = "Raise the vehicle using the buttons";
        satirKoduAracKaldýrma.toggleTamamlandiMi.isOn = false;

        büyükLiftUpBtn.GorevBasladi();
        while (!liftMovement.liftEnYukardaMi)
        {
            if (liftMovement.liftEnYukardaMi)
            {
                satirKoduAracKaldýrma.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduAracKaldýrma.toggleTamamlandiMi.isOn = true;
        büyükLiftUpBtn.GorevBitti();

        yeniPrefebAracKaldýrma.SetActive(false);

        StartCoroutine(SetGorevKucukLiftiGetirYukarýKaldýr());
    }

    IEnumerator SetGorevKucukLiftiGetirYukarýKaldýr()
    {

        egitim_ses_yoneticisi.LiftiBataryaninAltinaGetir();
        yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());

        baslikText.text = "Setup Lift";
        GameObject yeniPrefebLiftiGetir = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduLiftiGetir = yeniPrefebLiftiGetir.GetComponent<GorevSatiriRowUI>();
        satirKoduLiftiGetir.gorevYazisi.text = "Position the lift under the battery";
        satirKoduLiftiGetir.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebLiftiKaldir = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduLiftiKaldir = yeniPrefebLiftiKaldir.GetComponent<GorevSatiriRowUI>();
        satirKoduLiftiKaldir.gorevYazisi.text = "Raise the lift";
        satirKoduLiftiKaldir.toggleTamamlandiMi.isOn = false;

        kucukLift.GorevBasladi();
        kucukLiftHolder.SetActive(true);
        while (!liftYuvasý.liftAlandaMi)
        {
            if (liftYuvasý.liftAlandaMi)
            {
                satirKoduLiftiGetir.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduLiftiGetir.toggleTamamlandiMi.isOn = true;
        kucukLift.GorevBitti();

        egitim_ses_yoneticisi.LiftiYukariKaldir();
        yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());

        kucukLiftUpBtn.GorevBasladi();
        while (!kucukLiftTemas.Bataryaya_temas_ediyormu) 
        {
            if (kucukLiftTemas.Bataryaya_temas_ediyormu)
            {
                satirKoduLiftiKaldir.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        kucukLiftUpBtn.GorevBitti();
        satirKoduLiftiKaldir.toggleTamamlandiMi.isOn = true;

        yeniPrefebLiftiGetir.SetActive(false);
        yeniPrefebLiftiKaldir.SetActive(false);

        StartCoroutine(SetGorevSoketleriVeVidalariCikartBataryayiIndir());
    }

    IEnumerator SetGorevSoketleriVeVidalariCikartBataryayiIndir()
    {
        egitim_ses_yoneticisi.SoketleriCikar();
        yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());


        baslikText.text = "Detach and Lower Battery";
        GameObject yeniPrefebSoketleriCikart = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduSoketleriCikart = yeniPrefebSoketleriCikart.GetComponent<GorevSatiriRowUI>();
        satirKoduSoketleriCikart.gorevYazisi.text = "Disconnect the connectors at the front of the battery";
        satirKoduSoketleriCikart.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebMatkapiAl = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduMatkapiAl = yeniPrefebMatkapiAl.GetComponent<GorevSatiriRowUI>();
        satirKoduMatkapiAl.gorevYazisi.text = "Grab the drill";
        satirKoduMatkapiAl.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebVidalariCikart = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduVidalariCikart = yeniPrefebVidalariCikart.GetComponent<GorevSatiriRowUI>();
        satirKoduVidalariCikart.gorevYazisi.text = "Remove the screws around the battery  0/13";
        satirKoduVidalariCikart.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebBataryayiIndir = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduBataryayiIndir = yeniPrefebBataryayiIndir.GetComponent<GorevSatiriRowUI>();
        satirKoduBataryayiIndir.gorevYazisi.text = "Lower the lift to bring the battery down";
        satirKoduBataryayiIndir.toggleTamamlandiMi.isOn = false;

        soketler.GorevBasladi();

        bool matkapBaslatildi = false;
        bool vidalarBaslatildi = false;

        while (!soketTakmaCýkartma.TumSoketlerSokulduMu || !boltRemover.matkapTutulduMu || !boltRemover.VidalarinHepsiSokulduMu())
        {
            if (!matkapBaslatildi && soketTakmaCýkartma.TumSoketlerSokulduMu)
            {
                matkapBaslatildi = true;

                satirKoduSoketleriCikart.toggleTamamlandiMi.isOn = true;
                soketler.GorevBitti();

                egitim_ses_yoneticisi.MatkabiAl();
                yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());
                matkap.GorevBasladi();
            }
            if (!vidalarBaslatildi && boltRemover.matkapTutulduMu)
            {

                vidalarBaslatildi = true;

                egitim_ses_yoneticisi.VidalariSok();
                yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());


                foreach (NesneGorevVurgulama vida in vidalar)
                {
                    vida.GorevBasladi();
                }

                satirKoduMatkapiAl.toggleTamamlandiMi.isOn = true;
                matkap.GorevBitti();
            }
            satirKoduVidalariCikart.gorevYazisi.text = "Remove the screws around the battery  " + boltRemover.GetKacVidaSokuldu() + "/13";
            if (boltRemover.VidalarinHepsiSokulduMu())
            {
                satirKoduVidalariCikart.toggleTamamlandiMi.isOn = true;
                foreach (NesneGorevVurgulama vida in vidalar)
                {
                    vida.GorevBitti();
                }
            }
            yield return null;
        }
        soketler.GorevBitti(); matkap.GorevBitti();
        foreach (NesneGorevVurgulama vida in vidalar)
        {
            vida.GorevBitti();
        }
        satirKoduSoketleriCikart.toggleTamamlandiMi.isOn = true;
        satirKoduMatkapiAl.toggleTamamlandiMi.isOn = true;
        satirKoduVidalariCikart.toggleTamamlandiMi.isOn = true;

        egitim_ses_yoneticisi.BataryayiIndir();
        yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());

        kucukLiftDownBtn.GorevBasladi();
        while (!kucukLiftMovement.BataryaAlýnýpAþaðýyaIndiMi())
        {
            if (kucukLiftMovement.BataryaAlýnýpAþaðýyaIndiMi())
            {
                satirKoduBataryayiIndir.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduBataryayiIndir.toggleTamamlandiMi.isOn = true;
        kucukLiftDownBtn.GorevBitti();

        yeniPrefebSoketleriCikart.SetActive(false);
        yeniPrefebMatkapiAl.SetActive(false);
        yeniPrefebVidalariCikart.SetActive(false);
        yeniPrefebBataryayiIndir.SetActive(false);

        StartCoroutine(SetGorevSicaklikKontolEtVerileriGir());
    }

    IEnumerator SetGorevSicaklikKontolEtVerileriGir()
    {
        egitim_ses_yoneticisi.TermalKamerayiAl();
        yield return new WaitWhile(() => egitim_ses_yoneticisi.SesCaliyorMu());

        baslikText.text = "Record Data";
        GameObject yeniPrefebTermaliAl = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduTermaliAl = yeniPrefebTermaliAl.GetComponent<GorevSatiriRowUI>();
        satirKoduTermaliAl.gorevYazisi.text = "Grab the thermal camera";
        satirKoduTermaliAl.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebGun2Gec = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduGun2Gec = yeniPrefebGun2Gec.GetComponent<GorevSatiriRowUI>();
        satirKoduGun2Gec.gorevYazisi.text = "Record Day 1 data and proceed to Day 2";
        satirKoduGun2Gec.toggleTamamlandiMi.isOn = false;
        GameObject yeniPrefebGun3Gec = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduGun3Gec = yeniPrefebGun3Gec.GetComponent<GorevSatiriRowUI>();
        satirKoduGun3Gec.gorevYazisi.text = "Record Day 2 data and proceed to Day 3";
        satirKoduGun3Gec.toggleTamamlandiMi.isOn = false;

        GameObject yeniPrefebDegerlendirmeyeGec = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduDegerlendirmeyeGec = yeniPrefebDegerlendirmeyeGec.GetComponent<GorevSatiriRowUI>();
        satirKoduDegerlendirmeyeGec.gorevYazisi.text = "Record Day 3 data and proceed to the assessment screen";
        satirKoduDegerlendirmeyeGec.toggleTamamlandiMi.isOn = false;

        GameObject yeniPrefebKararVer = Instantiate(gorevSatiriPrefab, panel);
        GorevSatiriRowUI satirKoduKararVer = yeniPrefebKararVer.GetComponent<GorevSatiriRowUI>();
        satirKoduKararVer.gorevYazisi.text = "Assess cell conditions";
        satirKoduKararVer.toggleTamamlandiMi.isOn = false;

        termalKamera.GorevBasladi(); 



        while (!fLIRController.termalTutulduMu || !uiBataryaVeriGirisi.gun2GecildiMi || !uiBataryaVeriGirisi.gun3GecildiMi || !uiBataryaVeriGirisi.sonucGecildiMi || !panelSonucUI.degerlendirmeBittiMi)
        {
            if (fLIRController.termalTutulduMu)
            {
                satirKoduTermaliAl.toggleTamamlandiMi.isOn = true;
                termalKamera.GorevBitti();
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
                satirKoduDegerlendirmeyeGec.toggleTamamlandiMi.isOn = true;
            }
            if (panelSonucUI.degerlendirmeBittiMi)
            {
                satirKoduKararVer.toggleTamamlandiMi.isOn = true;
            }
            yield return null;
        }
        satirKoduTermaliAl.toggleTamamlandiMi.isOn = true;
        satirKoduGun2Gec.toggleTamamlandiMi.isOn = true;
        satirKoduGun3Gec.toggleTamamlandiMi.isOn = true;
        satirKoduDegerlendirmeyeGec.toggleTamamlandiMi.isOn = true;
        satirKoduKararVer.toggleTamamlandiMi.isOn = true;
        termalKamera.GorevBitti();

        yeniPrefebTermaliAl.SetActive(false);
        yeniPrefebGun2Gec.SetActive(false);
        yeniPrefebGun3Gec.SetActive(false);
        yeniPrefebDegerlendirmeyeGec.SetActive(false);
        yeniPrefebKararVer.SetActive(false);

        baslikText.text = "CONGRATULATIONS!\nTutorial Completed\nDon't forget to check your score on the Results screen!";
    }
}
