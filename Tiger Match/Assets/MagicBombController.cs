using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBombController : MonoBehaviour
{

    private GameManager gameManager;
    private Animator animator;
    [SerializeField] ParticleSystem destroyParticle;

    private void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            Debug.Log(destroyParticle);
            activeParticleSpell();
            gameManager._Ball.forseUp();
            gameManager.ballTouchAll();
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            animator.SetTrigger("DestroyAnimTrigger");

            activeParticleSpell();

            gameManager._Ball.bombForse();
            gameManager._Ball.forseUp();
            gameManager.ballTouchAll();

        }
    }


    public void activeParticleSpell()
    {
        
        Instantiate(destroyParticle, gameObject.transform);
        destroyParticle.Play();

    }

    public void destroyBombAnim()
    {
        Destroy(gameObject);
    }





}
