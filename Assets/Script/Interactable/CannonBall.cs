using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
     [SerializeField] float speed;
    Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime,rb.velocity.y);
        Destroy(gameObject,5f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
