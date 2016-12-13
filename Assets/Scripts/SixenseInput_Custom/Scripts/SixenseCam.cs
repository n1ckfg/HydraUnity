using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixenseCam : MonoBehaviour {

	public SixenseCtl sixCtl;
	public Transform target;
	public Transform origin;
	public Vector3 offset = Vector3.zero;
	public float speed = 0.1f;
	public float joystickScale = 1f;

	void Update() {
		if (sixCtl.firstRun) {
			if (sixCtl.triggerUp) {
				transform.position = target.position + offset;
				transform.LookAt (origin);
			}
		} else {
			if (sixCtl.triggerPressed) {
				transform.position = Vector3.Lerp (transform.position, target.position + offset, speed);
				//transform.LookAt (origin);
			} else {
				transform.position = transform.position + (new Vector3(-sixCtl.joystickVal.x, sixCtl.joystickVal.y, 0f) * joystickScale);
			}
			transform.LookAt (origin);
		}
	}

	/*
	void LateUpdate() {
		//transform.LookAt(origin.position + (new Vector3(-sixCtl.joystickVal.x, sixCtl.joystickVal.y, 0f) * joystickScale));
		transform.position = transform.position + (new Vector3(-sixCtl.joystickVal.x, sixCtl.joystickVal.y, 0f) * joystickScale);
		if (!sixCtl.triggerPressed) transform.LookAt(origin);
	}
	*/

}
