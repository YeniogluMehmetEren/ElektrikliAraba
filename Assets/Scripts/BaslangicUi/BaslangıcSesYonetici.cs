using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BaslangıcSesYonetici : MonoBehaviour
{
    [SerializeField] AudioSource ses_kaynagi;

    [SerializeField] Toggle egitim_toggle;

    [SerializeField] Toggle degenlendirme_togle;

    [SerializeField] Button baslat_butonu;

    private void Start()
    {
        baslat_butonu.interactable = false;

        egitim_toggle.interactable = false;

        degenlendirme_togle.interactable = false;

        ses_kaynagi.Play();

        StartCoroutine(SesiBekle());
    }

    private IEnumerator SesiBekle()
    {
        yield return new WaitForSeconds(ses_kaynagi.clip.length);

        baslat_butonu.interactable = true;

        egitim_toggle.interactable = true;

        degenlendirme_togle.interactable = true;
    }

}
