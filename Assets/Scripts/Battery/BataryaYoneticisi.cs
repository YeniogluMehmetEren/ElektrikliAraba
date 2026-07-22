using System.Linq;
using UnityEngine;
using System;

public class BataryaYoneticisi : MonoBehaviour
{


    private HucreSicakligi[] hucreSicakliklari;
    private BataryaDegiskenleri[] hucreler;

    private int mevcut_gun = 1;

    public event Action BataryaGuncellendi;

    private void Awake()
    {
        HucreleriHazirla();
    }

    private void Start()
    {
        SenaryoOlustur();
        HucreSicakliklariniYukle();

        GunuYukle(mevcut_gun);
        BataryaGuncellendi?.Invoke();
    }

    public void SonrakiGun()
    {
        if (mevcut_gun >= 3)
        {
            Debug.Log("Son güne ulaşıldı.");
            return;
        }
            

        mevcut_gun++;

        GunuYukle(mevcut_gun);

        BataryaGuncellendi?.Invoke();
    }
    private void HucreleriHazirla()
    {
        hucreler = GetComponentsInChildren<BataryaDegiskenleri>();

        hucreler = hucreler
            .OrderBy(h => h.gameObject.name)
            .ToArray();

        for (int i = 0; i < hucreler.Length; i++)
        {
            hucreler[i].cell_id = i + 1;
        }
    }

    private void SenaryoOlustur()
    {
        int secilenSeneryo = UnityEngine.Random.Range(1, 4);

        ISeneryo seneryo;

        switch (secilenSeneryo)
        {
            case 1:
                seneryo = new NormalSeneryo();
                break;

            case 2:
                seneryo = new UyarıSeneryo();
                break;

            case 3:
                seneryo = new KritikSeneryo();
                break;

            default:
                seneryo = new NormalSeneryo();
                break;
        }

        hucreSicakliklari = seneryo.SicaklikOlustur();

        Debug.Log($"Senaryo : {seneryo.GetType().Name}");
    }

    private void HucreSicakliklariniYukle()
    {
        for (int i = 0; i < hucreler.Length; i++)
        {
            hucreler[i].birinci_sicaklik = hucreSicakliklari[i].BirinciGun;
            hucreler[i].ikinci_sicaklik = hucreSicakliklari[i].IkinciGun;
            hucreler[i].ucuncu_sicaklik = hucreSicakliklari[i].UcuncuGun;
        }
    }

    private void GunuYukle(int gun)
    {
        for (int i = 0; i < hucreler.Length; i++)
        {
            switch (gun)
            {
                case 1:
                    hucreler[i].mevcut_sicaklik = hucreler[i].birinci_sicaklik;
                    break;

                case 2:
                    hucreler[i].mevcut_sicaklik = hucreler[i].ikinci_sicaklik;
                    break;

                case 3:
                    hucreler[i].mevcut_sicaklik = hucreler[i].ucuncu_sicaklik;
                    break;
            }

            hucreler[i].hucre_durumu = SicaklikDurumHesaplayici.Hesapla(hucreler[i].mevcut_sicaklik);
        }
    }
    public BataryaDegiskenleri HucreGetir(int cellId)
    {
        if (cellId < 1 || cellId > hucreler.Length)
            return null;

        return hucreler[cellId - 1];
    }


    public BataryaDegiskenleri[] HucreleriGetir()
    {
        return hucreler;
    }
}
