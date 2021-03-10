using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isTriggered;
    private Torch intensityCap;
    private float newIntensity;

    public GameObject torch;
    public float intensityDecrease;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;

        intensityCap = torch.GetComponent<Torch>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.CompareTag("Player")) && (!isTriggered))
        {
            Debug.Log("Collision");

            newIntensity = intensityCap.getIntensity() - intensityDecrease;

            isTriggered = true;

            intensityCap.setIntensityCap(intensityDecrease);
            intensityCap.setIntensity(newIntensity);
        }
    }

    public bool getIsTriggered()
    {
        return isTriggered;
    }
}
