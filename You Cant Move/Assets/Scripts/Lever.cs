using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]
    private Animator leverAnim;
    [SerializeField]
    private Animator doorAnim;
    private SpriteRenderer mRenderer;
    public GameObject SmallDoor;

    public float timer;

    private bool player;

    // Start is called before the first frame update
    void Start()
    {
        leverAnim = GetComponent<Animator>();
        doorAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        
        mRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                leverAnim.SetBool("isOpen", true);
                StartCoroutine(OpenDoor());
            }
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(1.5f);
        doorAnim.SetBool("isOpen", true);
        mRenderer.sortingOrder = 12;
        SmallDoor.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            player = true;
        }
    }
}
