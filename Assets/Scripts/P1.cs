using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class P1 : MonoBehaviour
{
    [SerializeField] Toggle audioToggle;

    public Rigidbody2D rb;
    public BoxCollider2D cb;
    public Animation anim;
    public Animator animator;

    public ParticleSystem dust;

    public float JUMP_POWER = 250;
    public float MOVE_SPEED = 5.5f;
    public float CROUCH_SPEED = 1.5f;

    bool onGround = false;
    public bool crouch = false;

    private void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();

        if (AudioListener.volume == 0)
        {
            audioToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            CreateDust();
            rb.AddForce(Vector2.up * JUMP_POWER);
        }
        if (Input.GetKey(KeyCode.A))
        {
            CreateDust();
            if (crouch)
            {
                rb.transform.Translate(Vector2.left * CROUCH_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    print("doin smt");
                    return;
                }
                else
                {
                    animator.Play("crawlLeft");
                    print("crawling left");
                }
            }
            else
            {
                rb.transform.Translate(Vector2.left * MOVE_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    print("doin smt");
                    return;
                }
                else
                {
                    animator.Play("walkLeft");
                    print("walking left");
                }
            }
        }
        if (Input.GetKey(KeyCode.D))
            if (crouch)
            {
                rb.transform.Translate(Vector2.right * CROUCH_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    print("doin smt");
                    return;
                }
                else
                {
                    animator.Play("crawlRight");
                    print("crawling right");
                }
            }
            else
            {
                rb.transform.Translate(Vector2.right * MOVE_SPEED * Time.deltaTime);
                if (anim.isPlaying)
                {
                    print("doin smt");
                    return;
                }
                else
                {
                    animator.Play("walkRight");
                    print("walking right");
                }
            }
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
        if (other.tag == "spikes")
        {
            Debug.Log("The player has died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void CreateDust()
    {
        dust.Play();
    }
}
