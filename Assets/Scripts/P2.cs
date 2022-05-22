using UnityEngine;
using UnityEngine.SceneManagement;

public class P2 : MonoBehaviour
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
    
    /// <summary>
    /// Get the components for the player.
    /// </summary>
    private void Start()
    {
        _playerAnimation = GetComponent<Animation>();
        _animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    private void Update()
    {
        PlayerJump();
        PlayerMoveLeft();
        PlayerMoveRight();
        PlayerStandUp();
    }

    /// <summary>
    /// Player stand up.
    /// </summary>
    private void PlayerStandUp()
    {
        if (_playerAnimation.isPlaying) return;
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _crouch = true;
            boxCollide.size = new Vector2(1.8f, 0.8f);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _crouch = false;
            boxCollide.size = new Vector2(0.8f, 1.74f);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.Play("Stand");
        }
    }

    /// <summary>
    /// Player moving right.
    /// </summary>
    private void PlayerMoveRight()
    {
        if (!Input.GetKey(KeyCode.RightArrow) || _playerAnimation.isPlaying) return;
        
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

    /// <summary>
    /// Player moving left.
    /// </summary>
    private void PlayerMoveLeft()
    {
        if (!Input.GetKey(KeyCode.LeftArrow) || _playerAnimation.isPlaying) return;
        
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
    
    /// <summary>
    /// Player jumping.
    /// </summary>
    private void PlayerJump()
    {
        if (!Input.GetKeyDown(KeyCode.UpArrow) || !_onGround || _playerAnimation.isPlaying) return;
        
        rigidBody.AddForce(Vector2.up * JumpPower);
        CreateDust();
        JumpSounds();
    }

    /// <summary>
    /// Player is touching the "ground".
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Player"))
            _onGround = true;
    }
    
    /// <summary>
    /// Player is NOT touching the "ground"
    /// </summary>
    private void OnCollisionExit2D()  { _onGround = false; }

    /// <summary>
    /// Player touches the object with the tag "spikes".
    /// </summary>
    /// <param name="collider">Deadly spikes.</param>
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("spikes") && !collider.CompareTag("Player")) return;
        
        deathSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Dust method to be called to play particles.
    /// </summary>
    private void CreateDust()  {  dust.Play();  }

    /// <summary>
    /// Plays the jumping sound. 
    /// </summary>
    private void JumpSounds()  { jumpSound.Play(); }
}
