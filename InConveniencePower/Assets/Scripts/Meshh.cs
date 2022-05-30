using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshh : MonoBehaviour
{
    MeshRenderer ms;
    float b;
    // Start is called before the first frame update
    void Start()
    {
        ms = GetComponent<MeshRenderer>();
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (b <= 0.2)
        {
            b += Time.deltaTime;
        }else if(b >= 0.2)
        {
            ms.enabled = true;
        }
    }
}
