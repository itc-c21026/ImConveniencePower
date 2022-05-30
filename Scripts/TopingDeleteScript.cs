using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopingDeleteScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ramen") Destroy(this.gameObject);
    }
}
