using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahaBirdGoFly : MonoBehaviour
{
    private PhotonView PV;
    public GameManager gameManager;
    public float velocity = 1;
    private Rigidbody2D rb;
    private Animator animator;
    private Animator groundAnim;
    public static bool grounded;

    private bool jumpbird;
    private bool hedobefallindo;

    bool mobile = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PV = GetComponent<PhotonView>();
        groundAnim = GameManager.ground.GetComponent<Animator>();
        birdAnim("BIRD_DAED");
    }

    void Update()
    {
        if (PV.IsMine || !GameSetupController.multiplayer)
        {
            if (velocity == 0)
            {
                grounded = true;
            }
            if (grounded)
            {
                groundAnim.Play("GROUND_STOP");
            }
            if (Input.GetMouseButtonDown(0))
            {
                jumpbird = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                jumpbird = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                hedobefallindo = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                hedobefallindo = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (jumpbird) {
            rb.velocity = Vector2.up * velocity;
            grounded = false;
            GameManager.soundWing();
            birdAnim("BIRD_FLY");
            groundAnim.Play("GROUND_MOVE");
        }
        if (hedobefallindo) {
            rb.velocity = Vector2.down * velocity;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ur grounded lol")
        {
            grounded = true;
            GameManager.soundHit();
        }
        birdAnim("BIRD_DAED");
        if (other.gameObject.tag == "Game Over Collider") {
            grounded = true;
            GameManager.gameOver();
        }
    }

    void birdAnim(string suffix) {
        if (PV.IsMine) {
            string anim = $"{GameManager.currentBird}_{suffix}";
            animator.Play(anim);
        }
    }
}
