using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningMotherfucker : MonoBehaviour {
    public float Speed = 50f;

	void Update() {
        transform.Rotate(Time.deltaTime * Speed * 0.5f, Time.deltaTime * Speed * 2f, Time.deltaTime * Speed);
	}
}
