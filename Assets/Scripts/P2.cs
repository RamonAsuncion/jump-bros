using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D cb;
    public Animation anim;
    public Animator animator;

    public float JUMP_POWER = 350;
    public float MOVE_SPEED = 7.5f;
    public float CROUCH_SPEED = 2f;

    bool onGround = false;
    bool crouch = false;
    private void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            rb.AddForce(Vector2.up * JUMP_POWER);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
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
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
            cb.size = new Vector2(1.8f, 0.8f);
            Debug.Log("Button was pressed");
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
            cb.size = new Vector2(0.8f, 1.74f);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.Play("Stand");
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
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "spikes"){
            Debug.Log("The player has died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
