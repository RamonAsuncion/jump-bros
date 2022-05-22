using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Win : MonoBehaviour 
{
    /** Confetti particles when the player wins. */ 
    [SerializeField]
    private ParticleSystem confettiEffect;

    /// <summary>
    /// Get the confetti effect.
    /// </summary>
    public void Awake()
    {
        confettiEffect.GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// When player clicks the confetti particles they activate.
    /// </summary>
    /// <param name="collide">The trophy shooting out confetti.</param>
    public void OnTriggerEnter2D(Collider2D collide)
    {
        Debug.Log("Collision with the particle");
        if (collide.CompareTag("Player"))
            confettiEffect.Play();
    }
}
