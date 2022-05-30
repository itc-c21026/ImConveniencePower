using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheer3 : MonoBehaviour
{
    public GameObject Sign;
    public GameObject Sign2;
    public GameObject Sign3;
    public GameObject Sign4;

    public int D;

    public GameObject Hantei;
    HanteiScript script;

    private void Start()
    {
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
        if (other.gameObject.tag == "customer" && script.check3 == false)
        {
            if(script.i == 0)
            {
                D = script.ran[script.i];
                Debug.Log("‹q3 Men1");
                Sign.SetActive(true);
                Sign2.SetActive(true);
            }else if(script.i == 1)
            {
                D = script.ran[script.i];
                Debug.Log("‹q3 Men2");
                Sign.SetActive(true);
                Sign3.SetActive(true);
            }else if(script.i == 2)
            {
                D = script.ran[script.i];
                Debug.Log("‹q3 Men3");
                Sign.SetActive(true);
                Sign4.SetActive(true);
            }
        }

        script.i = 0;
    }

    void Off()
    {
        if (script.check3 == true)
        {
            Sign.SetActive(false);
            Sign2.SetActive(false);
            Sign3.SetActive(false);
            Sign4.SetActive(false);
        }
    }
}
