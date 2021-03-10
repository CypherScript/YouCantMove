using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    private Animator anim;

    private Torch torch;

    // Start is called before the first frame update
    void Start()
    {
        torch = FindObjectOfType<Torch>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<PlayerMovement>())
        {
            Debug.Log(other.name + "is here");

            anim.SetTrigger("Player");
            torch.setGameOver(true);
            
        }
    }

}
