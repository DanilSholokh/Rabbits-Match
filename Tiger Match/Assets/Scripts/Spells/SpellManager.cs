using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{


    private TigerControlle upTiger;
    private TigerControlle downTiger;

    private GameManager gameManager;
    private ParticleController particleController;

    [SerializeField] TouchInput touchInput;

    [SerializeField] private List<Image> fillCoolDowns;    
    [SerializeField] private List<TMP_Text> fillText;    


    private int hp_resurected = 30;
    private int speedAdd = 6;

    private int speed_min = 0;

    private int endcoolDownSpell = 10;
    [SerializeField] private float startCoolDownSpell = 0;
    public int Hp_resurected { get => hp_resurected; set => hp_resurected = value; }
    public ParticleController ParticleController { get => particleController; set => particleController = value; }

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        ParticleController = GetComponent<ParticleController>();

        upTiger = gameManager.UpTiger;
        downTiger = gameManager.DownTiger;

        speed_min = gameManager.TigerSpeed;


        for (int i = 0; i < fillCoolDowns.Count; i++)
        {
            fillCoolDowns[i].fillAmount = endcoolDownSpell;
        }

    }

    private void Update()
    {
        if (startCoolDownSpell > 0)
        {
            startCoolDownSpell -= Time.deltaTime;
            tikResetSpells();

            if (startCoolDownSpell <= 0)
            {
                startCoolDownSpell = 0;
                activateCooldown(false);

                gameManager.TigerSpeed = speed_min;
                touchInput.SpellOneWayActive = false;


            }

        }
    }


    public void hp_Resurected()
    {
        if (startCoolDownSpell <= 0)
        {
            activateCooldown(true);
            startCoolDownSpell = endcoolDownSpell;

            upTiger.healHP(Hp_resurected);
            upTiger.activeParticleSpell(ParticleController.particleSystems[0]);

            downTiger.healHP(Hp_resurected);
            downTiger.activeParticleSpell(ParticleController.particleSystems[0]);

        }

    }

    public void speedStiger()
    {
        if (startCoolDownSpell <= 0)
        {
            activateCooldown(true);
            startCoolDownSpell = endcoolDownSpell;

            gameManager.TigerSpeed += speedAdd;

            upTiger.activeParticleSpell(ParticleController.particleSystems[1]);
            downTiger.activeParticleSpell(ParticleController.particleSystems[1]);
        }
    }

    public void oneWayTigers()
    {
        if (startCoolDownSpell <= 0)
        {
            activateCooldown(true);
            startCoolDownSpell = endcoolDownSpell;

            touchInput.SpellOneWayActive = true;

            upTiger.activeParticleSpell(ParticleController.particleSystems[2]);
            downTiger.activeParticleSpell(ParticleController.particleSystems[2]);

        }
    }

    public void resetTime()
    {
        if (startCoolDownSpell <= 0)
        {
            activateCooldown(true);
            startCoolDownSpell = endcoolDownSpell;

            gameManager.reset_backStage();

            upTiger.activeParticleSpell(ParticleController.particleSystems[3]);
            downTiger.activeParticleSpell(ParticleController.particleSystems[3]);

        }
    }

    private void tikResetSpells()
    {
        for (int i = 0; i < fillCoolDowns.Count; i++)
        {
            float normalizedValue = startCoolDownSpell / endcoolDownSpell;
            fillCoolDowns[i].fillAmount = normalizedValue;
            fillText[i].text = "" + (int)startCoolDownSpell;
        }
    }

    private void activateCooldown(bool isActivate)
    {
        for (int i = 0; i < fillCoolDowns.Count; i++)
        {
            fillCoolDowns[i].gameObject.SetActive(isActivate);
            fillText[i].text = "" + endcoolDownSpell;
        }
    }

}
