using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D myBody;
    private float jumpForce = 5f;

    private float max_Y = 4.4f;

    private string KNIFE_TAG = "Knife";

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameManager.instance.ResetValues(); // Now accessible since it's public
    }

    void Update()
    {
        Jump();
        CheckBounds();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
        }
    }

    void CheckBounds()
    {
        Vector3 temp = transform.position;

        if (temp.y > max_Y)
        {
            temp.y = max_Y;
        }
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == KNIFE_TAG)
        {
            Time.timeScale = 0f;
            GameManager.instance.RestartGame();
        }
    }
}
