using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    /** Activate the moving platform with a button. */
    public GameObject button;
    
    /** The block for the platform */
    public Rigidbody2D platform;

    /** The start position of the elevator.*/
    [SerializeField] 
    private Vector2 startPosition;
    
    /** The end position of the elevator.*/
    [SerializeField] 
    private Vector2 endPosition;

    /** How fast the platform is. (value has to be small)*/
    private const float Speed = 1.0F;

    /** The elevator going moving? */
    public bool isMoving;
    
    
    /// <summary>
    /// Construct a moving platform (side to side) for the player.
    /// </summary>
    /// <param name="button">to turn activate the elevator.</param>
    /// <param name="platform">the object that is acting as the elevator.</param>
    /// <param name="startPosition">the start position of the elevator.</param>
    /// <param name="endPosition"><the end position of the elevator./param>
    public MovingPlatform(GameObject button, Rigidbody2D platform, Vector2 startPosition, Vector2 endPosition) 
    {
        this.button = button;
        this.platform = platform;
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (platform.position.x >= startPosition.x && isMoving)
            platform.transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    /// <summary>
    /// The user is pressing the button to activate the elevator.
    /// </summary>
    /// <param name="collision">The elevator.</param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        
        if (button.GetComponent<Button>().pressed && platform.position.x <= endPosition.x)
        {
            platform.transform.Translate(Vector2.right * Speed * Time.deltaTime);
            isMoving = false;
        }
        else if (!(button.GetComponent<Button>().pressed) && platform.position.x >= startPosition.x)
        {
            isMoving = true;
        }
    }
    
    /// <summary>
    ///  Player is standing on the elevator.
    /// </summary>
    /// <param name="collision">The elevator.</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        
        // Player moves with the elevator
        collision.transform.parent = transform;
        isMoving = true;
    }
}
