using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseEffect : MonoBehaviour {
    public int speedMultiplier = 2;
    public int startingPitch = 4;
    public int timeToDecrease = 5;

    public AnimationCurve audioOffset;

    AudioSource audioSource;

    private float offset;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startingPitch;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.F)) {
            offset += Time.deltaTime * startingPitch / timeToDecrease * speedMultiplier;
        }
        else {
            offset = 0f;
       }
        audioSource.pitch = startingPitch + audioOffset.Evaluate(offset);
	}
}
