using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerVar : MonoBehaviour
{
   public float movSpeed;
   public float jumpForce;
   public int   health;
   public int   playerState;
   public bool  ammo = false;
   public bool sworded = false;
   public AnimatorOverrideController[] overrideControllers;
   public GameObject throwedSword;
   public Transform swordPoint;
   public GameObject ballSprite;
   public bool readyToFire;
   [SerializeField]  TextMeshProUGUI coinText;
   [SerializeField]  Slider slider;
   [SerializeField]  LayerMask ground;
   [HideInInspector] public GameObject cannon;
    public GameObject sword;
   [HideInInspector] public PickUpSword pickUpSword;
   [HideInInspector] public Cannon cannonUI;
   [HideInInspector] public float direction;
   [HideInInspector] public bool isGrounded;
   [HideInInspector] public bool isDead;
   [HideInInspector] public int score;
   CapsuleCollider2D capsule;
   float maxHealth;
   PlayerCon playerCon;

   void Awake()
   {
        playerCon = GetComponent<PlayerCon>();
        capsule = GetComponent<CapsuleCollider2D>();
   }
   private void Start() {
        maxHealth = health;
        slider.maxValue = maxHealth;
   }
   void FixedUpdate()
   {
        coinText.text = score.ToString();
        ballSprite.SetActive(ammo);
        playerCon.setAnim(overrideControllers[playerState]);
        dead();
        groundCheck();
        flip();
        heart();
   }
   void groundCheck()
   {
    if(capsule.IsTouchingLayers(ground))
    {
        isGrounded = true;
    }
    else isGrounded = false;
   }
   void flip()
   {
    if(direction < 0)
    {
        transform.localScale = new Vector3(-1,1,1);
    }
    else if(direction > 0)
    {
        transform.localScale = new Vector3(1,1,1);
    }
   }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.tag == "sword" && !sworded) 
        {
            sword = other.gameObject;
            pickUpSword = sword.GetComponent<PickUpSword>();
        }
        if(other.tag == "cannon")
        {
            cannon = other.gameObject;
            cannonUI = cannon.GetComponent<Cannon>();
            readyToFire = true;
        }
        if(other.tag == "Ammo" && !ammo)
        {
            Destroy(other.gameObject);
            ammo = true;
        }
        if(other.tag == "coin")
        {
            other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            other.gameObject.GetComponent<Animator>().SetTrigger("collected");
            Destroy(other.gameObject,0.2f);
            score += 1;
        }
        if(other.tag == "Water")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<PlayerCon>().enabled = false;
            health = 0;
        }
        if(other.tag == "Treasure")
        {
            score+= 100;
            Destroy(other.gameObject);
            FindObjectOfType<SceneControl>().NextScene();
        }
        if(other.tag == "Key" && FindObjectOfType<chest>().key == false)
        {
            FindObjectOfType<chest>().key = true;
            other.gameObject.GetComponent<Animator>().SetTrigger("Collected");
            Destroy(other.gameObject,0.3f);
        }
   }
   void OnTriggerExit2D(Collider2D other)
   {
       if(other.tag == "sword" && !sworded)
       {
            sword = null;
            pickUpSword = null;
       }
       if(other.tag == "cannon")
        {
            cannon = null;
            readyToFire = false;
        }
   }

   void dead()
   {
    if(health <= 0)
    {
        isDead = true;
        FindObjectOfType<SceneControl>().restart();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
   }

   void heart()
   {
        slider.value = health;
   }
}

