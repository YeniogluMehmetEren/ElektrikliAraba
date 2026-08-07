using UnityEngine;

public class EgitimSesYoneticisi : MonoBehaviour
{
    [SerializeField] private AudioSource sesKaynagi;

    [SerializeField] private AudioClip gorev_tamamlandi;

    [SerializeField] private AudioClip koruyucu_ekipman_giyme;

    [SerializeField] private AudioClip araci_yukari_kaldir;

    [SerializeField] private AudioClip lifti_bataryanin_altina_getir;

    [SerializeField] private AudioClip lifti_yukari_kaldir;

    [SerializeField] private AudioClip soketleri_cikar;

    [SerializeField] private AudioClip matkabi_al;

    [SerializeField] private AudioClip vidalari_sok;

    [SerializeField] private AudioClip bataryayi_indir;

    [SerializeField] private AudioClip termal_kamerayi_al;

    [SerializeField] private AudioClip tum_hucreler_taramadi;

    [SerializeField] private AudioClip birinci_gun;

    [SerializeField] private AudioClip ikinci_gun;

    [SerializeField] private AudioClip ucuncu_gun;

    [SerializeField] private AudioClip egitim_tamamlandi;



    private void SesCal(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }
        sesKaynagi.Stop();
        sesKaynagi.PlayOneShot(clip);
    }

    public bool SesCaliyorMu()
    {
        return sesKaynagi.isPlaying;
    }

    public void GorevTamamlandi()
    {
        SesCal(gorev_tamamlandi);
    }

    public void KoruyucuEkipmanGiyme()
    {
        SesCal(koruyucu_ekipman_giyme);
    }

    public void AraciYukariKaldir()
    {
        SesCal(araci_yukari_kaldir);
    }

    public void LiftiBataryaninAltinaGetir()
    {
        SesCal(lifti_bataryanin_altina_getir);
    }

    public void LiftiYukariKaldir()
    {
        SesCal(lifti_yukari_kaldir);
    }

    public void SoketleriCikar()
    {
        SesCal(soketleri_cikar);
    }

    public void MatkabiAl()
    {
        SesCal(matkabi_al);
    }

    public void VidalariSok()
    {
        SesCal(vidalari_sok);
    }

    public void BataryayiIndir()
    {
        SesCal(bataryayi_indir);
    }

    public void TermalKamerayiAl()
    {
        SesCal(termal_kamerayi_al);
    }

    public void TumHucrelerTaranmadi()
    {
        SesCal(tum_hucreler_taramadi);
    }

    public void BirinciGun()
    {
        SesCal(birinci_gun);
    }

    public void IkinciGun()
    {
        SesCal(ikinci_gun);
    }

    public void UcuncuGun()
    {
        SesCal(ucuncu_gun);
    }

    public void EgitimTamamlandi()
    {
        SesCal(egitim_tamamlandi);
    }

}
