using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Particle : MonoBehaviour
{

    public GameObject particleEffect;


    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag == "confetti")

        {
            particleEffect.SetActive(true);
        }
    }
}