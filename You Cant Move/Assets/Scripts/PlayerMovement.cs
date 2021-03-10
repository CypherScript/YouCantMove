using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Transform movementPoint;
    public LayerMask stopMovement;
    public float movementSpeed, movementTimer;

    private SpriteRenderer mSpriteRenderer;
    private float CurrentStep, timer;
    private bool isMoving, skipTurn;

    private Animator anim;

    public GameObject LtorchLocation;
    public GameObject RtorchLocation;
    public GameObject Torch;

    public int key;

    public AudioClip MoveAudio;
    private AudioSource aSource;

    private Torch torch;

    public bool isAlive;

    //playerHUD
    public Text keycountText;
    public GameObject WinScreen;


    /*TODO
     * __for the player__
     * -interact function for fires/braziers
     * -wait time between inputs so players cant spam movement
     * -skip movement option
     * -Fire should increase when the player skips movement instead of overtime
     * -"die" function, should reset the player to previous checkpoint and reset enemies to original positions
     * 
     * __For the enemies__
     * -move when the player moves
     * -if the player skips movement, they should still continue to move
     * -move in a grid pattern
     * -see the player in a certain radius and chase them
     * -if they player gets away, go back to patrol area / start location
     */


    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        skipTurn = false;
        isAlive = true;

        timer = -1;

        movementPoint.parent = null;
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();

        torch = FindObjectOfType<Torch>();


        CurrentStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, movementPoint.position, movementSpeed * Time.deltaTime);
        //if (isAlive)
        //{
            if (Vector3.Distance(transform.position, movementPoint.position) <= .05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movementPoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, stopMovement))
                    {
                        if (isAlive)
                        {
                        movementPoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        CurrentStep = Input.GetAxisRaw("Horizontal");
                        anim.SetBool("isMoving", true);

                        isMoving = true;
                        skipTurn = false;
                        timer = movementTimer;
                        }
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movementPoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, stopMovement))
                    {
                        if (isAlive)
                        {
                            movementPoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                            anim.SetBool("isMoving", true);

                            isMoving = true;
                            skipTurn = false;
                            timer = movementTimer;
                        }  
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    skipTurn = !skipTurn;
                }
                else
                {
                    isMoving = false;
                }
            }
        //}
        else
        {
            anim.SetBool("isMoving", false);
        }


        //Flip sprites for both the player and torch
        if (CurrentStep > 0)
        {
            mSpriteRenderer.flipX = true;

            Torch.transform.position = RtorchLocation.transform.position;
            Torch.transform.rotation = RtorchLocation.transform.rotation;


        }
        else
        {
            mSpriteRenderer.flipX = false;

            Torch.transform.position = LtorchLocation.transform.position;
            Torch.transform.rotation = LtorchLocation.transform.rotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Key>())
        {
            key++;
            UpdateUI();
        }
        if(other.gameObject.tag == "Enemy")
        {
            torch.setGameOver(true);
            Debug.Log("killed by enemy");
        }
        if (other.CompareTag("Finish"))
        {
            WinScreen.SetActive(true);
        }
    }

    public void UpdateUI()
    {
        keycountText.text = "Keys: " + key.ToString();
    }

    public bool getIsMoving ()
    {
        return isMoving;
    }

    public bool getSkipTurn()
    {
        return skipTurn;
    }

    public void setIsMoving(bool value)
    {
        isMoving = value;
    }

    public void PlayMoveAudio()
    {
        aSource.PlayOneShot(MoveAudio);
    }
}




