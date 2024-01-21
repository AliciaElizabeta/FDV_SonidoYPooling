using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndJump2D : MonoBehaviour
{

    public float MovementSpeed = 3;

    public float JumpForce = 3;

    private Rigidbody2D _rigidbody;

    private SpriteRenderer mySpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()

    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            //ForceMode2D.Impulse
            //Add an instant force impulse to the rigidbody2D, using its mass.
        }

        if (movement > 0)
        {
            //this.transform.localScale = new Vector3(1,1,1);
            mySpriteRenderer.flipX = false;
        }
        if (movement < 0)
        {
            //this.transform.localScale = new Vector3(-1, 1, 1);
            mySpriteRenderer.flipX = true;
        }
    }
}