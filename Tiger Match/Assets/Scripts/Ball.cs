using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{


    public float speed = 10.0f;

    private float min_speed = 0;
    private float force_speed = 0;
    private float addSpeed = 30;

    private bool isBoost = true;

    private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    private ParticleSystem spellParticle;

    private float acceleration = 2f;
    private Vector3 posStart;

    public Vector3 PosStart { get => posStart; set => posStart = value; }
    public float Min_speed { get => min_speed;}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PosStart = transform.position;

        min_speed = speed;

    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }


    public void strtBall()
    {
        transform.position = PosStart;
        forseUp();
        
    }

    public void forseUp()
    {
        float angle = Random.Range(30f, 120f);
        if (Random.Range(0, 2) == 0)
        {
            angle = Random.Range(210f, 330f);
        }

        float angleInRadians = angle * Mathf.Deg2Rad;

        float xComponent = Mathf.Cos(angleInRadians);
        float yComponent = Mathf.Sin(angleInRadians);

        Vector2 direction = new Vector2(xComponent, yComponent).normalized;

        rb.velocity = direction * speed;
    }

    public void bombForse()
    {
        speed += acceleration;
        Debug.Log(speed);

    }

    public void hitAnim()
    {
        animator.SetTrigger("Hit");
    }

    public void activeParticleSpell(ParticleSystem particle)
    {

        if (spellParticle != null)
        {
            Destroy(spellParticle.gameObject);
        }

        spellParticle = Instantiate(particle, gameObject.transform);
        spellParticle.Play();

    }




}
