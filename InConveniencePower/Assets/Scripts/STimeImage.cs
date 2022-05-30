using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STimeImage : MonoBehaviour
{
    public CanvasRenderer[] NumberCR;

    public int nowNumber;
    int oldNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        AllClear();
        oldNumber = nowNumber;
        nowNunbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldNumber != nowNumber)
        {
            nowNunbers();
            oldNumber = nowNumber;
        }

        if (nowNumber >= 10 || nowNumber <= -1)
        {
            AllClear();
        }
    }

    void AllClear()
    {
        foreach (CanvasRenderer nowCR in NumberCR)
        {
            nowCR.SetAlpha(0);
        }
    }
    void nowNunbers()
    {
        NumberCR[oldNumber].SetAlpha(0);
        NumberCR[nowNumber].SetAlpha(1);
    }
}
