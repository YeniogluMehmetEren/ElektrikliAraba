using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BoltRemover : MonoBehaviour
{
    [Header("Vida Ayarlarý")]
    public float asagiInmeMesafesi = 0.15f;
    public float islemSuresi = 1f;
    public float donusHizi = 720f;

    [Header("Tüm Vidalarýn Listesi")]
    public List<Vidalar> tumVidalar;

    [SerializeField] private AudioSource matkap_ses;

    public int kacVidaSokuldu = 0;

    public bool matkapTutulduMu = false;

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
            //Transform boltTransform = other.transform.Find("Bolt"); //Child GameObject'e Transform üzerinden ulaþýlýyormuþ
            //GameObject BoltGO = boltTransform.gameObject;     GameObject üzerinden deðil collider üzerinden GO ulaþýcaz

            foreach (var vida in tumVidalar)
            {
                if (other == vida.etkilesimAlani)
                {
                    if (vida.islemDevamEdiyor)
                    {
                        continue;
                    }

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



    private IEnumerator VidayiSok(Vidalar vida)
    {
        vida.islemDevamEdiyor = true;

        if (matkap_ses != null && !matkap_ses.isPlaying)
        {
            matkap_ses.Play();
        }

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
        kacVidaSokuldu++;
        vida.islemDevamEdiyor = false;

        if (matkap_ses != null && matkap_ses.isPlaying)
        {
            matkap_ses.Stop();
        }
    }

    private IEnumerator VidayiTak(Vidalar vida)
    {
        vida.islemDevamEdiyor = true;

        if (matkap_ses != null && !matkap_ses.isPlaying)
        {
            matkap_ses.Play();
        }
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
        kacVidaSokuldu--;
        vida.islemDevamEdiyor = false;
        if (matkap_ses != null && matkap_ses.isPlaying)
        {
            matkap_ses.Stop();
        }
    }

    public bool VidalarinHepsiSokulduMu()
    {
        if (kacVidaSokuldu == 13)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int GetKacVidaSokuldu() { return kacVidaSokuldu; }

    public void MatkapTutuldu(SelectEnterEventArgs args) 
    {
        if (args.interactorObject is XRSocketInteractor)
        {
            return;
        }
        matkapTutulduMu = true; 
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