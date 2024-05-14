using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TigerControlle : MonoBehaviour
{

    private int hp_max = 100;
    private int hp_min = 0;
    private int hp_current = 0;

    [SerializeField] Slider hpSlider;

    private GameManager gameManager;
    private ParticleSystem spellParticle;


    private Vector3 startPos;
    private Vector3 currentPos;

    public Vector3 CurrentPos { get => transform.position;}
    public Vector3 StartPos { get => startPos; set => startPos = value; }

    private void Start()
    {
        StartPos = transform.position;
        hp_current = hp_max;

        gameManager = GameManager.Instance;
    }


    public void hitController()
    {
        hp_current -= 16;
        hpSlider.value = hp_current;

        gameManager.ballTouchWallTigers();
        gameManager.ballTouchAll();


        if (hp_current <= 0)
        {
            gameManager.loseHP();
        }
    }

    public void healHP(int addHp)
    {
        hp_current += addHp;

        if (hp_current > hp_max)
        {
            hp_current = hp_max;
        }

        hpSlider.value = hp_current;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitController();
        }
        
    }


    public void resetTiger()
    {
        hp_current = hp_max;
        hpSlider.value = hp_max;
        transform.position = startPos;
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
