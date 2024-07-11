using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMenuBelajar : MonoBehaviour
{
    [Header("Button Angka")]
    public Button buttonAngka0;
    public Button buttonAngka1;
    public Button buttonAngka2;
    public Button buttonAngka3;
    public Button buttonAngka4;
    public Button buttonAngka5;
    public Button buttonAngka6;
    public Button buttonAngka7;
    public Button buttonAngka8;
    public Button buttonAngka9;

    [Header("Button Swara")]
    public Button aClipButton;
    public Button iClipButton;
    public Button uClipButton;
    public Button eClipButton;
    public Button e2ClipButton;
    public Button euClipButton;
    public Button oClipButton;

    [Header("Button Ngalegena")]
    public Button kaClipButton;
    public Button gaClipButton;
    public Button ngaClipButton;
    public Button caClipButton;
    public Button jaClipButton;
    public Button nyaClipButton;
    public Button taClipButton;
    public Button daClipButton;
    public Button naClipButton;
    public Button paClipButton;
    public Button baClipButton;
    public Button maClipButton;
    public Button yaClipButton;
    public Button raClipButton;
    public Button laClipButton;
    public Button waClipButton;
    public Button saClipButton;
    public Button haClipButton;
    public Button faClipButton;
    public Button qaClipButton;
    public Button vaClipButton;
    public Button xaClipButton;
    public Button zaClipButton;

    // Audio Clip Section
    [Header("Audio Clip Angka")]
    [SerializeField] private AudioClip angka0;
    [SerializeField] private AudioClip angka1;
    [SerializeField] private AudioClip angka2;
    [SerializeField] private AudioClip angka3;
    [SerializeField] private AudioClip angka4;
    [SerializeField] private AudioClip angka5;
    [SerializeField] private AudioClip angka6;
    [SerializeField] private AudioClip angka7;
    [SerializeField] private AudioClip angka8;
    [SerializeField] private AudioClip angka9;

    [Header("Audio Clip Swara")]
    [SerializeField] private AudioClip aClip;
    [SerializeField] private AudioClip iClip;
    [SerializeField] private AudioClip uClip;
    [SerializeField] private AudioClip eClip;
    [SerializeField] private AudioClip e2Clip;
    [SerializeField] private AudioClip euClip;
    [SerializeField] private AudioClip oClip;

    [Header("Audio Clip Ngalegena")]
    [SerializeField] private AudioClip kaClip;
    [SerializeField] private AudioClip gaClip;
    [SerializeField] private AudioClip ngaClip;
    [SerializeField] private AudioClip caClip;
    [SerializeField] private AudioClip jaClip;
    [SerializeField] private AudioClip nyaClip;
    [SerializeField] private AudioClip taClip;
    [SerializeField] private AudioClip daClip;
    [SerializeField] private AudioClip naClip;
    [SerializeField] private AudioClip paClip;
    [SerializeField] private AudioClip baClip;
    [SerializeField] private AudioClip maClip;
    [SerializeField] private AudioClip yaClip;
    [SerializeField] private AudioClip raClip;
    [SerializeField] private AudioClip laClip;
    [SerializeField] private AudioClip waClip;
    [SerializeField] private AudioClip saClip;
    [SerializeField] private AudioClip haClip;
    [SerializeField] private AudioClip faClip;
    [SerializeField] private AudioClip qaClip;
    [SerializeField] private AudioClip vaClip;
    [SerializeField] private AudioClip xaClip;
    [SerializeField] private AudioClip zaClip;

    private List<Button> allButtons;

    private void Start()
    {
        allButtons = new List<Button>
        {
            buttonAngka0, buttonAngka1, buttonAngka2, buttonAngka3, buttonAngka4, buttonAngka5, buttonAngka6,
            buttonAngka7, buttonAngka8, buttonAngka9,
            aClipButton, iClipButton, uClipButton, eClipButton, e2ClipButton, euClipButton, oClipButton,
            kaClipButton, gaClipButton, ngaClipButton, caClipButton, jaClipButton, nyaClipButton, taClipButton,
            daClipButton, naClipButton, paClipButton, baClipButton, maClipButton, yaClipButton, raClipButton,
            laClipButton, waClipButton, saClipButton, haClipButton, faClipButton, qaClipButton, vaClipButton,
            xaClipButton, zaClipButton
        };

        // Assigning the button click events to the corresponding methods
        AssignButtonClick(buttonAngka0, PlayAngka0Clip);
        AssignButtonClick(buttonAngka1, PlayAngka1Clip);
        AssignButtonClick(buttonAngka2, PlayAngka2Clip);
        AssignButtonClick(buttonAngka3, PlayAngka3Clip);
        AssignButtonClick(buttonAngka4, PlayAngka4Clip);
        AssignButtonClick(buttonAngka5, PlayAngka5Clip);
        AssignButtonClick(buttonAngka6, PlayAngka6Clip);
        AssignButtonClick(buttonAngka7, PlayAngka7Clip);
        AssignButtonClick(buttonAngka8, PlayAngka8Clip);
        AssignButtonClick(buttonAngka9, PlayAngka9Clip);

        AssignButtonClick(aClipButton, PlayAClip);
        AssignButtonClick(iClipButton, PlayIClip);
        AssignButtonClick(uClipButton, PlayUClip);
        AssignButtonClick(eClipButton, PlayEClip);
        AssignButtonClick(e2ClipButton, PlayE2Clip);
        AssignButtonClick(euClipButton, PlayEuClip);
        AssignButtonClick(oClipButton, PlayOClip);

        AssignButtonClick(kaClipButton, PlayKaClip);
        AssignButtonClick(gaClipButton, PlayGaClip);
        AssignButtonClick(ngaClipButton, PlayNgaClip);
        AssignButtonClick(caClipButton, PlayCaClip);
        AssignButtonClick(jaClipButton, PlayJaClip);
        AssignButtonClick(nyaClipButton, PlayNyaClip);
        AssignButtonClick(taClipButton, PlayTaClip);
        AssignButtonClick(daClipButton, PlayDaClip);
        AssignButtonClick(naClipButton, PlayNaClip);
        AssignButtonClick(paClipButton, PlayPaClip);
        AssignButtonClick(baClipButton, PlayBaClip);
        AssignButtonClick(maClipButton, PlayMaClip);
        AssignButtonClick(yaClipButton, PlayYaClip);
        AssignButtonClick(raClipButton, PlayRaClip);
        AssignButtonClick(laClipButton, PlayLaClip);
        AssignButtonClick(waClipButton, PlayWaClip);
        AssignButtonClick(saClipButton, PlaySaClip);
        AssignButtonClick(haClipButton, PlayHaClip);
        AssignButtonClick(faClipButton, PlayFaClip);
        AssignButtonClick(qaClipButton, PlayQaClip);
        AssignButtonClick(vaClipButton, PlayVaClip);
        AssignButtonClick(xaClipButton, PlayXaClip);
        AssignButtonClick(zaClipButton, PlayZaClip);
    }

    private void AssignButtonClick(Button button, UnityEngine.Events.UnityAction action)
    {
        button.onClick.AddListener(() =>
        {
            DisableAllButtons();
            action.Invoke();
            AnimateButton(button.gameObject);
        });
    }

    private void DisableAllButtons()
    {
        foreach (Button button in allButtons)
        {
            button.interactable = false;
        }
    }

    private void EnableAllButtons()
    {
        foreach (Button button in allButtons)
        {
            button.interactable = true;
        }
    }

    private void AnimateButton(GameObject button)
    {
        LeanTween.scale(button, new Vector3(1.1f, 1.1f, 1.1f), 0.7f)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.scale(button, new Vector3(1f, 1f, 1f), 0.7f)
                    .setEase(LeanTweenType.easeOutQuad)
                    .setOnComplete(() =>
                    {
                        EnableAllButtons(); // Mengaktifkan kembali semua tombol setelah animasi selesai
                    });
            });
    }

    // Audio Angka
    public void PlayAngka0Clip()
    {
        AudioManager.instance.PlaySound(angka0);
    }

    public void PlayAngka1Clip()
    {
        AudioManager.instance.PlaySound(angka1);
    }

    public void PlayAngka2Clip()
    {
        AudioManager.instance.PlaySound(angka2);
    }

    public void PlayAngka3Clip()
    {
        AudioManager.instance.PlaySound(angka3);
    }

    public void PlayAngka4Clip()
    {
        AudioManager.instance.PlaySound(angka4);
    }

    public void PlayAngka5Clip()
    {
        AudioManager.instance.PlaySound(angka5);
    }

    public void PlayAngka6Clip()
    {
        AudioManager.instance.PlaySound(angka6);
    }

    public void PlayAngka7Clip()
    {
        AudioManager.instance.PlaySound(angka7);
    }

    public void PlayAngka8Clip()
    {
        AudioManager.instance.PlaySound(angka8);
    }

    public void PlayAngka9Clip()
    {
        AudioManager.instance.PlaySound(angka9);
    }

    // Audio Swara
    public void PlayAClip()
    {
        AudioManager.instance.PlaySound(aClip);
    }

    public void PlayIClip()
    {
        AudioManager.instance.PlaySound(iClip);
    }

    public void PlayUClip()
    {
        AudioManager.instance.PlaySound(uClip);
    }

    public void PlayEClip()
    {
        AudioManager.instance.PlaySound(eClip);
    }

    public void PlayE2Clip()
    {
        AudioManager.instance.PlaySound(e2Clip);
    }

    public void PlayEuClip()
    {
        AudioManager.instance.PlaySound(euClip);
    }

    public void PlayOClip()
    {
        AudioManager.instance.PlaySound(oClip);
    }

    // Audio Ngalegena
    public void PlayKaClip()
    {
        AudioManager.instance.PlaySound(kaClip);
    }

    public void PlayGaClip()
    {
        AudioManager.instance.PlaySound(gaClip);
    }

    public void PlayNgaClip()
    {
        AudioManager.instance.PlaySound(ngaClip);
    }

    public void PlayCaClip()
    {
        AudioManager.instance.PlaySound(caClip);
    }

    public void PlayJaClip()
    {
        AudioManager.instance.PlaySound(jaClip);
    }

    public void PlayNyaClip()
    {
        AudioManager.instance.PlaySound(nyaClip);
    }

    public void PlayTaClip()
    {
        AudioManager.instance.PlaySound(taClip);
    }

    public void PlayDaClip()
    {
        AudioManager.instance.PlaySound(daClip);
    }

    public void PlayNaClip()
    {
        AudioManager.instance.PlaySound(naClip);
    }

    public void PlayPaClip()
    {
        AudioManager.instance.PlaySound(paClip);
    }

    public void PlayBaClip()
    {
        AudioManager.instance.PlaySound(baClip);
    }

    public void PlayMaClip()
    {
        AudioManager.instance.PlaySound(maClip);
    }

    public void PlayYaClip()
    {
        AudioManager.instance.PlaySound(yaClip);
    }

    public void PlayRaClip()
    {
        AudioManager.instance.PlaySound(raClip);
    }

    public void PlayLaClip()
    {
        AudioManager.instance.PlaySound(laClip);
    }

    public void PlayWaClip()
    {
        AudioManager.instance.PlaySound(waClip);
    }

    public void PlaySaClip()
    {
        AudioManager.instance.PlaySound(saClip);
    }

    public void PlayHaClip()
    {
        AudioManager.instance.PlaySound(haClip);
    }

    public void PlayFaClip()
    {
        AudioManager.instance.PlaySound(faClip);
    }

    public void PlayQaClip()
    {
        AudioManager.instance.PlaySound(qaClip);
    }

    public void PlayVaClip()
    {
        AudioManager.instance.PlaySound(vaClip);
    }

    public void PlayXaClip()
    {
        AudioManager.instance.PlaySound(xaClip);
    }

    public void PlayZaClip()
    {
        AudioManager.instance.PlaySound(zaClip);
    }
}
