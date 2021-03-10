using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool isMoving, gameOver;
    private float intensityCap;
    private PlayerMovement isCharacterMoving;

    public Light2D torchLight;
    public GameObject character;
    public float rate;

    // Start is called before the first frame update
    void Start()
    {
        isCharacterMoving = character.GetComponent<PlayerMovement>();

        intensityCap = 4.5f;

        gameOver = false;
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
                gameOver = true;
            }
        }
        else
        {
            if(torchLight.intensity < intensityCap)
            {
                torchLight.intensity += rate * 2;

                if (torchLight.intensity > intensityCap)
                {
                    torchLight.intensity = intensityCap;
                }
            }
        }
    }

    public void setIntensityCap(float value)
    {
        intensityCap -= value;
    }

    public bool getGameOver ()
    {
        return gameOver;
    }
}
