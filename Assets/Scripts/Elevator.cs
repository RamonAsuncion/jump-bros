using UnityEngine;

public class Elevator : MonoBehaviour {
    // TODO: Remove from public and have them work on private.
    
    /** The button */
    public GameObject button;
    
    /** The character */
    public Rigidbody2D self;
    
    /** The start position of the elevator.*/
    public Vector2 startPosition;
    
    /** The end position of the elevator.*/
    public Vector2 endPosition;

    /** The speed of a character */
    private const float Speed = 30;

    /** The elevator going down? */
    public bool isMoving;
    public Elevator(GameObject button, Rigidbody2D self, Vector2 startPosition, Vector2 endPosition) {
        this.button = button;
        this.self = self;
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }

    // Update is called once per frame
    public void Update() {
        if (self.position.y >= startPosition.y && isMoving) {
            self.transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (button.GetComponent<Button>().pressed && self.position.y <= endPosition.y && collision.collider.CompareTag("Player")) {
            self.transform.Translate(Vector2.up * Speed * Time.deltaTime);
            isMoving = false;
        }
        else if (!(button.GetComponent<Button>().pressed) && self.position.y >= startPosition.y && collision.collider.CompareTag("Player")) {
            isMoving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Debug.Log("Player was standing on elevator.");
        if (collision.collider.CompareTag("Player")) {
            isMoving = true;
        }
    }
}
