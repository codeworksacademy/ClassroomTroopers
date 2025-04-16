using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;

    private Vector2 MoveInput;
    private Rigidbody2D rb;


    void Start()
    {
        // NOTE get the component from the game object that this script is attached to
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveInput = MoveInput.normalized;

        // Things you want to see happen visually each frame

        // Flip the character based on direction
        if (MoveInput.x > .1f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (MoveInput.x < -.1f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }


    // NOTE The physics update
    void FixedUpdate()
    {
        rb.linearVelocity = MoveInput * speed;
    }

}
