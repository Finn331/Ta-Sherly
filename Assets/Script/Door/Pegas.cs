using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pegas : MonoBehaviour
{
    [Header("Pegas Requirement")]
    public bool haveKey;

    [Header("Pegas Text")]
    [SerializeField] private GameObject pegasText;

    [Header("Pegas Button")]
    [SerializeField] private GameObject pegasButton;

    [Header("Script Reference")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerController playerController2;

    [SerializeField] private Animator penjaraAnim;
    private Animator anim;

    private bool playerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger)
        {
            KeyChecking();
        }
    }

    private void KeyChecking()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (haveKey)
            {
                anim.SetTrigger("open");
                penjaraAnim.SetTrigger("openPenjara");
                playerController.speed = 0;
                playerController2.speed = 0;
                playerController.enabled = false;
                playerController2.enabled = false;

                
            }
            else
            {
                ShowPegasText();
            }
        }
    }

    private void ShowPegasText()
    {
        pegasText.SetActive(true);
        LeanTween.scale(pegasText, Vector3.one, 1f)
                 .setEase(LeanTweenType.easeOutBack)
                 .setOnComplete(() =>
                 {
                     LeanTween.scale(pegasText, Vector3.zero, 1.5f)
                              .setEase(LeanTweenType.easeOutBack)
                              .setOnComplete(() => pegasText.SetActive(false));
                 });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && pegasButton != null)
        {
            playerInTrigger = true;
            pegasButton.SetActive(true);
            LeanTween.scale(pegasButton, Vector3.one, 1f).setEase(LeanTweenType.easeOutBack);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && pegasButton != null)
        {
            playerInTrigger = false;
            LeanTween.scale(pegasButton, Vector3.zero, 0.3f)
                     .setEase(LeanTweenType.easeOutBack)
                     .setOnComplete(() => pegasButton.SetActive(false));
        }
    }
}
