using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramen : MonoBehaviour
{
    public AudioClip SE;
    AudioSource audioSource;

    public GameObject Spw;
    SpawnScript script;

    /*string s = "0000000";
    string s1;
    string s2;
    string s3;
    string s4;
    string s5;
    string s6;
    string s7;*/

    //public GameObject Top;
    //top script2;

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
        //score();
        //GetComponent<Collider>().gameObject.GetComponent<top>().Ts = Topping;
        /*b += Time.deltaTime;
        if (b >= 2)
        {
            Debug.Log("Ramenトッピング" + topping);
            b = 0;
        }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plate") Destroy(gameObject);
        if (collision.gameObject.tag == "Trash") Destroy(gameObject);

        if (collision.gameObject.tag == t && T == 0)
        {
            audioSource.PlayOneShot(SE);
            T++;
            fo();
            //Topping += 100000;
            //Debug.Log(Topping);
            Men1.enabled = true;
            Men1.GetComponent<Renderer>().enabled = true;
        }else if (collision.gameObject.tag == t4 && T4 == 0)
        {
            audioSource.PlayOneShot(SE);
            T4++;
            fo1();
            //Topping += 1000000;
            //Debug.Log(Topping);
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
                //Topping += 1;
                //Debug.Log(Topping);
                C1.enabled = true;
                C1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t3 && T3 == 0)
            {
                audioSource.PlayOneShot(SE);
                T3++;
                fo3();
                //Topping += 10;
                //Debug.Log(Topping);
                N1.enabled = true;
                N1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t5 && T5 == 0)
            {
                audioSource.PlayOneShot(SE);
                T5++;
                fo4();
                //Topping += 100;
                //Debug.Log(Topping);
                M1.enabled = true;
                M1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t6 && T6 == 0)
            {
                audioSource.PlayOneShot(SE);
                T6++;
                fo5();
                //Topping += 1000;
                //Debug.Log(Topping);
                A1.enabled = true;
                A1.GetComponent<Renderer>().enabled = true;
            }
            else if (collision.gameObject.tag == t7 && T7 == 0)
            {
                audioSource.PlayOneShot(SE);
                T7++;
                fo6();
                //Topping += 10000;
                //Debug.Log(Topping);
                n1.enabled = true;
                n1.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    void fo()
    {
        script.a[0] = Topping += 100000;
        /*for (int e = 0; e <= script.i; e++)
        {
            if(script.TrFas[e] == "true")
            {
                script.a[e] = Topping += 100000;
                break;
            }
        }*/
    }

    void fo1()
    {
        script.a[0] = Topping += 1000000;
        /*for (int f = 0; f <= script.i; f++)
        {
            
            if (script.TrFas[f] == "true")
            {
                script.a[f] = Topping += 1000000;
                break;
            }
        }*/
    }

    void fo2()
    {
        script.a[0] = Topping += 1;
        /*for (int g = 0; g <= script.i; g++)
        {
            if (script.TrFas[g] == "true")
            {
                script.a[g] = Topping += 1;
                break;
            }
        }*/
    }

    void fo3()
    {
        script.a[0] = Topping += 10;
        /*for (int h = 0; h <= script.i; h++)
        {
            if (script.TrFas[h] == "true")
            {
                script.a[h] = Topping += 10;
                break;
            }
        }*/
    }

    void fo4()
    {
        script.a[0] = Topping += 100;
        /*for (int j = 0; j <= script.i; j++)
        {
            if (script.TrFas[j] == "true")
            {
                script.a[j] = Topping += 100;
                break;
            }
        }*/
    }

    void fo5()
    {
        script.a[0] = Topping += 1000;
        /*for (int k = 0; k <= script.i; k++)
        {
            if (script.TrFas[k] == "true")
            {
                script.a[k] = Topping += 1000;
                break;
            }
        }*/
    }

    void fo6()
    {
        script.a[0] = Topping += 10000;
        /*for (int l = 0; l <= script.i; l++)
        {
            if (script.TrFas[l] == "true")
            {
                script.a[l] = Topping += 10000;
                break;
            }
        }*/
    }

    /*void score()
    {
        s = Topping.ToString();
        s1 = s.Substring(0, 1);
        s2 = s.Substring(1, 1);
        s3 = s.Substring(2, 1);
        s4 = s.Substring(3, 1);
        s5 = s.Substring(4, 1);
        s6 = s.Substring(5, 1);
        s7 = s.Substring(6, 1);

        if (s1 == "2") Topping -= 1000000;

        if (s2 == "2") Topping -= 100000;

        if (s3 == "2") Topping -= 10000;

        if (s4 == "2") Topping -= 1000;

        if (s5 == "2") Topping -= 100;

        if (s6 == "2") Topping -= 10;

        if (s7 == "2") Topping -= 1;
    }*/
}
