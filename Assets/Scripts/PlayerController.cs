using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("PASKOO")]
    [Tooltip("In meters per second")][SerializeField] float xSpeed = 4f;
    [Tooltip("In meters")][SerializeField] float xRange = 5f;

    [SerializeField] GameObject[] guns;

    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In meters")] [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 4.5f;
    [SerializeField] float controlRollFactor = -20f;
    float xThrow, yThrow;
    bool isControlEnabled = true;

	
    // Update is called once per frame
    void Update ()
    {
        if (isControlEnabled)
        {
            HorizontalMovement();
            VerticalMovement();
            RotationalMovement();
            ProcessFiring();
        }
    }
    void OnPlayerDeath()   // called by string reference
    {
        isControlEnabled = false;
    } 

    private void RotationalMovement()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void VerticalMovement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, +yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void HorizontalMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, +xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        /*
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
        */
        if (Input.GetKeyDown(KeyCode.Space))
            FireThings();
    }

    bool _lol = false;
    void FireThings()
    {
        if (!_lol)
            guns[0].GetComponent<ParticleSystem>().Play();
        else
            guns[0].GetComponent<ParticleSystem>().Stop();

        _lol = !_lol;
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns){
            gun.GetComponent<ParticleSystem>().Play();
            //gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns){
            gun.GetComponent<ParticleSystem>().Stop();
            //gun.SetActive(false);
        }
    } 

}
