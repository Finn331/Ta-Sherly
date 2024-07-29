using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [Header("Player Script Reference")]
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerController playerController2;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerAttack playerAttack2;

    [Header("Finish Level UI")]
    [SerializeField] GameObject finishLevelPanel;
    [SerializeField] GameObject finishLevelHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelFinished()
    {
        playerController.enabled = false;
        playerController2.enabled = false;
        playerAttack.enabled = false;
        playerAttack2.enabled = false;

        finishLevelPanel.SetActive(true);
        finishLevelHolder.SetActive(true);
        LeanTween.scale(finishLevelHolder, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutBack);

    }
}
