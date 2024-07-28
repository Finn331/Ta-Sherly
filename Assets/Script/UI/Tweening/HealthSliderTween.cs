using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderTween : MonoBehaviour
{
    [Header("Health Slider Setup")]
    [SerializeField] Slider bossHealthSlider;
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
        if (collision.CompareTag("Player"))
        {
            LeanTween.scale(bossHealthSlider.gameObject, new Vector3(3, 3, 3), 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
