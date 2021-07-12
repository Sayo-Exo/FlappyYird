using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPipe : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("amogus");
        if (other.tag == "BYE BYE PIPE") {
            Destroy(gameObject);
        }
    }
}
