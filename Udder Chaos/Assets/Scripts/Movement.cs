using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem leftParticles;
    [SerializeField] ParticleSystem rightParticles;
    [SerializeField] ParticleSystem middleParticles;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            StopRotation();
        }
    }


    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!middleParticles.isPlaying || middleParticles.isPlaying)
        {
            middleParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        middleParticles.Stop();
    }


    void RotateLeft()
    {
        ApplyRotation(-rotationThrust);
        if (!rightParticles.isPlaying)
        {
            rightParticles.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(rotationThrust);
        if (!leftParticles.isPlaying)
        {
            leftParticles.Play();
        }
    }

    void StopRotation()
    {
        rightParticles.Stop();
        leftParticles.Stop();
    }



    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(new Vector3(1, 0, 0) * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
