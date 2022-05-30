using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public AudioClip Atari;
    AudioSource audioSource;
    public AudioClip Okane;
    public AudioClip Hazure;

    public GameObject ParticleObj;

    public GameObject Utuwa;

    public GameObject Che;
    Cheer1 script;

    public GameObject Spw;
    SpawnScript script3;

    public string targetTag;

    public bool exi;

    public int Sc = 0;

    int i;

    //GameObject obj;
//float b;
private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //Utuwa = GameObject.FindGameObjectWithTag("Ramen");
        //Application.targetFrameRate = 30;

        exi = false;

        Che = GameObject.Find("Cheer");
        script = Che.GetComponent<Cheer1>();
        Spw = GameObject.Find("DonburiSpawn");
        script3 = Spw.GetComponent<SpawnScript>();
    }
        //obj = GameObject.FindGameObjectWithTag("Ramen");

        /*b += Time.deltaTime;
        if (b >= 2)
        {
            Debug.Log("Plateトッピング" + script2.Topping);
            b = 0;
        }*/
        //Debug.Log(scrip.topping);
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("abc");
        if (collision.gameObject.tag == targetTag)
        {
            //Debug.Log("abc");
            //Destroy(gameObject);
            //Debug.Log("客1 " + script.B + " トッピング " + script3.a[0]);
            i++;
            if (script.B/* == 1 */== script3.a[0])
            {
                audioSource.PlayOneShot(Atari);
                audioSource.PlayOneShot(Okane);
                var instantiateEffect = GameObject.Instantiate(ParticleObj, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(instantiateEffect, 1f);
                Sc += 175;
                TrFa();
            }else if (script.B != script3.a[0])
            {
                audioSource.PlayOneShot(Hazure);
                Sc -= 50;
                if(Sc < 0)
                {
                    Sc = 0;
                }
                TrFa();
            }
        }
    }

    public void TrFa()
    {
        exi = true;
        /*foreach (GameObject Ra in objects)
        {
            Destroy(Ra);
        }*/
        script3.RamenspwanCnt = 1;
        script3.a[0] = 0;
    }
}
