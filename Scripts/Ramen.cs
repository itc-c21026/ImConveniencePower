using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramen : MonoBehaviour
{
    public AudioClip SE;
    AudioSource audioSource;

    public GameObject Spw;
    SpawnScript script;

    //麺
    [SerializeField] Renderer Men1;
    //チャーシュー
    [SerializeField] Renderer C1;
    //のり
    [SerializeField] Renderer N1;
    //スープ
    [SerializeField] Renderer S1;
    //めんま
    [SerializeField] Renderer M1;
    //味玉
    [SerializeField] Renderer A1;
    //ナルト
    [SerializeField] Renderer n1;

    public string t;
    public string t2;
    public string t3;
    public string t4;
    public string t5;
    public string t6;
    public string t7;

    int T;
    int T2;
    int T3;
    int T4;
    int T5;
    int T6;
    int T7;

    public int Topping;

    //float b;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Spw = GameObject.Find("DonburiSpawn");
        script = Spw.GetComponent<SpawnScript>();

        //Application.targetFrameRate = 30;

        Men1.enabled = false;
        Men1.GetComponent<Renderer>().enabled = false;

        C1.enabled = false;
        C1.GetComponent<Renderer>().enabled = false;

        N1.enabled = false;
        N1.GetComponent<Renderer>().enabled = false;

        S1.enabled = false;
        S1.GetComponent<Renderer>().enabled = false;

        M1.enabled = false;
        M1.GetComponent<Renderer>().enabled = false;

        A1.enabled = false;
        A1.GetComponent<Renderer>().enabled = false;

        n1.enabled = false;
        n1.GetComponent<Renderer>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plate") Destroy(gameObject);
        if (collision.gameObject.tag == "Trash") Destroy(gameObject);

        if (collision.gameObject.tag == t && T == 0)
        {
            audioSource.PlayOneShot(SE);
            T++;
            fo();
            Men1.enabled = true;
            Men1.GetComponent<Renderer>().enabled = true;
        }else if (collision.gameObject.tag == t4 && T4 == 0)
        {
            audioSource.PlayOneShot(SE);
            T4++;
            fo1();
            S1.enabled = true;
            S1.GetComponent<Renderer>().enabled = true;
        }

        if (Topping >= 1100000)
        {
            if (collision.gameObject.tag == t2 && T2 == 0)
            {
                audioSource.PlayOneShot(SE);
                T2++;
                fo2();
                C1.enabled = true;
                C1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t3 && T3 == 0)
            {
                audioSource.PlayOneShot(SE);
                T3++;
                fo3();
                N1.enabled = true;
                N1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t5 && T5 == 0)
            {
                audioSource.PlayOneShot(SE);
                T5++;
                fo4();
                M1.enabled = true;
                M1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t6 && T6 == 0)
            {
                audioSource.PlayOneShot(SE);
                T6++;
                fo5();
                A1.enabled = true;
                A1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t7 && T7 == 0)
            {
                audioSource.PlayOneShot(SE);
                T7++;
                fo6();
                n1.enabled = true;
                n1.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    void fo()
    {
        script.a[0] = Topping += 100000;
    }

    void fo1()
    {
        script.a[0] = Topping += 1000000;
    }

    void fo2()
    {
        script.a[0] = Topping += 1;
    }

    void fo3()
    {
        script.a[0] = Topping += 10;
    }

    void fo4()
    {
        script.a[0] = Topping += 100;
    }

    void fo5()
    {
        script.a[0] = Topping += 1000;
    }

    void fo6()
    {
        script.a[0] = Topping += 10000;
    }
}
