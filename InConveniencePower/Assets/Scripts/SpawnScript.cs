using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;

    //スポーンさせるオブジェクト
    public GameObject obj;

    public string Tag;

    public bool spwan;

    public float spwanTime;

    int spwanCnt;
    public int RamenspwanCnt;

    float b = 0;

    public int i = 0;

    public int[] a;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spwanTime = 10;
        spwan = true;
        Application.targetFrameRate = 30;
    }


    private void OnCollisionExit(Collision collision)
    {
        //オブジェクトが離れるとfalseになる
        if (collision.gameObject.tag == Tag && spwanCnt == 0 && collision.gameObject.tag != "Ramen")
        {
            Invoke("Spwanbool", spwanTime);
            spwanCnt++;
        }
    }

    void Update()
    {
        if (RamenspwanCnt == 1)
        {
            Invoke("Spwanbool", 1f);
            spwanCnt++;
            RamenspwanCnt++;
        }

        if (spwanCnt >= 1)
        {
            b += Time.deltaTime;
            if (b >= 10)
            {
                spwanCnt = 0;
                b = 0;
            }
        }
        
        //falseになるとオブジェクトが出現してtrueになる
        if (spwan == false)
        {
            audioSource.PlayOneShot(SE1);
            GameObject Obj =  Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y+3, this.transform.position.z), Quaternion.identity);
            
            Obj.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            spwan = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ramen")
        {
            a[i] = i;

        }
    }

    void Spwanbool()
    {
        spwan = false;
    }
}
