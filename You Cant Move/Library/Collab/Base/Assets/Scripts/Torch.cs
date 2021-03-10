using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool isMoving;
    private PlayerMovement isCharacterMoving;

    public Light2D torchLight;
    public GameObject character;
    public float rate;

    // Start is called before the first frame update
    void Start()
    {
        isCharacterMoving = character.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = isCharacterMoving.getIsMoving();

        if (isMoving)
        {
            torchLight.intensity -= rate;

            if (torchLight.intensity < 0)
            {
                torchLight.intensity = 0;
            }
        }
        else
        {
            if(torchLight.intensity < 4.5)
            {
                torchLight.intensity += rate * 2;

                if (torchLight.intensity > 4.5)
                {
                    torchLight.intensity = 4.5f;
                }
            }
        }
    }
}
