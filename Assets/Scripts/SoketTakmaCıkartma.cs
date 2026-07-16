using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SoketTakmaCıkartma : MonoBehaviour
{
    public GameObject conn1Connected;
    public GameObject conn2Connected;
    public GameObject conn3Connected;
    public GameObject conn4Connected;
    public GameObject conn5Connected;
    public GameObject conn1Disconnected;
    public GameObject conn2Disconnected;
    public GameObject conn3Disconnected;
    public GameObject conn4Disconnected;
    public GameObject conn5Disconnected;

    public XRBaseInteractor sagElInteractor;
    public XRBaseInteractor solElInteractor;
    void Update()
    {
        EldenGelenEtkilesimiKontrolEt(sagElInteractor);
        EldenGelenEtkilesimiKontrolEt(solElInteractor);
    }

    private void EldenGelenEtkilesimiKontrolEt(XRBaseInteractor elInteractor)
    {
        if (elInteractor == null || !elInteractor.hasSelection) return;

        IXRSelectInteractable tutulanObje = elInteractor.firstInteractableSelected;

        if (tutulanObje != null)
        {
            if (tutulanObje.transform.CompareTag("Conn1Connected"))
            {
                conn1Connected.SetActive(false);
                conn1Disconnected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn1Disconnected"))
            {
                conn1Disconnected.SetActive(false);
                conn1Connected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn2Connected"))
            {
                conn2Connected.SetActive(false);
                conn2Disconnected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn2Disconnected"))
            {
                conn2Disconnected.SetActive(false);
                conn2Connected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn3Connected"))
            {
                conn3Connected.SetActive(false);
                conn3Disconnected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn3Disconnected"))
            {
                conn3Disconnected.SetActive(false);
                conn3Connected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn4Connected"))
            {
                conn4Connected.SetActive(false);
                conn4Disconnected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn4Disconnected"))
            {
                conn4Disconnected.SetActive(false);
                conn4Connected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn5Connected"))
            {
                conn5Connected.SetActive(false);
                conn5Disconnected.SetActive(true);
            }
            else if (tutulanObje.transform.CompareTag("Conn5Disconnected"))
            {
                conn5Disconnected.SetActive(false);
                conn5Connected.SetActive(true);
            }
        }
    }
}
