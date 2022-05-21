using UnityEngine;

public class Elevator : MonoBehaviour 
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

    public Elevator(GameObject button, Rigidbody2D platform, Vector2 startPosition, Vector2 endPosition) 
    {
        this.button = button;
        this.platform = platform;
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }

    /*
     * Update is called once per frame
     */
    public void Update() 
    {
        if (platform.position.y >= startPosition.y && isMoving) 
            platform.transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    /*
     * The user is pressing the button to activate the elevator.
     */
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        
        if (button.GetComponent<Button>().pressed && platform.position.y <= endPosition.y) 
        {
            platform.transform.Translate(Vector2.up * Speed * Time.deltaTime);
            isMoving = false;
        }
        else if (!(button.GetComponent<Button>().pressed) && platform.position.y >= startPosition.y) 
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
