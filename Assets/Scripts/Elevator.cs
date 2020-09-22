using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject button;
    public Rigidbody2D self;
    public Vector2 startPos;
    public Vector2 endPos;
    public float SPEED;

    bool down = false;

    // Update is called once per frame
    void Update()
    {
        if (self.position.y >= startPos.y && down)
        {
            self.transform.Translate(Vector2.down * SPEED * Time.deltaTime);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (button.GetComponent<Button>().pressed && self.position.y <= endPos.y && collision.collider.tag == "Player")
        {
            self.transform.Translate(Vector2.up * SPEED * Time.deltaTime);
            down = false;
        }
        else if (!(button.GetComponent<Button>().pressed) && self.position.y >= startPos.y && collision.collider.tag == "Player")
        {
            down = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            down = true;
        }
    }
}
