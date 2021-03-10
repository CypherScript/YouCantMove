using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Brazier : MonoBehaviour
{

    private Animator anim;

    private Light2D fire;


    private bool inBrazier = false;
    private bool isLit = false;
    private bool isTriggered;

    private Torch torch;
    private PlayerMovement player;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fire = GetComponentInChildren<Light2D>();

        torch = FindObjectOfType<Torch>();
        player = FindObjectOfType<PlayerMovement>();

        fire.intensity = 0f;
    }

    private void Update()
    {
        if(inBrazier && !isLit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOnFire();
                isLit = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            inBrazier = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            inBrazier = false;
        }
    }

    public void TurnOnFire()
    {
        anim.SetBool("unlit", true);
        fire.intensity = 2.5f;
        isTriggered = true;

        //set player respawn point to this location
        player.gameObject.GetComponent<Respawn>().respawnPoint = new Vector3(transform.position.x, transform.position.y - 0.85f, 0);
        player.movementPoint.position = new Vector3(transform.position.x, transform.position.y - 0.85f, 0);

        torch.setIntensityCap(1);
        torch.setIntensity(torch.getIntensityCap());
        torch.setRadius(1);
    }

    public bool getIsTriggered()
    {
        return isTriggered;
    }

}
