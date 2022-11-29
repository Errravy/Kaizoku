using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowedSword : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    BoxCollider2D box;
    [SerializeField] PhysicsMaterial2D physicsMaterial2D;
    PlayerVar player;
    bool isEmbed;
    float direction;
    [SerializeField] int a = 2;
    private void Awake() 
    {
        player = FindObjectOfType<PlayerVar>();
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();    
    }
    private void Start() {
        direction = player.transform.localScale.x;
        flip();
    }
    void FixedUpdate()
    {
        goAway();
        embed();
        if (a <= 0)
        {
            Destroy(gameObject,1f);
        }
    }
    void goAway()
    {
        rb.velocity = new Vector2(speed  *direction * Time.fixedDeltaTime,rb.velocity.y);
    }
    void embed()
    {
        if(box.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rb.bodyType = RigidbodyType2D.Static;
            GetComponent<Animator>().SetBool("nyangkut",true);
            box.sharedMaterial = physicsMaterial2D;
        }
        else if (box.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            GetComponent<Animator>().SetTrigger("mantul");
            a--;
            
        }
    }
     void flip()
   {
    if(player.transform.localScale.x < 0)
    {
        transform.localScale = new Vector3(-1,1,1);
    }
    else if(player.transform.localScale.x > 0)
    {
        transform.localScale = new Vector3(1,1,1);
    }
   }
}
