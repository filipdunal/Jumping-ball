using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJumpScript : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public float powerOfJumping;
    PlayerControl pc;
    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        pc = player.GetComponent<PlayerControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "platform")
        {
            Jump();
            PlatformScript ps = collision.transform.GetComponent<PlatformScript>();
            ps.cloneMe();
            if(!ps.takenPoint)
            {
                pc.points++;
                ps.takenPoint = true;
            }
        }
        else if (collision.tag == "ziemia")
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddRelativeForce(transform.up * powerOfJumping);
    }
}
