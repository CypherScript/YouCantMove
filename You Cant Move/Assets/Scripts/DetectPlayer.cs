using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private bool isChasing;
    private Transform playerPosition;
    private Vector3 startingPosition;
    private PlayerMovement isPlayerMoving;
    private EnemyMovement isPatrolling;
    private Vector3 movement;

    public GameObject player;
    public float speed, distance;

    // Start is called before the first frame update
    void Start()
    {
        isChasing = false;

        playerPosition = player.GetComponent<Transform>();

        startingPosition = new Vector3(transform.position.x, transform.position.y, 0);

        isPlayerMoving = player.GetComponent<PlayerMovement>();

        isPatrolling = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerMoving.getIsMoving())
        {
            if (isChasing && !isPatrolling.getIsPatrolling())
            {
                FollowPlayer();
            }
            
            if(!isChasing && !isPatrolling.getIsPatrolling())
            {
                transform.position = new Vector3(startingPosition.x, startingPosition.y, 0f);
                isPatrolling.setIsPatrolling(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            isPatrolling.setIsPatrolling(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isChasing = false;
        }
    }

    void FollowPlayer()
    {
        /*if(Vector2.Distance(transform.position, playerPosition.position) >= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        }*/

        if(transform.position.y <= playerPosition.position.y)
        {
            movement = Vector3.up;
        }
        else if(transform.position.y >= playerPosition.position.y)
        {
            movement = Vector3.down;
        }

        if(transform.position.x >= playerPosition.position.x)
        {
            movement = Vector3.left;
        }
        else if(transform.position.x <= playerPosition.position.x)
        {
            movement = Vector3.right;
        }

        transform.position += movement;
    }
}
