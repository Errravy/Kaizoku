using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    PlayerVar player;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerVar>();        
    }

    // Update is called once per frame
    void Update()
    {
        run();
    }

    public void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,player.jumpForce * Time.fixedDeltaTime);
    }
    void run()
    {
        rb.velocity = new Vector2(player.direction * player.movSpeed * Time.fixedDeltaTime,rb.velocity.y);
    }

}
