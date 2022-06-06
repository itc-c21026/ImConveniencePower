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
    
private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        exi = false;

        Che = GameObject.Find("Cheer");
        script = Che.GetComponent<Cheer1>();
        Spw = GameObject.Find("DonburiSpawn");
        script3 = Spw.GetComponent<SpawnScript>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            i++;
            if (script.B == script3.a[0])
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
        script3.RamenspwanCnt = 1;
        script3.a[0] = 0;
    }
}
