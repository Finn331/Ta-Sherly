using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("Text Setting")]
    [SerializeField] GameObject keyText;

    [Header("Script Reference")]
    [SerializeField] Pegas pegas;
    [SerializeField] EnemyStatus enemyStatus;

    [Header("Audio Clip Key")]
    [SerializeField] AudioClip keyClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (enemyStatus.currHealth > 1)
            {
                if (keyText != null)
                {

                    keyText.SetActive(true);
                    LeanTween.scale(keyText, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
                    {
                        LeanTween.scale(keyText, new Vector3(0, 0, 0), 1.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
                        {
                            keyText.SetActive(false);
                        });

                    });
                }
            }

            if (enemyStatus.currHealth == 0)
            {
                pegas.haveKey = true;
                AudioManager.instance.PlaySound(keyClip);
                Destroy(gameObject);
            }
        }
    }
}