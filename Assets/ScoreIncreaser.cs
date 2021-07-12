using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
    public bool hitTrigger = false;
    void Start()
    {
        hitTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bird") {
            if (!hitTrigger)
            {
                hitTrigger = true;
                GameManager.increaseScore();
            }
        }
    }
}
