using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    public Animator doorAnim;
    public Animator leverAnim;

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        leverAnim = gameObject.transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
