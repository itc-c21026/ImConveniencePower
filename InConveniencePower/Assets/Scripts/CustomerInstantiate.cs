using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInstantiate : MonoBehaviour
{
    public GameObject ins;
    HanteiScript scr;

    public GameObject prefab;

    public GameObject customer;
    public GameObject customer2;
    public GameObject customer3;

    int i = 0;
    int c;

    float a = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;

        ins = GameObject.Find("CheerHantei");
        scr = ins.GetComponent<HanteiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        tim();

        //Debug.Log(scr.check);
        //Debug.Log(a);
    }

    public void instantiate()
    {
        c = Random.Range(0, 3);
        if (c == 0)
        {
            customer = Instantiate(customer, new Vector3(25, 2, 12), Quaternion.identity);
        }else if (c == 1)
        {
            customer2 = Instantiate(customer2, new Vector3(25, 2, 12), Quaternion.identity);
        }else if (c == 2)
        {
            customer3 = Instantiate(customer3, new Vector3(25, 2, 12), Quaternion.identity);
        }
    }

    void tim()
    {
        if (i == 0)
        {
            //Debug.Log("a");
            instantiate();
            i = 1;
        }

        if (i == 1 && a >= 10)
        {
            a = 0;
            i = 0;
        }

        if (scr.check == false)
        {
            i = 2;
        } else if (scr.check == true && i == 2)
        {
            //Debug.Log("i");
            i = 1;
        }
    }
}
