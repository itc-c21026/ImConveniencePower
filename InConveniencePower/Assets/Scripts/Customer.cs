using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    GameObject Hantei;
    HanteiScript script;

    GameObject Pl;
    Plate script2;

    private NavMeshAgent agent;     //エージェントとなるオブジェクトのNavMeshAgent格納用 
    public bool GoalHantei = true;
    public int d = 3;
    
    float e;
    float b;

    int a;

    float c = 0;
    float f = 0;

    bool bl = true;
    // Use this for initialization
    void Start()
    {
        d = 0;
        Application.targetFrameRate = 30;

        Hantei = GameObject.Find("CheerHantei");
        script = Hantei.GetComponent<HanteiScript>();
        Pl = GameObject.Find("Plate");
        script2 = Pl.GetComponent<Plate>();
        //エージェントのNaveMeshAgentを取得する
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {

        e += Time.deltaTime;

        CTM();
        E();
        //Debug.Log(a);
        Ro();

        if (bl == true)
        {
            Transform myTF = transform;
            Vector3 pos = myTF.position;
            pos.x = 25.0f;
            pos.y = 2.0f;
            pos.z = 12.0f;
            myTF.position = pos;
            bl = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (GoalHantei == true)
        {
            if (other.gameObject.tag == "Hantei")
            {
                if (script.check == true)
                {
                    d = script.a;                  
                }
            }
        }

        if (other.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Cheer")
        {
            a = 1;
        }
    }

    void CTM()
    {
        if (d == 0)
        {
            Vector3 Goal = new Vector3(6, 0, -10);
            agent.destination = Goal;
        }
        else if(GoalHantei == true)
        {
            Vector3 GoalHuntei = new Vector3(18, 0, 8);
            agent.destination = GoalHuntei;
        }
    }

    void E()
    {

        if (e >= 999)
        {
            if (d == 0)
            {
                script.check = true;
            }
            d = 4;
            e = 0;
            GoalHantei = false;
        }
        
        if (script2.exi == true)
        {
            if (d == 0)
            {
                GoalHantei = false;
                script.check = true;
                d = 4;
                script2.exi = false;
            }

        }
        if (d == 4)
        {
            exit();
        }
    }

    void exit()
    {
        Vector3 Exit = new Vector3(-11, 0, 10);
        agent.destination = Exit;
    }

    private void Ro()
    {
        if (a == 1)
        {
            /*c += Time.deltaTime;
            if (c >= 0.2)
            {
                f += 0.5f;
                c = 0;
            }*/
            // transformを取得
            Transform myTransform = this.transform;
            // ワールド座標を基準に、回転を取得
            Vector3 localAngle = myTransform.localEulerAngles;
            //Debug.Log("yeah");
            localAngle.y = 180.0f;
            myTransform.eulerAngles = localAngle; // 回転角度を設定

            b += Time.deltaTime;

            if (b >= 3)
            {
                b = 0;
                a = 0;
            }
            /*if (f == 0.5)
            {
                worldAngle.y = -158.0f;
            }
            else if (f == 1.0f)
            {
                worldAngle.y = -161.0f;
            }
            else if (f == 1.5f)
            {
                worldAngle.y = -166.0f;
            }
            else if (f == 2.0f)
            {
                worldAngle.y = -171.0f;
            }
            else if (f == 2.5f)
            {
                worldAngle.y = -175.0f;
            }
            else if (f == 3.0f)
            {
                worldAngle.y = -178.0f;
            }
            else if (f == 3.5f)
            {
                worldAngle.y = -180.0f;
                a = 0;
            }*/
        }

    }
}
