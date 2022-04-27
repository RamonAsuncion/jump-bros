using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Win : MonoBehaviour {
    // TODO: Fix the particle collision.
    
    /** Confetti particles when the player wins. */ 
    [SerializeField]
    private ParticleSystem confettiEffect;

    /*
     * Get the confetti effect.
     */
    public void Awake()
    {
        confettiEffect.GetComponent<ParticleSystem>();
    }

    /*
     * When player clicks the confetti particles they activate.
     */
    public void OnTriggerEnter2D(Collider2D collide)
    {
        Debug.Log("Collision with the particle");
        if (collide.CompareTag("Player"))
            confettiEffect.Play();
    }
}
