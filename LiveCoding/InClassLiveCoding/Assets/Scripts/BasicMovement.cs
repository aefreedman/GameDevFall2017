using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Rigidbody2D MyRigidbody2D;
    public float ForceStrength;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        // Moving GameObjects:
        // You can use the Transform component always
        // if it's also a physics object you can use the Rigidbody/Rigidbody2D
        // If you move a physics object's transform, it will ignore physics interactions during the movement
        // Make sure you use the rigidbody to move an object if you want it to have physics interactions during the
        // movement. Make sure not to move it too quickly.
        
        // Input:
        // Use Input.GetKey() to get a physical key on your keyboard
        // Use Input.GetButton() or Input.GetAxix() to use your buttons/axes defined in the InputManager
        // Remember there's also Input.GetButtonDown() and Input.GetButtonUp()
        
        // move up
        if (Input.GetAxis("Vertical") > 0)
        {
            Debug.Log("this button moves me up");
            
//			transform.Translate(new Vector3(0, 1, 0));
//			transform.Translate(Vector2.up * 5);
            MyRigidbody2D.AddForce(Vector2.up * ForceStrength);
        }
        // move down
        if (Input.GetAxis("Vertical") < 0)
        {
//			transform.Translate(Vector2.down * 5);
//			MyRigidbody2D.MovePosition(Vector2.down * ForceStrength);
            MyRigidbody2D.AddForce(Vector2.down * ForceStrength);
        }
        // move left
        if (Input.GetAxis("Horizontal") < 0)
        {
            MyRigidbody2D.AddForce(Vector2.left * ForceStrength);
        }
        // move right
        if (Input.GetAxis("Horizontal") > 0)
        {
            MyRigidbody2D.AddForce(Vector2.right * ForceStrength);
        }
    }
}