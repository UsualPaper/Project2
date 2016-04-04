using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

    Rigidbody2D charRB;

    [Header("CHARACTER MOVEMENT")]
    [Header("horizontal")]
    float hVelocity; //store directions pressed from -1 and 1.
    [Range(0.01f, 5.0f)]
    public float hscale = .05f; // our scaling factor for horizontal movement.


    float vVelocity; // stores the vertical velocity.
    [Tooltip("Lets us know the height of our jump.")]
    [Range(0.5f, 20.0f)]
    public float jumpVal = 1.0f; //the jump velocity when applied.
    [Range(0.5f, 20.0f)]
    public float secondJumpVal = 1.5f; // the second jump velocity.
    [Tooltip("Let's us know when character is on ground.")]
    public bool onGround; // Lets us know if character is "on the ground"
    public float interjumpTime = .25f;
    float jumpStartTime;
    [Tooltip("Subtract 2 from the amount for the number of jumps available.")]
    public int jumps;
    public float numjump = 1f;


	Animator animator;
	bool facingRight = true;

    // Use this for initialization
    void Start() {
        charRB = gameObject.GetComponent<Rigidbody2D>();
        jumps = 0;
		animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update() {
        getHorizontal();
        getJump();
        move();
    }
    void getHorizontal() {
        hVelocity = Input.GetAxis("Horizontal") * hscale * Time.deltaTime;
    }
    void move() {

		if (hVelocity > 0 && !facingRight) {
			flip ();
		} else if (hVelocity < 0 && facingRight) {
			flip ();
		}

		animator.SetFloat ("hSpeed", hVelocity);

        charRB.transform.position = new Vector2(hVelocity + charRB.transform.position.x, charRB.transform.position.y);
        charRB.velocity += (Vector2.up * vVelocity);
    }
    void getJump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (jumps < numjump && ((Time.time - jumpStartTime) > interjumpTime)) {
                vVelocity = secondJumpVal;
                jumps++;
            }

            if (onGround) {
                vVelocity = jumpVal;
                jumpStartTime = Time.time;
                jumps++;
                animator.SetTrigger("jump"); // jump animation trigger?
            }
        } else {
            vVelocity = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Ground")) {
            if (!onGround){
                onGround = true;
            }
        jumps = 0;
    }
}
    void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.CompareTag ("Ground")) {
			if (onGround) {
				onGround = false;
			}
		}
	}
		void flip(){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1f;
		transform.localScale = theScale;

    }

}
