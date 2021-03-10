using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float directionTimer, movementTimer;
    public bool vertical;
    public GameObject player;

    private Vector3 movement;
    private float  dirTimer, movingTimer, direction;
    private PlayerMovement isPlayerMoving;
    private bool isPatrolling;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;

        isPatrolling = true;

        direction = 1f;
        dirTimer = directionTimer;
        movingTimer = movementTimer;
        isPlayerMoving = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerMoving.getIsMoving() && isPatrolling)
        {
            Movement();
        }
        else if(isPlayerMoving.getSkipTurn())
        {
            Movement();
        }
    }

    void Movement()
    {
        TimerManagement();

        if (vertical)
        {
            movement = new Vector3(0f, 1.0f * direction, 0f);
        }
        else
        {
            movement = new Vector3(1.0f * direction, 0f, 0f);
        }
    }

    void TimerManagement()
    {
        dirTimer -= Time.deltaTime;

        if (dirTimer < 0)
        {
            direction = -direction;
            dirTimer = directionTimer;
        }

        movingTimer -= Time.deltaTime;

        if (movingTimer < 0)
        {
            transform.position += movement;

            movingTimer = movementTimer;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            direction = -direction;
            dirTimer = directionTimer;
        }
    }

    public bool getIsPatrolling()
    {
        return isPatrolling;
    }

    public void setIsPatrolling(bool value)
    {
        isPatrolling = value;
    }
}
