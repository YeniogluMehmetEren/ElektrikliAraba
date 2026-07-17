using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltRemover : MonoBehaviour
{
    public float asagiInmeMesafesi = 0.15f;
    public float islemSuresi = 1f;
    public float donusHizi = 720f;

    public bool a;
    public bool b;

    [Header("Tüm Vidalarýn Listesi")]
    public List<Vidalar> tumVidalar;

    private void Start()
    {
        foreach (var vida in tumVidalar)
        {
            vida.ilkPozisyon = vida.vidaGO.transform.position;
        }
    }

    private void Update()
    {
        if (a)
        {
            //StartCoroutine(VidayiSok(vida));
        }
        if (b)
        {
            //StartCoroutine(VidayiTak(vida));
        }
    }

    private IEnumerator VidayiSok(Vidalar vida)
    {
        vida.islemDevamEdiyor = true;

        float gecenZaman = 0f;
        Vector3 baslangicNoktasi = vida.ilkPozisyon;
        Vector3 hedefNokta = vida.ilkPozisyon + (Vector3.down * asagiInmeMesafesi);

        while (gecenZaman < islemSuresi)
        {
            gecenZaman += Time.deltaTime;
            float oran = gecenZaman / islemSuresi;

            vida.vidaGO.transform.position = Vector3.Lerp(baslangicNoktasi, hedefNokta, oran);
            vida.vidaGO.transform.Rotate(0, 0, donusHizi * Time.deltaTime, Space.Self);
            yield return null;
        }
        vida.vidaGO.SetActive(false);
        vida.islemDevamEdiyor = false;
    }

    private IEnumerator VidayiTak(Vidalar vida)
    {
        vida.islemDevamEdiyor = true;
        vida.vidaGO.SetActive(true);

        float gecenZaman = 0f;
        Vector3 baslangicNoktasi = vida.ilkPozisyon + (Vector3.down * asagiInmeMesafesi);
        Vector3 hedefNokta = vida.ilkPozisyon;

        while (gecenZaman < islemSuresi)
        {
            gecenZaman += Time.deltaTime;
            float oran = gecenZaman / islemSuresi;

            vida.vidaGO.transform.position = Vector3.Lerp(baslangicNoktasi, hedefNokta, oran);
            vida.vidaGO.transform.Rotate(0, 0, -donusHizi * Time.deltaTime, Space.Self);

            yield return null;
        }

        vida.vidaGO.transform.position = vida.ilkPozisyon;
        //takiliMi = true;
        vida.islemDevamEdiyor = false;
    }
}

[System.Serializable]
public class Vidalar
{
    //public Collider etkilesimAlani;
    public GameObject vidaGO;
    public bool takiliMi = true;

    [HideInInspector] public Vector3 ilkPozisyon;
    [HideInInspector] public bool islemDevamEdiyor = false;
}