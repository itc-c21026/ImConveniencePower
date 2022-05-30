using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public AudioClip ButtonSE;
    AudioSource audioSource;

    public Text highScoreText;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // �n�C�X�R�A��\��
        highScoreText.text = "�͂������� " + PlayerPrefs.GetInt("HighScore");
    }

    public void OnStartButtonClicked()
    {
        audioSource.PlayOneShot(ButtonSE);
        Invoke("gameplay", 1f);
    }

    public void OnTutorialButtonClicked()
    {
        audioSource.PlayOneShot(ButtonSE);
        Invoke("tutorial", 1f);
    }

    void gameplay()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    void tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
