public class DegerlendirmeHatasi
{
    public DegerlendirmeHataKodu kod;
    public HataTürü tur;
    public string aciklama;
    public int ceza;

    private DegerlendirmeHatasi(
        DegerlendirmeHataKodu kod,
        HataTürü tur,
        string aciklama,
        int ceza)
    {
        this.kod = kod;
        this.tur = tur;
        this.aciklama = aciklama;
        this.ceza = ceza;
    }

    public static DegerlendirmeHatasi PPE()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.PPE,
            HataTürü.Guvenlik,
            "Gerekli koruyucu ekipmanlar kullanılmadan işleme devam edildi.",
            10
        );
    }

    public static DegerlendirmeHatasi AracKaldirma()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.AracKaldirma,
            HataTürü.Prosedur,
            "Araç kaldırılmadan sonraki işleme geçildi.",
            5
        );
    }

    public static DegerlendirmeHatasi KucukLiftYeri()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.KucukLiftYeri,
            HataTürü.Prosedur,
            "Küçük lift getirilmeden sonraki işleme geçildi.",
            5
        );
    }

    public static DegerlendirmeHatasi KucukLiftTemas()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.KucukLiftTemas,
            HataTürü.Prosedur,
            "Küçük lift bataryaya temas ettirilmeden sonraki işleme geçildi.",
            5
        );
    }

    public static DegerlendirmeHatasi Soket()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.Soket,
            HataTürü.Prosedur,
            "Soketler çıkarılmadan sonraki işleme geçildi.",
            5
        );
    }

    public static DegerlendirmeHatasi Matkap()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.Matkap,
            HataTürü.Prosedur,
            "Matkap alınmadan sonraki işleme geçildi.",
            5
        );
    }

    public static DegerlendirmeHatasi Vida()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.Vida,
            HataTürü.Prosedur,
            "Vidalar çıkarılmadan sonraki işleme geçildi.",
            5
        );
    }

    public static DegerlendirmeHatasi BataryaIndirme()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.BataryaIndirme,
            HataTürü.Prosedur,
            "Batarya indirilmeden sonraki işleme geçildi.",
            10
        );
    }

    public static DegerlendirmeHatasi FLIR()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.FLIR,
            HataTürü.Prosedur,
            "Termal kamera ile kontrol sırası tamamlanmadan işlem yapıldı.",
            5
        );
    }
}