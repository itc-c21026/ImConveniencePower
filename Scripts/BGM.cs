using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public float PitchS;

    public GameObject STim;
    STimeScript script;
    
    public AudioClip bgm;
    AudioSource audioSource;

    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        PitchS = 1;
        STim = GameObject.Find("NumberFs");
        script = STim.GetComponent<STimeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Pitch();

    }

    void Pitch()
    {
        if (script.testTime == 29 && a == 0)
        {
            PitchS = 1.5f;
            this.gameObject.GetComponent<AudioSource>().pitch = PitchS;
            a++;
        }
    }
}
