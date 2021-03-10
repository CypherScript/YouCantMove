using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDoor : MonoBehaviour
{

    private Animator anim;

    private bool playerHere;
    private bool isOpen;
    //this is just to deactive the collider on the child gameobject
    GameObject childgameObject;

    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        childgameObject = gameObject.transform.GetChild(0).gameObject;

        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen && playerHere && player.key > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isOpening", true);
                player.key -= 1;
                childgameObject.SetActive(false);
                isOpen = true;

                player.UpdateUI();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            Debug.Log(other.name);
            playerHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            playerHere = false;
        }
    }
}
