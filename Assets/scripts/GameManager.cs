using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public Animator       myPlayerAnim     = default;

    public ParticleSystem myPlayerPartical = default;
    public ParticleSystem MMsParticual     = default;

    public AudioSource  eatMMsSound    = default;
    public AudioSource  eatYummysSound = default;
    public AudioSource  powerUpSound   = default;
    public AudioSource  gameoverSound  = default;
    public AudioSource  endGameSound   = default;
    public AudioSource  gameMusic      = default;
    //it can be a array(sounds)
    public Text         inGameScoreText       = default;
    public Text         endLevelScoreText     = default;
    public Text         endLevelHighscoreText = default;

    List<GameObject>    MyYummys = new List<GameObject>();
   
    PlayerUpDown        playerUpDown=default;

    private GameObject  Player                  = default;
    public  GameObject  endLevelScreen          = default;
    public  GameObject  endLevelSection         = default;
    public  GameObject  gameOverSection         = default;
    public  GameObject  inGameScoreScreen       = default;
    public  GameObject  endGameFigur            = default;


    int        score              = 0;
    public int WhatistheNextLevel = 1;

    [HideInInspector]
    public byte endLineMultiplier = 1;

    private void OnEnable()
    {
        Camera.main.GetComponent<WinTurn>().enabled = false;
        //enabled it when we are win
    }
    void Start()
    {
        MyYummys.Add( GameObject.FindGameObjectWithTag("FirstCube"));

        playerUpDown = GameObject.FindGameObjectWithTag("PlayerCapsule").GetComponent<PlayerUpDown>();

        Player = GameObject.FindGameObjectWithTag("Player");

        //I didnt check uı and object in here because ı manuelly did it


    }


    /// <summary>
    /// For yummys things in here
    /// </summary>
    #region yummys region
    /// <summary>
    /// move up the yummys because new yummy adding our family
    /// </summary>
    public void moveYummysUp()
    {
        playerUpDown.GoUp();         //move up the my player(capsule)
     //
        for (int i = 0; i < MyYummys.Count; i++)
        {
            MyYummys[i].transform.localPosition = new Vector3(0,
                MyYummys[i].transform.localPosition.y + 0.51f, 0);
        }
        myPlayerAnim.SetBool("Jump", true);
        StartCoroutine(Wait());
    }
    //
    void AddTheList(GameObject yummys)
    {
        MyYummys.Add(yummys);

        //Do some particul
       
        EatYummysSound();//do some sound effects
    }
    //
    public void RemoveTheList(GameObject yummys)
    {
        MyYummys.Remove(yummys);
    }
    //
    public bool IsThatSameYummys(GameObject yummys)
    {
        //if interact the same yummy dont do the operation
        return MyYummys[MyYummys.Count - 1] != yummys;
    }
    //
    public void MoveMyNewYummyBase(GameObject yummys)
    {
       yummys.transform.parent = Player.transform;   //do it child because it travel with us
       //
       yummys.transform.localPosition = Vector3.zero;//move the base
       //
       AddTheList(yummys);
    }
    //
    #endregion yummys region

    /// <summary>
    /// M&M's things do in it here
    /// </summary>
    #region MMs region
    public void EatTheMMs()
    {
        score++;
        //score refresh on the screen
       
        DoParticulForMMs();//do some effect
        EatMMsSound();// do some sound effect
        RefreshTheScore();
    }
    #endregion MMs region

    /// <summary>
    /// particule section
    /// </summary>
    #region particul

    void DoParticulForPlayer()
    {
        myPlayerPartical.Play(true);
    }
    void DoParticulForMMs()
    {
        MMsParticual.Play(true);
    }

    #endregion particul

    /// <summary>
    /// Control the sounds in here
    /// </summary>
    #region Sounds

    void EatYummysSound()
    {
        eatYummysSound.Play();
    }
    void EatMMsSound()
    {
        eatMMsSound.Play();
    }
    void EndLevelSound()
    {
        MuteGameMusic();
        endGameSound.Play();
    }
    public void PowerUpSound()
    {
        powerUpSound.Play();
    }
    void GomeobeSound()
    {
        MuteGameMusic();
        gameoverSound.Play();
    }
    public void MuteGameMusic()
    {
        gameMusic.Stop();
    }
    #endregion Sounds

    /// <summary>
    /// Control the uı elements in here
    /// </summary>
    /// <param name="arrows"></param>
    #region UIwork



    public void DisableArrows(GameObject arrows)
    {
        arrows.SetActive(false);
    }
    void RefreshTheScore()
    {
        Debug.Log(score);
        inGameScoreText.text = score.ToString();
    }
    void EndLevelScreen()
    {

        //
        endLevelScreen.SetActive(true);
        endGameFigur.SetActive(true);
        //


    }
    void DisableIngameScore()
    {
        inGameScoreScreen.SetActive(false);//dont show in game
    }
    void GameOverScreen()
    {
        gameOverSection.SetActive(true);
    }
    #endregion UIwork


    /// <summary>
    /// Control some bişiler in here
    /// </summary>
    #region GameMechanik
    //
    public void GameOver()
    {
        EndLevel();

        GameOverScreen();
        GomeobeSound();

        myPlayerAnim.SetBool("Die", true);
        StartCoroutine(Wait());
        Debug.Log("Game Overr");
    }
    //
    public void WinTheLevel()
    {
        EndLevel();
        EndLevelScreen();
        //
        endLevelSection.SetActive(true);
        //
        DoParticulForPlayer();
        playerUpDown.GoUp();
        EndLevelSound();//cheer sound

        myPlayerAnim.SetBool("Cheer", true);
       

        Camera.main.GetComponent<WinTurn>().enabled = true;
    }
    //
    void EndLevel()
    {
        DisableIngameScore();
        StopThePlayer();
        //
        ScoreCalculator();
        EndLevelScreen();


    }
    //
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    //
    public void NextLevel()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene(WhatistheNextLevel);
    }
    //
    int HighscoreCalculator(int EndScore)
    {
        int high = PlayerPrefs.GetInt("Highscore");
        if (high< EndScore)
        {
           PlayerPrefs.SetInt("Highscore", EndScore);
            return EndScore;
        }else
        {
            return high;
        }
       
    }
    //
    void ScoreCalculator()
    {
        int myScore = score * endLineMultiplier;
        endLevelScoreText.text = (myScore).ToString();
        endLevelHighscoreText.text = HighscoreCalculator(myScore).ToString();
    }
    //
    void StopThePlayer()
    {
        Player.GetComponent<Move>().enabled = false;
        Player.GetComponent<MovePlayer>().enabled = false;
    }
    //

    #endregion GameMekhancs
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        myPlayerAnim.SetBool("Jump", false);
        myPlayerAnim.SetBool("Die", false);
    }

}
