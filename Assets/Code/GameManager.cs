using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Level> Level = new List<Level>();

    public Text LogError;
    public TextMeshProUGUI textLevel;

    public static GameManager instance;
    public int counterKnife;

    public GameObject panelPause;
    public GameObject panelDefeat;
    public GameObject panelVictory;
    public GameObject panelWin;
    public GameObject knife;
    public GameObject woodParent;

    public Button pauseButton;
    public Button exitButton;
    public Button resumeButton;
    public Button btnShoot;

    Vector3 knifeVector = new Vector3(0, -15, 30);

    int listIndex;
    int manyknife;
    float knifeDistance = 0.8f;

    int stage;
    int levelCounetr;
    int listMaximum;

    public List<GameObject> listKnife = new List<GameObject>();
    public Vector3 temp;
    public TextMeshProUGUI score;
    public int record;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("Level"));
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    if (PlayerPrefs.GetInt("Level") == 0)

        //    {
        //    }
        //    else
        //    {
        //        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        //        Debug.Log("load   " + PlayerPrefs.GetInt("Level"));
        //    }
        //}

        // Debug.LogWarning("Start Player Prefs" + PlayerPrefs.GetInt("Level"));

        StageAandLevel();
        ButtnReAction();
        CreatListKnife();
        manyknife = listMaximum;

    }

    void Update()
    {
        ScoreText();
        WinOrLose();
    }

    void SetLevel1()
    {
        stage = Level[0].stage;
        listMaximum = Level[0].listMaximum;
        textLevel.text = Level[0].textLevel.ToString();
    }

    void SetLevel2()
    {
        stage = Level[1].stage;
        listMaximum = Level[1].listMaximum;
        textLevel.text = Level[1].textLevel.ToString();
    }

    void SetLevel3()
    {
        stage = Level[2].stage;
        listMaximum = Level[2].listMaximum;
        textLevel.text = Level[2].textLevel.ToString();
    }

    void SetLevel4()
    {
        stage = Level[3].stage;
        listMaximum = Level[3].listMaximum;
        textLevel.text = Level[3].textLevel.ToString();
    }

    void CreatListKnife()
    {
        temp = transform.position;
        temp.z += 0.5f;
        for (int i = 0; i < listMaximum; i++)
        {
            listKnife.Add(Instantiate(knife, temp, Quaternion.identity) as GameObject);
            temp.y -= knifeDistance;
        }
    }

    void FireKnife()
    {
        listKnife[listIndex].GetComponent<Shoot_Knife>().MoveKnife();
        listIndex++;
        manyknife--;

        Handheld.Vibrate();

        btnShoot.onClick.RemoveAllListeners();

        StartCoroutine(UpKnife());
    }

    IEnumerator UpKnife()
    {
        yield return new WaitForSeconds(0.1f);
        btnShoot.onClick.AddListener(() => FireKnife());
    }

    void ScoreText()
    {
        score.text = manyknife.ToString();
    }

    public void Defeat()
    {
        //SaveLevel();
        panelDefeat.SetActive(true);
        woodParent.SetActive(false);
    }

    public void Victory()
    {
        //SaveLevel();
        panelVictory.SetActive(true);
        woodParent.SetActive(false);
    }

    void ButtnReAction()
    {
        //btn.onClick.AddListener(() => MakeNewKnife()); // shoot knife
        btnShoot.onClick.AddListener(() => FireKnife()); // shoot knife
        pauseButton.onClick.AddListener(() => PausMenuAction()); //pause Game
        resumeButton.onClick.AddListener(() => ResumeButtonAction()); // resume Game
        exitButton.onClick.AddListener(() => ExitButtonAction()); //go to menu
    }

    void PausMenuAction()
    {
        panelPause.SetActive(true);
        woodParent.SetActive(false);
    }

    void ResumeButtonAction()
    {
        panelPause.SetActive(false);
        woodParent.SetActive(true);
    }

    void ExitButtonAction()
    {
        PlayerPrefs.SetInt("Level", 0);

        SceneManager.LoadScene(0);
    }

    public void RestartButtonAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NewGameAction()
    {
        SceneManager.LoadScene(sceneName: "Menu");
        PlayerPrefs.DeleteKey("Level");
    }

    void WinOrLose()
    {
        if (manyknife == 0 && counterKnife == listMaximum)
        {
            Victory();
        }
    }

    //void SaveLevel()
    //{
    //    PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    //    Debug.Log("SAVE  " + SceneManager.GetActiveScene().buildIndex);
    //    Debug.LogWarning("Player Prefs: " + PlayerPrefs.GetInt("Level"));
    //}

    void SaveRecord()
    {
        PlayerPrefs.SetInt("Record", record);
    }

    public void NextButtonAction()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (panelDefeat)
        {
            panelDefeat.SetActive(false);
        }
        if (panelVictory)
        {
            panelVictory.SetActive(false);
        }
        woodParent.SetActive(true);

        stage++;

        PlayerPrefs.SetInt("Level", stage);

        SceneManager.LoadScene(1);
    }

    public void StageAandLevel()
    {
        Debug.Log("Stage In Code : " + stage);

        //if (PlayerPrefs.HasKey("Stage"))
        //{
        //    PlayerPrefs.SetInt("Stage", stage);
        //}
        stage = PlayerPrefs.GetInt("Level");

        switch (stage)
        {
            case 0:
                stage++;
                //PlayerPrefs.SetInt("Stage", stage);
                SetLevel1();
                manyknife = listMaximum;
                break;

            case 1:
                stage++;
                SetLevel2();
                manyknife = listMaximum;
                break;

            case 2:
                stage++;
                SetLevel3();
                manyknife = listMaximum;
                break;

            case 3:
                stage++;
                SetLevel4();
                manyknife = listMaximum;
                break;

            case 4:
                stage++;
                record++;
                Debug.LogError("Win");
                SaveRecord();
                panelVictory.SetActive(false);
                panelDefeat.SetActive(false);
                woodParent.SetActive(false);
                pauseButton.enabled = false;
                panelWin.SetActive(true);
                break;
            default:
                LogError.text = "Fuck";
                LogError.color = Color.red;
                break;
        }

    }
}
