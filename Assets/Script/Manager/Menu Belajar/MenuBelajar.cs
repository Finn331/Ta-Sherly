using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBelajar : MonoBehaviour
{
    [Header("Menu Belajar Panel")]
    public GameObject menuBelajarPanel;
    public GameObject menuBelajarButton;
    public GameObject menuBelajarHeading;

    [Header("Mengenal Aksara Sunda Setup")]
    public GameObject mengenalAksaraPanel;
    public GameObject buttonBackMengenalAksara;
    public GameObject backButton;

    [Header("Aksara Swara Panel")]
    public GameObject aksaraSwara;

    [Header("Aksara Ngalegena Panel")]
    public GameObject aksaraNgalegena;

    [Header("Vokalisasi Panel")]
    public GameObject vokalisasi;

    [Header("Angka Panel")]
    public GameObject angka;

    [Header("Audio Clip")]
    [SerializeField] AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Mengenal Aksara Sunda
    public void MengenalAksaraSunda()
    {
        AudioManager.instance.PlaySound(buttonClick);
        menuBelajarPanel.SetActive(false);
        menuBelajarButton.SetActive(false);
        menuBelajarHeading.SetActive(false);
        mengenalAksaraPanel.SetActive(true);
        buttonBackMengenalAksara.SetActive(true);
    }

    public void MengenalAksaraSundaBack()
    {
        AudioManager.instance.PlaySound(buttonClick);
        menuBelajarPanel.SetActive(true);
        menuBelajarButton.SetActive(true);
        menuBelajarHeading.SetActive(true);
        mengenalAksaraPanel.SetActive(false);
        buttonBackMengenalAksara.SetActive(false);
    }

    public void BackButtonToAksaraSundaPanel()
    {
        AudioManager.instance.PlaySound(buttonClick);
        mengenalAksaraPanel.SetActive(true);
        buttonBackMengenalAksara.SetActive(true);
        menuBelajarPanel.SetActive(false);
        menuBelajarButton.SetActive(false);
        menuBelajarHeading.SetActive(false);
        backButton.SetActive(false);
        aksaraNgalegena.SetActive(false);
        aksaraSwara.SetActive(false);
        angka.SetActive(false);
        vokalisasi.SetActive(false);
    }

    public void AksaraSwara()
    {
        AudioManager.instance.PlaySound(buttonClick);
        aksaraSwara.SetActive(true);
        backButton.SetActive(true);
        menuBelajarPanel.SetActive(false);
        menuBelajarButton.SetActive(false);
        menuBelajarHeading.SetActive(false);
        mengenalAksaraPanel.SetActive(false);
        buttonBackMengenalAksara.SetActive(false);
    }

    public void AksaraNgalegena()
    {
        AudioManager.instance.PlaySound(buttonClick);
        aksaraNgalegena.SetActive(true);
        backButton.SetActive(true);
        menuBelajarPanel.SetActive(false);
        menuBelajarButton.SetActive(false);
        menuBelajarHeading.SetActive (false);
        mengenalAksaraPanel.SetActive(false);
        buttonBackMengenalAksara.SetActive(false);
    }

    public void AksaraAngka()
    {
        AudioManager.instance.PlaySound(buttonClick);
        angka.SetActive(true);
        backButton.SetActive(true);
        menuBelajarPanel.SetActive(false);
        menuBelajarButton.SetActive(false);
        menuBelajarHeading.SetActive(false);
        mengenalAksaraPanel.SetActive(false);
        buttonBackMengenalAksara.SetActive(false);
    }

    public void Vokalisasi()
    {
        AudioManager.instance.PlaySound(buttonClick);
        vokalisasi.SetActive(true);
        backButton.SetActive(true);
        menuBelajarPanel.SetActive(false);
        menuBelajarButton.SetActive(false);
        menuBelajarHeading.SetActive(false);
        mengenalAksaraPanel.SetActive(false);
        buttonBackMengenalAksara.SetActive(false);
    }
}
