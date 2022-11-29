using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] float speed;
    Rigidbody2D rb;
    PlayerVar player;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerVar>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed * Time.fixedDeltaTime,rb.velocity.y);
        Destroy(gameObject,5f);
    }
    public void destroyed()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            player.health--;
            speed = 0;
            rb.velocity = Vector2.zero;
            GetComponent<Animator>().SetTrigger("destroyed");
        }
        else if(other.tag == "Ground")
        {
            speed = 0;
            rb.velocity = Vector2.zero;
            GetComponent<Animator>().SetTrigger("destroyed");
        }
    }
}
