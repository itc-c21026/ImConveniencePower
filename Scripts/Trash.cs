using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject Pl;
    Plate script;
    // Start is called before the first frame update
    void Start()
    {
        Pl = GameObject.Find("Plate");
        script = Pl.GetComponent<Plate>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ramen")
        {
            script.TrFa();
        }
    }
}
