using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 0.0f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    private void FixedUpdate() {
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        rb.velocity = movement * moveSpeed;
    }
}
