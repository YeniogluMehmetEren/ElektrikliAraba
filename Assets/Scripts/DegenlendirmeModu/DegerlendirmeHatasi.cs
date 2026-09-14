using UnityEngine.Rendering;

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
            "Proceeded without required PPE.",
            10
        );
    }

    public static DegerlendirmeHatasi AracKaldirma()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.AracKaldirma,
            HataTürü.Prosedur,
            "Proceeded to the next step without lifting the vehicle.",
            5
        );
    }

    public static DegerlendirmeHatasi KucukLiftYeri()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.KucukLiftYeri,
            HataTürü.Prosedur,
            "Proceeded to the next step without positioning the small lift.",
            5
        );
    }

    public static DegerlendirmeHatasi KucukLiftTemas()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.KucukLiftTemas,
            HataTürü.Prosedur,
            "Proceeded to the next step without supporting the battery with the lift.",
            5
        );
    }

    public static DegerlendirmeHatasi Soket()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.Soket,
            HataTürü.Prosedur,
            "Proceeded to the next step without disconnecting the connectors.",
            5
        );
    }

    public static DegerlendirmeHatasi Matkap()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.Matkap,
            HataTürü.Prosedur,
            "Proceeded to the next step without grabbing the drill.",
            5
        );
    }

    public static DegerlendirmeHatasi Vida()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.Vida,
            HataTürü.Prosedur,
            "Proceeded to the next step without removing the screws.",
            5
        );
    }

    public static DegerlendirmeHatasi BataryaIndirme()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.BataryaIndirme,
            HataTürü.Prosedur,
            "Proceeded to the next step without lowering the battery.",
            10
        );
    }

    public static DegerlendirmeHatasi FLIR()
    {
        return new DegerlendirmeHatasi(
            DegerlendirmeHataKodu.FLIR,
            HataTürü.Prosedur,
            "Action performed before completing the thermal camera inspection.",
            5
        );
    }
}