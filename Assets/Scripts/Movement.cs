using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Movement : MonoBehaviour
{
    [SerializeField] float thrustSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] AudioClip vfx_EngineThrust;
    [SerializeField] ParticleSystem ps_Booster;
    [SerializeField] Joystick joyStick;
    [SerializeField] Button thrustButton;

    Rigidbody playerRigidbody;
    AudioSource playerAudioSource;

    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
        playerAudioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ApplyThrustTouchScreen()
    {
        playerRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSpeed);
        if (!ps_Booster.isPlaying)
        {
            ps_Booster.Play();
        }
        if (!playerAudioSource.isPlaying)
        {
            playerAudioSource.PlayOneShot(vfx_EngineThrust);
        }
    }

    void NegateThrustTouchScreen()
    {
        playerAudioSource.Stop();
        ps_Booster.Stop();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSpeed);
            if(!ps_Booster.isPlaying)
            {
                ps_Booster.Play();
            }
            if (!playerAudioSource.isPlaying)
            {
                playerAudioSource.PlayOneShot(vfx_EngineThrust);
            }
        } else
        {
            playerAudioSource.Stop();
            ps_Booster.Stop();
        }
    }
    
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || joyStick.Horizontal < -0.3f)
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || joyStick.Horizontal > 0.3f)
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        playerRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        playerRigidbody.freezeRotation = false;
    }
}
