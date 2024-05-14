using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{


    private static GameManager instance;

    [SerializeField] GameObject PanelRestart;

    [SerializeField] TigerControlle upTiger;
    [SerializeField] TigerControlle downTiger;
    [SerializeField] Ball ball;
    [SerializeField] WallViser viser;

    private TextManager textManager;
    private CounterGoal goal;
    private Economica economica;
    private SpellManager spellManager;

    private int upScore = 0;
    private int downScore = 0;

    private int tigerSpeed = 18;


    public static GameManager Instance { get { return instance; } }
    public TextManager TextManager { get => textManager; set => textManager = value; }
    public int UpScore { get => upScore; set => upScore = value; }
    public int DownScore { get => downScore; set => downScore = value; }
    public TigerControlle UpTiger { get => upTiger; set => upTiger = value; }
    public TigerControlle DownTiger { get => downTiger; set => downTiger = value; }
    public int TigerSpeed { get => tigerSpeed; set => tigerSpeed = value; }
    public Ball _Ball { get => ball;}

    private void Awake()
    {
        instance = this;

        TextManager = GetComponent<TextManager>();
        goal = GetComponent<CounterGoal>();
        economica = GetComponent<Economica>();
        spellManager = GetComponent<SpellManager>();

    }

    private void Start()
    {
        TextManager.editMainGold(economica.GetCurrentGold());
    }


    public void resetGame()
    {

        UpScore = 0;
        DownScore = 0;

        reset_backStage();
        updateTextScore();
 
    }

    public void reset_backStage()
    {
        UpTiger.resetTiger();
        DownTiger.resetTiger();

        _Ball.speed = _Ball.Min_speed;
        _Ball.transform.position = _Ball.PosStart;
    }


    public void ballTouchWallTigers()
    {
        viser.createWall();
       
    }

    public void ballTouchAll()
    {
        _Ball.hitAnim();
        _Ball.activeParticleSpell(spellManager.ParticleController.particleSystems[4]);
    }

    public void startGame()
    {
        _Ball.strtBall();


        if (goal.isGoalLoose(upScore, downScore))
        {
            economica.SubtractGold(30);
        }
        else
        {
            economica.AddGold(25);
        }

        TextManager.editMainGold(economica.GetCurrentGold());

    }

    public void updateTextScore()
    {
        textManager.editUpCounter(UpScore);
        textManager.editDownCounter(DownScore);
    }    

    public void loseHP()
    {
        PanelRestart.SetActive(true);
    }

    public void upgradeButtone()
    {
        economica.SubtractGold(200);
        TextManager.editMainGold(economica.GetCurrentGold());
    }

}
