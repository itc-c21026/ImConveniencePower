using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class sorption : MonoBehaviour
{
    [SerializeField]
    private GameObject effectObject;

    [SerializeField]
    private float deleteTime = 0.1f;

    float c;

    public AudioClip Tap;
    AudioSource audioSource;

    public GameObject prefab;

    public GameObject obj;

    public string t;
    public string t2;
    public string t3;
    public string t4;
    public string t5;
    public string t6;
    public string t7;
    public string t8;

    string tz;
    string tz2;
    string tz3;
    string tz4;
    string tz5;
    string tz6;
    string tz7;
    string tz8;

    int sorpCnt;

    float longTapTime = 0.1f;
    float nowTapTime;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        

        tz = t;
        tz2 = t2;
        tz3 = t3;
        tz4 = t4;
        tz5 = t5;
        tz6 = t6;
        tz7 = t7;
        tz8 = t8;

        Application.targetFrameRate = 30;
    }
    void Update()
    {

        c += Time.deltaTime;

        if (nowTapTime == 0)
        {
            sorpCnt = 0;
        }

        if (sorpCnt == 0)
        {
            target();
        }

        if (Input.GetMouseButton(0))
        {
            nowTapTime++;
        }

        if (Input.GetMouseButtonUp(0))
        {
            nowTapTime = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 3f;
            GameObject clone = Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition),
                Quaternion.identity);
            Destroy(clone, deleteTime);

            audioSource.PlayOneShot(Tap);
        }
    }
    void OnTriggerStay(Collider other)
    {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();


            Vector3 direction = other.gameObject.transform.position - transform.position;
            direction.Normalize();

            if (other.gameObject.tag == t || other.gameObject.tag == t2 || other.gameObject.tag == t3 || other.gameObject.tag == t4 || other.gameObject.tag == t5 || other.gameObject.tag == t6 || other.gameObject.tag == t7 || other.gameObject.tag == t8)
            {
                if (other.gameObject.tag == t)
                {
                    // PC(テスト用)
                    if (Input.GetKey(KeyCode.Space))
                    {
                    effec();
                    T1();
                        r.velocity *= 0.9f;
                        r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                    }
                    
                    // タップ
                    if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                    {
                    effec();
                    T1();
                    r.velocity *= 0.9f;
                        r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                    }
                    // 2本指で画面タップしてもそのままの状態で操作できる
                    else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                    {
                    effec();
                    T1();
                    r.velocity *= 0.9f;
                        r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                    }
                }

            else if (other.gameObject.tag == t2)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    effec();
                    T2();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }

                if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                {
                    effec();
                    T2();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
                else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                {
                    effec();
                    T2();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
            }
            else if (other.gameObject.tag == t3)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    effec();
                    T3();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }

                if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                {
                    effec();
                    T3();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
                else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                {
                    effec();
                    T3();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
            }
            else if (other.gameObject.tag == t4)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    effec();
                    T4();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }

                if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                {
                    effec();
                    T4();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
                else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                {
                    effec();
                    T4();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
            }
            else if (other.gameObject.tag == t5)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    effec();
                    T5();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }

                if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                {
                    effec();
                    T5();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
                else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                {
                    effec();
                    T5();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
            }
            else if (other.gameObject.tag == t6)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    effec();
                    T6();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }

                if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                {
                    effec();
                    T6();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
                else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                {
                    effec();
                    T6();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
            }
            else if (other.gameObject.tag == t7)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    effec();
                    T7();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }

                if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                {
                    effec();
                    T7();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
                else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                {
                    effec();
                    T7();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
            }
            else if (other.gameObject.tag == t8)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    effec();
                    T8();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }

                if (nowTapTime >= longTapTime && Input.mousePosition.x >= Screen.width / 2)
                {
                    effec();
                    T8();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
                else if (nowTapTime >= longTapTime && Input.touchCount >= 2)
                {
                    effec();
                    T8();
                    r.velocity *= 0.9f;
                    r.AddForce(direction * -20.2f, ForceMode.Acceleration);
                }
            }
        }
        
    }
    void target()
    {
        t = tz;
        t2 = tz2;
        t3 = tz3;
        t4 = tz4;
        t5 = tz5;
        t6 = tz6;
        t7 = tz7;
        t8 = tz8;
    }

    void T1()
    {
        sorpCnt++;
        t2 = null;
        t3 = null;
        t4 = null;
        t5 = null;
        t6 = null;
        t7 = null;
        t8 = null;
    }

    void T2()
    {
        sorpCnt++;
        t = null;
        t3 = null;
        t4 = null;
        t5 = null;
        t6 = null;
        t7 = null;
        t8 = null;
    }

    void T3()
    {
        sorpCnt++;
        t = null;
        t2 = null;
        t4 = null;
        t5 = null;
        t6 = null;
        t7 = null;
        t8 = null;
    }

    void T4()
    {
        sorpCnt++;
        t = null;
        t2 = null;
        t3 = null;
        t5 = null;
        t6 = null;
        t7 = null;
        t8 = null;
    }

    void T5()
    {
        sorpCnt++;
        t = null;
        t2 = null;
        t3 = null;
        t4 = null;
        t6 = null;
        t7 = null;
        t8 = null;
    }

    void T6()
    {
        sorpCnt++;
        t = null;
        t2 = null;
        t3 = null;
        t4 = null;
        t5 = null;
        t7 = null;
        t8 = null;
    }

    void T7()
    {
        sorpCnt++;
        t = null;
        t2 = null;
        t3 = null;
        t4 = null;
        t5 = null;
        t6 = null;
        t8 = null;
    }

    void T8()
    {
        sorpCnt++;
        t = null;
        t2 = null;
        t3 = null;
        t4 = null;
        t5 = null;
        t6 = null;
        t7 = null;
    }

    void effec()
    {
        if (c >= 0.5)
        {
            var instantiateEffect = GameObject.Instantiate(effectObject, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            Destroy(instantiateEffect, deleteTime);
            c = 0;
        }
    }
}
