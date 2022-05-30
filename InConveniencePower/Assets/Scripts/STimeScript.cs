using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class STimeScript : MonoBehaviour
{
    public GameObject Ca;
    public GameObject Sorp;
    public GameObject GameCtrL;

    public AudioClip SE;
    AudioSource audioSource;
    int s = 0;

    //public CanvasRenderer[] ST;
    public GameObject[] ST;

    public GameObject Pl;
    Plate script;

    public int testTime;
    float b = 0;
    float c = 0;

    public Text TimeTextUI;

    public Text FinishText;

    public STimeImage[] numberis;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Pl = GameObject.Find("Plate");
        script = Pl.GetComponent<Plate>();

        Application.targetFrameRate = 30;
        testTime = 180;
    }

    // Update is called once per frame
    void Update()
    {

        c += Time.deltaTime;
        b += Time.deltaTime;
        if (b >= 1)
        {
            testTime--;
            b = 0;
        }

        string TimeText = testTime + "";
        TimeTextUI.text = TimeText;

        string[] getTimeOne = new string[3];
        int numberKeta = TimeText.Length;

        for (int i = 0; i <= numberKeta; i++)
        {
            if (i < numberKeta)
            {
                getTimeOne[i] = TimeText.Substring(TimeText.Length - (i + 1), 1);
                numberis[i].nowNumber = int.Parse(getTimeOne[i]);
            }
        }

        if (testTime < 100)
        {
            Destroy(ST[0]);
            //ST[1].SetAlpha(0);
        }
        
        if (testTime < 10)
        {
            Destroy(ST[1]);
            //ST[0].SetAlpha(0);
        }

        if (testTime == 0)
        {
            b -= 100;
        }

        if (testTime == 29 && s == 0)
        {
            audioSource.PlayOneShot(SE);

            s++;
        }

        if (testTime == 0)
        {
            if (PlayerPrefs.GetInt("HighScore") < script.Sc)
            {
                PlayerPrefs.SetInt("HighScore", script.Sc);
            }

            Ca = GameObject.Find("Main Camera");
            Ca.GetComponent<GyroScript>().enabled = false;
            Sorp = GameObject.Find("GameObject");
            Sorp.GetComponent<sorption>().enabled = false;
            GameCtrL = GameObject.Find("GameController");
            GameCtrL.GetComponent<Swipe>().enabled = false;


            FinishText.text = "‚Ö‚¢‚Ä‚ñ";

            Invoke("scen", 2f);
        }
    }

    void scen()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
