using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class BoltRemover : MonoBehaviour
{
    [Header("Vida Ayarlarý")]
    public float asagiInmeMesafesi = 0.15f;
    public float islemSuresi = 1f;
    public float donusHizi = 720f;

    [Header("Tüm Vidalarýn Listesi")]
    public List<Vidalar> tumVidalar;

    private void Start()
    {
        foreach (var vida in tumVidalar)
        {
            vida.ilkPozisyon = vida.vidaGO.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            Transform boltTransform = other.transform.Find("Bolt"); //Child GameObject'e Transform üzerinden ulaþýlýyormuþ

            if (boltTransform != null)
            {
                GameObject BoltGO = boltTransform.gameObject;

                foreach (var vida in tumVidalar)
                {
                    if (BoltGO == vida.vidaGO)
                    {
                        if (vida.takiliMi)
                        {
                            StartCoroutine(VidayiSok(vida));
                        }
                        else
                        {
                            StartCoroutine(VidayiTak(vida));
                        }
                    }
                }
            }
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
        vida.takiliMi = false;
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
        vida.takiliMi = true;
        vida.islemDevamEdiyor = false;
    }
}

[System.Serializable]
public class Vidalar
{
    public Collider etkilesimAlani;
    public GameObject vidaGO;
    public bool takiliMi = true;

    [HideInInspector] public Vector3 ilkPozisyon;
    [HideInInspector] public bool islemDevamEdiyor = false;
}