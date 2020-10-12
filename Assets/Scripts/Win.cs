using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public ParticleSystem confetti;
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Players has won");
        }
    }
}
