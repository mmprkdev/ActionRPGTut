using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;
    public Vector2 lastMove;

    private Animator animator;
    private bool playerMoving;
    
    private Rigidbody2D playerRigidbody;
    // static will allow a value to be persistant through all scene transitions
    private static bool playerExists;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        // handle player duplicaiton
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {

        playerMoving = false;

        // Only allow movement while not attacking
        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                // NOTE: You need to multiply by Time.deltaTime so that the movement speed is not dependant
                // on the frame rate.
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5)
            {
                playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5 && Input.GetAxisRaw("Vertical") > -0.5)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                // Stop moving while attacking.
                playerRigidbody.velocity = Vector2.zero;
                animator.SetBool("Attacking", true);
            }
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        else
        {
            attacking = false;
            animator.SetBool("Attacking", false);
        }



        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }
}
