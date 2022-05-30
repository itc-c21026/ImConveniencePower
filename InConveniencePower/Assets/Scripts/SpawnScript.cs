using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;
    //public GameObject obj2;

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

    //public MeshRenderer ms;

    //public string[] TrFas;
    // Start is called before the first frame update
    void Start()
    {
        //ms = GetComponent<MeshRenderer>();
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
            //ms.enabled = true;
            //Debug.Log(Tag + "!!!!!");
            Invoke("Spwanbool", spwanTime);
            spwanCnt++;
        }
    }

    void Update()
    {
        if (RamenspwanCnt == 1)
        {
            //Debug.Log("Ramen!!!!!");
            Invoke("Spwanbool", 1f);
            spwanCnt++;
            RamenspwanCnt++;
        }

        /*if (b % 2 == 0)
        {
            Debug.Log()
        }*/

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
            //Debug.Log("spawn");
            spwan = true;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        obj2.SetActive(true);
    }*/

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ramen")
        {
            a[i] = i;
            //Debug.Log(a[i]);
            //TrFas[i] = "true";
            //Debug.Log(TrFas[i]);
            //i++;

        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
        }
        else
        {
            spwanCnt = 1;
            b += Time.deltaTime;
            Debug.Log(b);
        }
    }*/

    void Spwanbool()
    {
        spwan = false;
    }
}
