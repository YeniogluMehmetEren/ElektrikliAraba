using TMPro;
using UnityEngine;

public class PanelSonUI : MonoBehaviour
{


    [SerializeField] private GameObject degerlendirmeSonucuButton;
    [SerializeField] private GameObject panelDegerlendirmeSonucu;

    public TextMeshProUGUI textNormalKacDogru;
    public TextMeshProUGUI textUyariKacDogru;
    public TextMeshProUGUI textKritikKacDogru;
    public TextMeshProUGUI textKacNormal;
    public TextMeshProUGUI textKacUyari;
    public TextMeshProUGUI textKacKritik;
    public TextMeshProUGUI textYuzdelikOran;
    
    public int NormalKacDogru;
    public int UyariKacDogru;
    public int KritikKacDogru;
    public int KacNormal;
    public int KacUyari;
    public int KacKritik;

    public int YanlisHucreSayisi;

    private BataryaDegiskenleri[] karsilastirilacakHucreler;

    void Start()
    {

        
        BataryaYoneticisi bataryaYoneticisi =
            FindAnyObjectByType<BataryaYoneticisi>();

        karsilastirilacakHucreler = bataryaYoneticisi.hucreler;
        DegerleriBul();
        if (degerlendirmeSonucuButton != null)
        {
            degerlendirmeSonucuButton.SetActive(
                SimulasyonModuYoneticisi.SeciliModu ==
                SimulasyonModu.Degerlendirme
            );
        }
    }

    void DegerleriBul()
    {
        foreach (var item in karsilastirilacakHucreler)
        {
            if (item.hucre_durumu == HucreDurumu.Normal)
            {
                KacNormal++;
            }
            if (item.hucre_durumu == HucreDurumu.Uyarý)
            {
                KacUyari++;
            }
            if (item.hucre_durumu == HucreDurumu.Kritik)
            {
                KacKritik++;
            }
            if (item.secilen_hucre_durumu == HucreDurumu.Normal && item.secilen_hucre_durumu == item.hucre_durumu)
            {
                NormalKacDogru++;
            }
            if (item.secilen_hucre_durumu == HucreDurumu.Uyarý && item.secilen_hucre_durumu == item.hucre_durumu)
            {
                UyariKacDogru++;
            }
            if (item.secilen_hucre_durumu == HucreDurumu.Kritik && item.secilen_hucre_durumu == item.hucre_durumu)
            {
                KritikKacDogru++;
            }
        }
        int dogruSayisi = NormalKacDogru + UyariKacDogru + KritikKacDogru;
        YanlisHucreSayisi = 12 - dogruSayisi;
        YuzdeBul(dogruSayisi);
        DegerleriTexteYazdýr();
    }

    void DegerleriTexteYazdýr()
    {
        textKacNormal.text = KacNormal.ToString();
        textNormalKacDogru.text = NormalKacDogru.ToString();
        textKacUyari.text = KacUyari.ToString();
        textUyariKacDogru.text = UyariKacDogru.ToString();
        textKacKritik.text = KacKritik.ToString();
        textKritikKacDogru.text = KritikKacDogru.ToString();

        TextRenkleriniAyarla();
    }

    void TextRenkleriniAyarla()
    {
        if (KacNormal == NormalKacDogru)
        {
            textNormalKacDogru.color = Color.green;
        }
        else
        {
            textNormalKacDogru.color = Color.red;
        }
        if (KacUyari == UyariKacDogru)
        {
            textUyariKacDogru.color = Color.green;
        }
        else
        {
            textUyariKacDogru.color = Color.red;
        }
        if (KacKritik == KritikKacDogru)
        {
            textKritikKacDogru.color = Color.green;
        }
        else
        {
            textKritikKacDogru.color = Color.red;
        }
    }

    void YuzdeBul(int dogrular)
    {
        float yuzdelik = (dogrular / 12f) * 100;
        textYuzdelikOran.text = "%" + yuzdelik.ToString("F2");
    }

    public void DegerlendirmeSonucunuGoster()
    {
  

        ModDegerlendirmeYoneticisi yonetici =
            FindAnyObjectByType<ModDegerlendirmeYoneticisi>();

        if (yonetici == null)
        {
            Debug.LogError("ModDegerlendirmeYoneticisi bulunamadý!");
            return;
        }

        yonetici.SonucPaneliniGuncelle();

        panelDegerlendirmeSonucu.SetActive(true);

        gameObject.SetActive(false);
    }
}
