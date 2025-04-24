using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Fb_GameManager _gameManager;
    public int _mSpeed = 5;
    [SerializeField ]private SpriteRenderer sprite;
    Rigidbody2D Rb;
    public float HorizontalInput;
    bool isFacingRight;
    Animator animate;

    //For Sounds
    PlayButtonSound playSound;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        _gameManager.GetComponent<Fb_GameManager>();
        sprite = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
        isFacingRight = true;

        playSound = GetComponent<PlayButtonSound>();
    }

    void Update()
    {
        // Handle keyboard input
        HorizontalInput = Input.GetAxis("Horizontal");

        // Handle mouse input
        if (Input.GetMouseButton(0) && _gameManager.isReady)
        {
            animate.SetBool("IsRunning", true);
            Debug.Log("Clicked");
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {
                //Rb.velocity = new Vector2(HorizontalInput = -1 * _mSpeed, Rb.velocity.x);
                HorizontalInput = -1; // Move left
                //sprite.flipX = true;
            }
            else
            {
                //Rb.velocity = new Vector2(HorizontalInput = 1 * _mSpeed, Rb.velocity.x);
                HorizontalInput = 1; // Move right
                //sprite.flipX = false;
            }
            if (!isFacingRight && touchPos.x > 0)
            {
                Flip();
            }
            else if (isFacingRight && touchPos.x < 0)
            {
                Flip();
            }

            /*if (HorizontalInput != 0)
            {
                //animate.SetTrigger("RnPlayer");
                animate.SetBool("IsRunning", true);
            }
            else
            {
                animate.SetBool("IsRunning", false);
            }*/

        }
        else
        {
            animate.SetBool("IsRunning", false);
        }

        // Set the velocity based on input
        Rb.velocity = new Vector2(HorizontalInput * _mSpeed, Rb.velocity.x);
    }

    private void LateUpdate()
    {
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            playSound.PlaySoundonButton();
            Destroy(collision.gameObject);
            _gameManager.Fb_AddPoints();
            Debug.Log("1 point");
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
