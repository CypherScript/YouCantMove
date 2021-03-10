using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    private bool isMoving, gameOver;
    
    private float intensityCap, delay;
    private PlayerMovement isCharacterMoving, isPlayerSkippingTurn;

    public Light2D torchLight;

    public GameObject character;
    public float rate, torchDelay;

    public Text torchText;

    // Start is called before the first frame update
    void Start()
    {
        isCharacterMoving = character.GetComponent<PlayerMovement>();
        isPlayerSkippingTurn = character.GetComponent<PlayerMovement>();

        intensityCap = torchLight.intensity;
        //intensityCap = 4.5f;

        gameOver = false;

        delay = Time.fixedTime + torchDelay;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isMoving = isCharacterMoving.getIsMoving();

        if (Time.fixedTime >= delay)
        {
            // Do your thang
            if (isMoving)
            {
                torchLight.intensity -= rate;

                if (torchLight.intensity <= 0)
                {
                    gameOver = true;
                    torchLight.intensity = 0;
                }
                //UpdateTorchUI();
            }
            else
            {
                if ((torchLight.intensity < intensityCap) && isPlayerSkippingTurn.getSkipTurn())
                {
                    torchLight.intensity += rate;

                    if (torchLight.intensity > intensityCap)
                    {
                        torchLight.intensity = intensityCap;
                    }

                   // UpdateTorchUI();

                    gameOver = false;
                }
            }
            delay = Time.fixedTime + torchDelay;
        }
    }

    public void UpdateTorchUI()
    {
        torchText.text = torchLight.intensity.ToString() + " / 5";
    }

    public void setIntensityCap(float value)
    {
        intensityCap -= value;
    }

    public void setIntensity(float value)
    {
        torchLight.intensity = value;
    }

    public void setGameOver(bool value)
    {
        gameOver = value;
    }

    public float getIntensityCap()
    {
        return intensityCap;
    }

    public float getIntensity()
    {
        return torchLight.intensity;
    }

    public void setRadius(float value)
    {
        torchLight.pointLightOuterRadius -= value; 
    }

    public bool getGameOver ()
    {
        return gameOver;
    }
}
