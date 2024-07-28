using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBoss : MonoBehaviour
{
    [Header("Healthbar Setting")]
    [SerializeField] private Slider healthSlider;

    [Header("Script References")]
    [SerializeField] private EnemyStatus enemyStatus;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    public void SetMaxHealth()
    {
        if (healthSlider != null && enemyStatus != null)
        {
            healthSlider.maxValue = enemyStatus.maxHealth;
            healthSlider.value = enemyStatus.currHealth;
        }
    }

    public void UpdateHealth()
    {
        if (healthSlider != null && enemyStatus != null)
        {
            healthSlider.value = enemyStatus.currHealth;
        }

        if (enemyStatus.currHealth == 0)
        {
            LeanTween.scale(healthSlider.gameObject, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeInBack).setOnComplete(() => healthSlider.enabled = false);
            
        }
    }
}
