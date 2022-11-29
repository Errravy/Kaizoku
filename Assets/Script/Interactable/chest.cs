using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class chest : MonoBehaviour
{
    [SerializeField] bool canOpenChest = false;
    [SerializeField] GameObject item;
    public bool key = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            canOpenChest = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            canOpenChest = false;
        }
    }

    public void openChest(InputAction.CallbackContext context)
    {
        if(context.started && canOpenChest && key)
        {
            key = false;
            GetComponent<Animator>().SetTrigger("unlocked");        
        }
    }

    public void chestLoadout()
    {
        item.SetActive(true);
    }

}
