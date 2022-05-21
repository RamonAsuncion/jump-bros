using UnityEngine;
using UnityEngine.SceneManagement;

public class P1 : MonoBehaviour
{
    /** Player animation for crouching, walking...*/
    private Animation _playerAnimation;
    
    /** Animate the user. */
    private Animator _animator;

    /** Player body. */
    [SerializeField]
    private Rigidbody2D rigidBody;
    
    /** Environment box collisions. */
    [SerializeField]
    private BoxCollider2D boxCollide;
    
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
    private const float JumpPower = 350F;
    
    /** The speed the player is moving. */
    private const float MovePower = 3.5F;
    
    /** The speed at which the player crouches. */
    private const float CrouchSpeed = 1.5F;
    
    /** Player is touching the ground? */
    private bool _onGround;
    
    /** Player is crouching? */
    private bool _crouch;
    
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
            _crouch = true;
            boxCollide.size = new Vector2(1.8f, 0.8f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            _crouch = false;
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
        
        if (_crouch)
        {
            rigidBody.transform.Translate(Vector2.right * CrouchSpeed * Time.deltaTime);
            _animator.Play("crawlRight");
        }
        else
        {
            rigidBody.transform.Translate(Vector2.right * MovePower * Time.deltaTime);
            _animator.Play("walkRight");
        }
    }

    /*
     * Player moving left.
     */
    private void PlayerMoveLeft()
    {
        if (!Input.GetKey(KeyCode.A) || _playerAnimation.isPlaying) return;
        
        if (_crouch)
        {
            rigidBody.transform.Translate(Vector2.left * CrouchSpeed * Time.deltaTime);
            _animator.Play("crawlLeft");
        }
        else
        {
            rigidBody.transform.Translate(Vector2.left * MovePower * Time.deltaTime);
            _animator.Play("walkLeft");
        }
    }
    
    /*
     * Player jumping.
     */
    private void PlayerJump()
    {
        if (!Input.GetKeyDown(KeyCode.W) || !_onGround || _playerAnimation.isPlaying) return;
        
        rigidBody.AddForce(Vector2.up * JumpPower);
        CreateDust();
        JumpSounds();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Player"))
            _onGround = true;
    }
    
    private void OnCollisionExit2D()  { _onGround = false; }

    /*
     * Player touches the object with the tag "spikes".
     */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("spikes") && !other.CompareTag("Player")) return;
        
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
