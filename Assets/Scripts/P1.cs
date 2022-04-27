using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class P1 : MonoBehaviour
{
    /** Player animation for crouching, walking...*/
    private Animation _playerAnimation;
    
    /** Animate the user. */
    private Animator _animator;

    /** Player body. */
    public Rigidbody2D rigidBody;
    
    /** Environment box collisions. */
    public BoxCollider2D boxCollide;
    
    /** Dust particle when player jumps. */
    [SerializeField]
    private ParticleSystem dust;

    /** The sound that plays when player jumps. */
    [SerializeField] 
    private AudioSource jumpSound;
    
    /** The sound that plays when player dies. */
    [SerializeField] 
    private AudioSource deathSound;

    /** The jump power of the player. */
    public float JUMP_POWER = 50F;
    
    /** The speed the player is moving. */
    public float MOVE_POWER = 3.5F;
    
    /** The speed at which the player crouches. */
    public float CROUCH_SPEED = 1.5F;
    
    /** Player is touching the ground? */
    public bool onGround;
    
    /** Player is crouching? */
    public bool crouch;
    
    /*
     * Get the components for the player.
     */
    private void Start()
    {
        _playerAnimation = GetComponent<Animation>();
        _animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }

    /*
     *  Update is called once per frame
     */
    private void Update()
    {
        PlayerJump();
        PlayerMoveLeft();
        PlayerMoveRight();
        PlayerStandUp();
    }

    /*
     * Player stand up.
     */
    private void PlayerStandUp()
    {
        if (_playerAnimation.isPlaying) return;
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
            boxCollide.size = new Vector2(1.8f, 0.8f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
            boxCollide.size = new Vector2(0.8f, 1.74f);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.Play("Stand");
        }
    }

    /*
     * Player moving right.
     */
    private void PlayerMoveRight()
    {
        if (!Input.GetKey(KeyCode.D) || _playerAnimation.isPlaying) return;
        
        if (crouch)
        {
            rigidBody.transform.Translate(Vector2.right * CROUCH_SPEED * Time.deltaTime);
            _animator.Play("crawlRight");
        }
        else
        {
            rigidBody.transform.Translate(Vector2.right * MOVE_POWER * Time.deltaTime);
            _animator.Play("walkRight");
        }
    }

    /*
     * Player moving left.
     */
    private void PlayerMoveLeft()
    {
        if (!Input.GetKey(KeyCode.A) || _playerAnimation.isPlaying) return;
        
        if (crouch)
        {
            rigidBody.transform.Translate(Vector2.left * CROUCH_SPEED * Time.deltaTime);
            _animator.Play("crawlLeft");
        }
        else
        {
            rigidBody.transform.Translate(Vector2.left * MOVE_POWER * Time.deltaTime);
            _animator.Play("walkLeft");
        }
    }
    
    /*
     * Player jumping.
     */
    private void PlayerJump()
    {
        if (!Input.GetKeyDown(KeyCode.W) || !onGround || _playerAnimation.isPlaying) return;
        
        rigidBody.AddForce(Vector2.up * JUMP_POWER);
        CreateDust();
        JumpSounds();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Player"))
            onGround = true;
    }
    
    private void OnCollisionExit2D()  { onGround = false; }

    /*
     * Player touches the object with the tag "spikes".
     */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("spikes") && !other.CompareTag("Player")) 
            return;
        
        deathSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*
     * Dust method to be called to play particles.
     */
    private void CreateDust()  {  dust.Play();  }

    /*
     * Plays the jumping sound. 
     */
    private void JumpSounds()  { jumpSound.Play(); }
}
