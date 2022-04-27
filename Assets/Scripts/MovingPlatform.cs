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

    /** The elevator going down? */
    public bool isMoving;
    
    public MovingPlatform(GameObject button, Rigidbody2D platform, Vector2 startPosition, Vector2 endPosition) 
    {
        this.button = button;
        this.platform = platform;
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }

   
    // Update is called once per frame
    void Update()
    {
        if (platform.position.x >= startPosition.x && isMoving)
            platform.transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    /*
     * The user is pressing the button to activate the elevator.
     */
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))  
            return;
        
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
    
    /*
     * Player is standing on the elevator.
     */
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            isMoving = true;
    }
}
