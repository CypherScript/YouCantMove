using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    public Transform movementPoint;

    [SerializeField]
    private Torch isGameOver;
    //private Checkpoint isTriggered;
    private Brazier isTriggered;
    private PlayerMovement isCharacterMoving;

    //public GameObject checkPoint;
    public GameObject brazier;
    public GameObject torch;
    public GameObject player;

    public GameObject GameoverScreen;
    public GameObject WinScreen;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;

        isGameOver = torch.GetComponent<Torch>();

        //isTriggered = checkPoint.GetComponent<Checkpoint>();
        isTriggered = brazier.GetComponent<Brazier>();

        isCharacterMoving = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver.getGameOver())
        {
            GameoverScreen.SetActive(true);
            GetComponent<PlayerMovement>().isAlive = false;

            //transform.position = respawnPoint;
            //movementPoint.position = respawnPoint;
            //
            //isGameOver.setIntensity(isGameOver.getIntensityCap());
            //
            //isGameOver.setGameOver(false);
            //
            //isCharacterMoving.setIsMoving(false);
        }
    }

    public void RespawnCharacter()
    {
        transform.position = respawnPoint;
        movementPoint.position = respawnPoint;

        isGameOver.setIntensity(isGameOver.getIntensityCap());

        isGameOver.setGameOver(false);

        isCharacterMoving.setIsMoving(false);
        GameoverScreen.SetActive(false);
        GetComponent<PlayerMovement>().isAlive = true;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if ((other.CompareTag("CheckPoint")) && isTriggered.getIsTriggered())
    //    {
    //        respawnPoint = new Vector3 (brazier.transform.position.x, brazier.transform.position.y - 2f, brazier.transform.position.z);

    //        Debug.Log("position has save to :" + respawnPoint);
    //    }
    //}
}
