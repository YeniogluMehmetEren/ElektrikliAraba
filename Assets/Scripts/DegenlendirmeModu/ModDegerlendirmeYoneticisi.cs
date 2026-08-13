using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModDegerlendirmeYoneticisi : MonoBehaviour
{
    [Header("Puan")]
    [SerializeField] private int baslangic_puani = 100;

    [Header("Hücre Değerlendirme")]
    [SerializeField] private int yanlis_hucre_cezasi = 5;

    private int mevcut_puan;

    private List<DegerlendirmeHatasi> hatalar = new List<DegerlendirmeHatasi>();

    private HashSet<DegerlendirmeHataKodu> verilen_hatalar = new HashSet<DegerlendirmeHataKodu>();

    private bool degerlendirme_aktif;

    private int yanlis_hucre_sayisi;
    private int hucre_cezasi;
    private bool hucre_cezasi_uygulandi;

    [Header("Sonuç Paneli")]
    [SerializeField] private TextMeshProUGUI baslangic_puani_text;
    [SerializeField] private TextMeshProUGUI yanlis_hucre_text;
    [SerializeField] private TextMeshProUGUI hucre_cezasi_text;
    [SerializeField] private TextMeshProUGUI puan_sonuc_text;
    [SerializeField] private Transform hatalar_container;
    [SerializeField] private GameObject hata_satiri;

    private PanelSonUI panel_son_uı;

    private ChestTrigger onluk_kontrol;
    private GloveWear eldiven_kontrol;
    private FeetTrigger ayakkabi_kontrol;

    private LiftMovement lift_kontrol;
    private LiftAnimationController kucuk_lift_kontrol;
    private LiftYuvasi lift_yuvasi;
    private LiftTemasKontrol kucuk_lift_temas;

    private SoketTakmaCıkartma soket_takma_cıkartma;
    private BoltRemover civata_kontrol;

    private FLIRController flir_kontrol;
    private UIBataryaVeriGirisi ui_batarya_veri;

    private void Start()
    {
        if (SimulasyonModuYoneticisi.SeciliModu !=
            SimulasyonModu.Degerlendirme)
        {
            return;
        }

        MekanikleriBul();
        Baslat();
    }

    private void MekanikleriBul()
    {
        onluk_kontrol = FindAnyObjectByType<ChestTrigger>();

        eldiven_kontrol = FindAnyObjectByType<GloveWear>();

        ayakkabi_kontrol = FindAnyObjectByType<FeetTrigger>();

        lift_kontrol = FindAnyObjectByType<LiftMovement>();

        kucuk_lift_kontrol = FindAnyObjectByType<LiftAnimationController>();

        lift_yuvasi = FindAnyObjectByType<LiftYuvasi>();

        kucuk_lift_temas = FindAnyObjectByType<LiftTemasKontrol>();

        soket_takma_cıkartma = FindAnyObjectByType<SoketTakmaCıkartma>();

        civata_kontrol = FindAnyObjectByType<BoltRemover>();

        flir_kontrol = FindAnyObjectByType<FLIRController>();

        ui_batarya_veri = FindAnyObjectByType<UIBataryaVeriGirisi>();

        panel_son_uı = FindAnyObjectByType<PanelSonUI>();

    }

    public void Baslat()
    {
        mevcut_puan = baslangic_puani;

        hatalar.Clear();
        verilen_hatalar.Clear();

        yanlis_hucre_sayisi = 0;
        hucre_cezasi = 0;
        hucre_cezasi_uygulandi = false;

        degerlendirme_aktif = true;
    }

    private void Update()
    {
        if (!degerlendirme_aktif)
        {
            return;
        }

        PPEKontrol();
        AracKaldirmaKontrol();
        KucukLiftGetirKontrol();
        KucukLiftKaldirKontrol();
        SoketKontrol();
        MatkapKontrol();
        VidaKontrol();
        BataryaIndirmeKontrol();
    }

    private void PPEKontrol()
    {
        if (!PpeTamamMi())
        {
            return;
        }
    }

    private bool PpeTamamMi()
    {
        if (onluk_kontrol == null ||
            eldiven_kontrol == null ||
            ayakkabi_kontrol == null)
        {
            return false;
        }

        return onluk_kontrol.giysiGiyildiMi &&
               eldiven_kontrol.eldivenGiyildiMi &&
               ayakkabi_kontrol.ayakkabiGiyildiMi;
    }

    private void AracKaldirmaKontrol()
    {
        if (lift_kontrol == null)
        {
            return;
        }

        if (!lift_kontrol.liftEnYukardaMi)
        {
            return;
        }

        if (!PpeTamamMi())
        {
            HataEkle(
                DegerlendirmeHatasi.PPE()
            );
        }
    }

    private void KucukLiftGetirKontrol()
    {
        if (lift_yuvasi == null)
        {
            return;
        }

        if (!lift_yuvasi.liftAlandaMi)
        {
            return;
        }

        if (!PpeTamamMi())
        {
            HataEkle(
                DegerlendirmeHatasi.PPE()
            );
        }

        if (lift_kontrol == null ||
            !lift_kontrol.liftEnYukardaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.AracKaldirma()
            );
        }
    }

    private void KucukLiftKaldirKontrol()
    {
        if (kucuk_lift_temas == null)
        {
            return;
        }

        if (!kucuk_lift_temas.Bataryaya_temas_ediyormu)
        {
            return;
        }

        if (!PpeTamamMi())
        {
            HataEkle(
                DegerlendirmeHatasi.PPE()
            );
        }

        if (lift_kontrol == null ||
            !lift_kontrol.liftEnYukardaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.AracKaldirma()
            );
        }

        if (lift_yuvasi == null ||
            !lift_yuvasi.liftAlandaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftYeri()
            );
        }
    }

    private void SoketKontrol()
    {
        if (soket_takma_cıkartma == null)
        {
            return;
        }

        if (!soket_takma_cıkartma.TumSoketlerSokulduMu)
        {
            return;
        }

        if (!PpeTamamMi())
        {
            HataEkle(
                DegerlendirmeHatasi.PPE()
            );
        }

        if (lift_kontrol == null ||
            !lift_kontrol.liftEnYukardaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.AracKaldirma()
            );
        }

        if (lift_yuvasi == null ||
            !lift_yuvasi.liftAlandaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftYeri()
            );
        }

        if (kucuk_lift_temas == null ||
            !kucuk_lift_temas.Bataryaya_temas_ediyormu)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftTemas()
            );
        }
    }

    private void MatkapKontrol()
    {
        if (civata_kontrol == null)
        {
            return;
        }

        if (!civata_kontrol.matkapTutulduMu)
        {
            return;
        }

        if (!PpeTamamMi())
        {
            HataEkle(
                DegerlendirmeHatasi.PPE()
            );
        }

        if (lift_kontrol == null ||
            !lift_kontrol.liftEnYukardaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.AracKaldirma()
            );
        }

        if (lift_yuvasi == null ||
            !lift_yuvasi.liftAlandaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftYeri()
            );
        }

        if (kucuk_lift_temas == null ||
            !kucuk_lift_temas.Bataryaya_temas_ediyormu)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftTemas()
            );
        }

        if (soket_takma_cıkartma == null ||
            !soket_takma_cıkartma.TumSoketlerSokulduMu)
        {
            HataEkle(
                DegerlendirmeHatasi.Soket()
            );
        }
    }

    private void VidaKontrol()
    {
        if (civata_kontrol == null)
        {
            return;
        }

        if (!civata_kontrol.VidalarinHepsiSokulduMu())
        {
            return;
        }

        if (!PpeTamamMi())
        {
            HataEkle(
                DegerlendirmeHatasi.PPE()
            );
        }

        if (lift_kontrol == null ||
            !lift_kontrol.liftEnYukardaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.AracKaldirma()
            );
        }

        if (lift_yuvasi == null ||
            !lift_yuvasi.liftAlandaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftYeri()
            );
        }

        if (kucuk_lift_temas == null ||
            !kucuk_lift_temas.Bataryaya_temas_ediyormu)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftTemas()
            );
        }

        if (soket_takma_cıkartma == null ||
            !soket_takma_cıkartma.TumSoketlerSokulduMu)
        {
            HataEkle(
                DegerlendirmeHatasi.Soket()
            );
        }

        if (!civata_kontrol.matkapTutulduMu)
        {
            HataEkle(
                DegerlendirmeHatasi.Matkap()
            );
        }
    }

    private void BataryaIndirmeKontrol()
    {
        if (kucuk_lift_kontrol == null)
        {
            return;
        }

        if (!kucuk_lift_kontrol.BataryaAlınıpAşağıyaIndiMi())
        {
            return;
        }

        if (!PpeTamamMi())
        {
            HataEkle(
                DegerlendirmeHatasi.PPE()
            );
        }

        if (lift_kontrol == null ||
            !lift_kontrol.liftEnYukardaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.AracKaldirma()
            );
        }

        if (lift_yuvasi == null ||
            !lift_yuvasi.liftAlandaMi)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftYeri()
            );
        }

        if (kucuk_lift_temas == null ||
            !kucuk_lift_temas.Bataryaya_temas_ediyormu)
        {
            HataEkle(
                DegerlendirmeHatasi.KucukLiftTemas()
            );
        }

        if (soket_takma_cıkartma == null ||
            !soket_takma_cıkartma.TumSoketlerSokulduMu)
        {
            HataEkle(
                DegerlendirmeHatasi.Soket()
            );
        }

        if (!civata_kontrol.matkapTutulduMu)
        {
            HataEkle(
                DegerlendirmeHatasi.Matkap()
            );
        }

        if (!civata_kontrol.VidalarinHepsiSokulduMu())
        {
            HataEkle(
                DegerlendirmeHatasi.Vida()
            );
        }
    }

    public void HataEkle(DegerlendirmeHatasi hata)
    {
        if (!degerlendirme_aktif)
        {
            return;
        }

        if (hata == null)
        {
            return;
        }

        if (!verilen_hatalar.Add(hata.kod))
        {
            return;
        }

        hatalar.Add(hata);

        mevcut_puan -= hata.ceza;

        if (mevcut_puan < 0)
        {
            mevcut_puan = 0;
        }
    }

    public void HucreCezasiniUygula(int yanlisSayisi)
    {
        if (hucre_cezasi_uygulandi)
        {
            return;
        }

        yanlisSayisi = Mathf.Clamp(
            yanlisSayisi,
            0,
            12
        );

        yanlis_hucre_sayisi = yanlisSayisi;

        hucre_cezasi =
            yanlis_hucre_sayisi *
            yanlis_hucre_cezasi;

        mevcut_puan -= hucre_cezasi;

        if (mevcut_puan < 0)
        {
            mevcut_puan = 0;
        }

        hucre_cezasi_uygulandi = true;
    }

    private bool PanelSonUIYanlisSayisiniAl()
    {
        if (panel_son_uı == null)
        {
            panel_son_uı =
                FindAnyObjectByType<PanelSonUI>();
        }

        if (panel_son_uı == null)
        {
            return false;
        }

        HucreCezasiniUygula(
            panel_son_uı.YanlisHucreSayisi
        );

        return true;
    }
    public void SonucPaneliniGuncelle()
    {
        if (!PanelSonUIYanlisSayisiniAl())
        {
            return;
        }

        if (baslangic_puani_text != null)
        {
            baslangic_puani_text.text =
                "Başlangıç Puanı: " +
                baslangic_puani;
        }

        if (yanlis_hucre_text != null)
        {
            yanlis_hucre_text.text =
                "Yanlış değerlendirilen: " +
                yanlis_hucre_sayisi;
        }

        if (hucre_cezasi_text != null)
        {
            hucre_cezasi_text.text =
                "Hücre cezası: " +
                yanlis_hucre_sayisi +
                " × -" +
                yanlis_hucre_cezasi +
                " = -" +
                hucre_cezasi;
        }

        if (puan_sonuc_text != null)
        {
            puan_sonuc_text.text =
                "Puanınız: " +
                mevcut_puan+"/100";
        }

        HatalariEkranaYaz();
    }
    private void HatalariEkranaYaz()
    {
        if (hatalar_container == null ||
            hata_satiri == null)
        {
            return;
        }

        foreach (DegerlendirmeHatasi hata in hatalar)
        {
            GameObject yeni_satir =
                Instantiate(
                    hata_satiri,
                    hatalar_container
                );

            yeni_satir.SetActive(true);

            Transform aciklama =
                yeni_satir.transform.Find(
                    "HataAciklamaText"
                );

            if (aciklama != null)
            {
                TextMeshProUGUI text =
                    aciklama.GetComponent<TextMeshProUGUI>();

                if (text != null)
                {
                    text.text =
                        "• " + hata.aciklama;
                }
            }

            Transform ceza =
                yeni_satir.transform.Find(
                    "HataCezaText"
                );

            if (ceza != null)
            {
                TextMeshProUGUI text =
                    ceza.GetComponent<TextMeshProUGUI>();

                if (text != null)
                {
                    text.text =
                        "-" + hata.ceza;
                }
            }
        }

        hata_satiri.SetActive(false);
    }
}