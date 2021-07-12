using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float speed = 2;

    // Update is called once per frame
    void Update()
    {
        if (!HahaBirdGoFly.grounded)
            transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /*
        if (other.gameObject.tag == "Bird") {
            GameManager.soundHit();
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BYE BYE PIPE") {
            Destroy(gameObject);
        }
    }
}
