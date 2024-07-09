using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMenuBelajar : MonoBehaviour
{
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
            aClipButton, iClipButton, uClipButton, eClipButton, e2ClipButton, euClipButton, oClipButton,
            kaClipButton, gaClipButton, ngaClipButton, caClipButton, jaClipButton, nyaClipButton, taClipButton,
            daClipButton, naClipButton, paClipButton, baClipButton, maClipButton, yaClipButton, raClipButton,
            laClipButton, waClipButton, saClipButton, haClipButton, faClipButton, qaClipButton, vaClipButton,
            xaClipButton, zaClipButton
        };

        // Assigning the button click events to the corresponding methods
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
        LeanTween.scale(button, new Vector3(1.1f, 1.1f, 1.1f), 0.5f)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.scale(button, new Vector3(1f, 1f, 1f), 0.5f)
                    .setEase(LeanTweenType.easeOutQuad)
                    .setOnComplete(() =>
                    {
                        EnableAllButtons(); // Mengaktifkan kembali semua tombol setelah animasi selesai
                    });
            });
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
