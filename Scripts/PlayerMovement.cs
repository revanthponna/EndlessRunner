using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    bool alive = true;
    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.07f;
    public float jumpForce = 400f;
    public LayerMask groundMask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void FixedUpdate()
    {
        if (!alive) return;
        // Specifying the forward and horizontal movement of the player
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Update is called once per frame
    void Update()
    {
        // Input Controls for player movement
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); // If space key is pressed, Jump function will be executed and player will jump.
        }
        
        // If player moves out of the platform, die function is executed.
        if(transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        // restarting the game
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(2);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask); // checking if the player is grounded or in the air
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }
}
