using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem moveParticle;

    [Range(0, 10)]
    [SerializeField] private float occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] private float dustFormationPeriod;

    [SerializeField] private Rigidbody2D rb;

    float counter;
    bool isOnGround;

    [SerializeField] ParticleSystem fallParticle;
    [SerializeField] public ParticleSystem touchParticle;


    void Start()
    {
        touchParticle.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(isOnGround && Mathf.Abs(rb.velocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                moveParticle.Play();
                counter = 0;
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            fallParticle.Play();
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        { 
            isOnGround = false;
        }
           
    }

    public void playTouchParticle(Vector2 pos)
    {
        touchParticle.transform.position = pos;
        touchParticle.Play();
    }

}
