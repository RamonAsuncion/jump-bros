using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class P1 : MonoBehaviour
{
    // Start Variables
    public Animation anim;
    public Animator animator;

    public Rigidbody2D rb;
    public BoxCollider2D cb;
    public ParticleSystem dust;

    // Sounds for the player. 
    [SerializeField] public AudioSource jumpsound;
    [SerializeField] public AudioSource deathsound;


    // Movement control values. 
    public float JUMP_POWER = 50;
    public float MOVE_SPEED = 3.5f;
    public float CROUCH_SPEED = 1.5f;
    bool onGround = false;
    public bool crouch = false;

    private void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        jumpsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            CreateDust();
            rb.AddForce(Vector2.up * JUMP_POWER);
            JumpSounds();

        }
        // Player 1 "A" control walk left and crouch. 
        if (Input.GetKey(KeyCode.A))
        {
            if (crouch)
            {
                rb.transform.Translate(Vector2.left * CROUCH_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    return;
                }
                else
                {
                    animator.Play("crawlLeft");
                    print("Crawling to the Left");
                }
            }
            else
            {
                rb.transform.Translate(Vector2.left * MOVE_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    return;
                }
                else
                {
                    animator.Play("walkLeft");
                    print("Walking to the Left");
                }
            }
        }
        // Player 1 "D" control walk right and crouch. 
        if (Input.GetKey(KeyCode.D))
            if (crouch)
            {
                rb.transform.Translate(Vector2.right * CROUCH_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    return;
                }
                else
                {
                    animator.Play("crawlRight");
                    print("Crawling to the RIGHT");
                }
            }
            else
            {
                rb.transform.Translate(Vector2.right * MOVE_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    return;
                }
                else
                {
                    animator.Play("walkRight");
                    Debug.Log("Walking to the RIGHT");
                }
            }
        // Player 1 "S" control for crouch and stand up.
        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
            cb.size = new Vector2(1.8f, 0.8f);
            Debug.Log("Button was pressed");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
            cb.size = new Vector2(0.8f, 1.74f);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.Play("Stand");
        }
        // Reset the level with the "R" key. 
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Player")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Touches the object with the tag "spikes".
        if (other.tag == "spikes")
        {
            deathsound.Play();
            Debug.Log("The player has died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Dust method to be called to play particles. 
    private void CreateDust()
    {
        dust.Play();
    }

    // Plays the jumping sound. 
    private void JumpSounds()
    {
        jumpsound.Play();
    }
}
