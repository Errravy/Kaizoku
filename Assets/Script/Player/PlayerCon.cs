using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCon : MonoBehaviour
{
    bool isRunning = false;
    bool isJumping = false;
    PlayerVar player;
    PlayerMov playerMov;
    Animator animator;
    Rigidbody2D rb;
    float CD = 1.5f;
    float gap;
    int a;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMov = GetComponent<PlayerMov>();
        player = GetComponent<PlayerVar>();
        animator = GetComponent<Animator>();
        gap = Time.time + CD;
    }
    void Update()
    {
        animatorCon();
    }
    public void running(InputAction.CallbackContext context)
    {
        getDirection(context.ReadValue<Vector2>());
        isRunning = true;
        if(context.canceled)
        {
            isRunning = false;
        }
    }
    public void jumping(InputAction.CallbackContext context)
    { 
        
        if(context.started && player.isGrounded)
        {
            a = 0;
            playerMov.jump();
        }
        else if(context.canceled && a <= 0)
        {
            Debug.Log(a);
            a++;
            rb.velocity = new Vector2(rb.velocity.x,0);
        }
    }
    public void fire(InputAction.CallbackContext context)
    {
        if(context.started && player.readyToFire && player.ammo && gap <= Time.time)
        {
            player.ammo = false;
            player.cannonUI.shoot();
            gap = Time.time + CD;
        }
        else if(context.started && player.readyToFire && !player.ammo)
        {
            
        }
    }
    void getDirection(Vector2 horizontal)
    {
        player.direction = horizontal.x;
    }
    public void SwordControl(InputAction.CallbackContext context)
    {
        if(context.started && player.sworded == false && player.sword != null)
        {
            player.sworded = true;
            player.playerState = 1;
            player.pickUpSword.destroySword();
        }
        else if(context.started && player.sworded)
        {
            animator.SetTrigger("throwing");
            Instantiate(player.throwedSword,player.swordPoint.position,Quaternion.identity);
            player.sworded = false;
            player.playerState = 0;
            player.sword = null;
        }
    }
    void animatorCon()
    {
        animator.SetBool("running",isRunning); 
        animator.SetFloat("airing",rb.velocity.y);       
        animator.SetBool("isGrounded",player.isGrounded);
        animator.SetBool("isdead",player.isDead);
    }

    public void setAnim(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
}
