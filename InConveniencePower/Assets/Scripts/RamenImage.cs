using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamenImage : MonoBehaviour
{
    public GameObject Sign;
    public GameObject Sign2;
    public GameObject Sign3;

    public GameObject Hantei;
    HanteiScript script;

    private void Start()
    {
        Hantei = GameObject.Find("CheerHantei");
        script = Hantei.GetComponent<HanteiScript>();
        Sign.SetActive(false);
        Sign2.SetActive(false);
        Sign3.SetActive(false);

    }

    private void Update()
    {
        Off();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "customer" && script.check == false)
        {
            Sign.SetActive(true);
        }else if (other.gameObject.tag == "customer" && script.check2 == false)
        {
            Sign2.SetActive(true);
        }if(other.gameObject.tag == "customer" && script.check3 == false)
        {
            Sign3.SetActive(true);
        }
    }

    void Off()
    {
        if (script.check == true)
        {
            Sign.SetActive(false);
        }

        if (script.check2 == true)
        {
            Sign2.SetActive(false);
        }

        if (script.check3 == true)
        {
            Sign3.SetActive(false);
        }
    }
}
