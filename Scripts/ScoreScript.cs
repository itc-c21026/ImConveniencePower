using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int testScore;
    public Text scoreTextUI;

    public ScoreImage[] numberis;

    public GameObject Pl;
    Plate Script;


    // Start is called before the first frame update
    void Start()
    {
        Pl = GameObject.Find("Plate");
        Script = Pl.GetComponent<Plate>();
    }

    // Update is called once per frame
    void Update()
    {
        testScore = Script.Sc;
        string scoreText = testScore + "";
        scoreTextUI.text = scoreText;

        string[] getScoreOne = new string[3];
        int numberKeta = scoreText.Length;

        for (int i = 0; i <= numberKeta; i++)
        {
            if (i < numberKeta)
            {
                getScoreOne[i] = scoreText.Substring(scoreText.Length - (i + 1), 1);
                numberis[i].nowNumber = int.Parse(getScoreOne[i]);
            }
        }
    }
}
