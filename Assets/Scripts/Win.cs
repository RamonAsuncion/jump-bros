using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {
    public ParticleSystem confettiEffect;
    void OnParticleCollision(GameObject other) {
        if (other.CompareTag("Player")) {
            // TODO: Add confetti when the player wins.
            Debug.Log("Players has won");
        }
    }
}
