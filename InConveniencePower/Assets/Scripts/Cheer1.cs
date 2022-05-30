using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheer1 : MonoBehaviour
{
    public AudioClip SE;
    AudioSource audioSource;

    public GameObject Sign;
    public GameObject Sign2;
    public GameObject Sign3;
    public GameObject Sign4;

    public int B;

    public GameObject Hantei;
    HanteiScript script;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Hantei = GameObject.Find("CheerHantei");
        script = Hantei.GetComponent<HanteiScript>();
        Sign.SetActive(false);
        Sign2.SetActive(false);
        Sign3.SetActive(false);
        Sign4.SetActive(false);

    }

    private void Update()
    {
        Off();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "customer" && script.check == false)
        {
            //Debug.Log(script.i);
            audioSource.PlayOneShot(SE);
            if (script.i == 0)
            {

                B = script.ran[script.i];
                //Debug.Log("‹q1 Men1");
                Sign.SetActive(true);
                Sign2.SetActive(true);
            }else if (script.i == 1)
            {
                B = script.ran[script.i];
                //Debug.Log("‹q1 Men2");
                Sign.SetActive(true);
                Sign3.SetActive(true);
            }else if (script.i == 2)
            {
                B = script.ran[script.i];
                //Debug.Log("‹q1 Men3");
                Sign.SetActive(true);
                Sign4.SetActive(true);
            }
        }

        script.i = 0;
    }

    void Off()
    {
        if (script.check == true)
        {
            Sign.SetActive(false);
            Sign2.SetActive(false);
            Sign3.SetActive(false);
            Sign4.SetActive(false);
        }
    }
}
