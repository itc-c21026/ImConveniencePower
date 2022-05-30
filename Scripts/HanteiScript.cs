using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanteiScript : MonoBehaviour
{
    public int a = 0;
    public int b = 1;
    public int c = 2;
    public bool check = true;
    public bool check2 = true;
    public bool check3 = true;
    public int[] ran;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        ran = new int[] { 1101110, 1110110, 1110011 };
    }


    public void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "customer" )
        {
            i = Random.Range(0, 3);
            if (check == true)
            {
                check = false;
            }
        }
    }
}
