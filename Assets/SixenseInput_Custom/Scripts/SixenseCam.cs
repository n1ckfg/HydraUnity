using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixenseCam : MonoBehaviour {

	public SixenseCtl sixCtlMain; // R ctl goes last
	public SixenseCtl sixCtlAlt;
	public Transform target;
	public Transform origin;
	public Vector3 offset = Vector3.zero;
	public float speed = 0.1f;
	public float joystickScale = 1f;
	public bool doSmoothDirVector = false;
	public bool joystickMovesOrigin = false;

	[HideInInspector] public bool doAlign = false;

	private Transform originOrig;
	private Vector3 offsetOrig;
	private bool isAligned = false;

	void Start() {
		originOrig = origin;
		offsetOrig = offset;
	}

	void Update() {
		if (sixCtlMain.firstRun) {
			if (sixCtlMain.triggerUp) {
				transform.position = target.position + offset;
				transform.LookAt (origin);
			}
		} else {
			// left/right, forward/back
			Vector3 dirVectorAlt = transform.localRotation * (new Vector3(sixCtlAlt.joystickVal.x, 0f, sixCtlAlt.joystickVal.y) * joystickScale);

			// left/right, up/down
			Vector3 dirVectorMain = transform.localRotation * (new Vector3(sixCtlMain.joystickVal.x, sixCtlMain.joystickVal.y, 0f) * joystickScale);

			// prevents weird results from joystick input
			if (doSmoothDirVector) {
				dirVectorMain = smoothDirVector(dirVectorMain);
				dirVectorAlt = smoothDirVector(dirVectorAlt);
			}

			/*
			if (dirVectorAlt != Vector3.zero) { 
				float directionLength = dirVectorAlt.magnitude;
				dirVectorAlt = dirVectorAlt / directionLength;
				directionLength = Mathf.Min(1.0f, directionLength);
				directionLength = directionLength * directionLength;
				dirVectorAlt = dirVectorAlt * directionLength;
			}
			*/

			if (joystickMovesOrigin) origin.transform.position += dirVectorAlt;
			//offset += dirVectorAlt;
			sixCtlAlt.offset += dirVectorAlt;
			sixCtlMain.offset += dirVectorAlt;
			transform.position += dirVectorAlt + dirVectorMain;

			if (sixCtlAlt.triggerPressed || sixCtlMain.button3Pressed || doAlign) {
				//origin.position = Vector3.Lerp (origin.position, originOrig.position, speed);
				transform.position = Vector3.Lerp (transform.position, target.position + offset, speed);
				//transform.LookAt (origin);
			}
			//else {
				//transform.position += new Vector3(-sixCtlAlt.joystickVal.x, sixCtlAlt.joystickVal.y, 0f) * joystickScale;
			//}
			//origin.position += new Vector3 (-sixCtlMain.joystickVal.x, sixCtlMain.joystickVal.y, 0f) * 3f * joystickScale;
			transform.LookAt (origin);
		}
	}

	public void disableOffset() {
		offset = Vector3.zero;
	}

	public void enableOffset() {
		offset = offsetOrig;
	}

	public Vector3 smoothDirVector(Vector3 v) {
		if (v != Vector3.zero) { 
			float directionLength = v.magnitude;
			v = v / directionLength;
			directionLength = Mathf.Min(1.0f, directionLength);
			directionLength = directionLength * directionLength;
			v = v * directionLength;
		}
		return v;
	}

	/*
	void LateUpdate() {
		//transform.LookAt(origin.position + (new Vector3(-sixCtlAlt.joystickVal.x, sixCtlAlt.joystickVal.y, 0f) * joystickScale));
		transform.position = transform.position + (new Vector3(-sixCtlAlt.joystickVal.x, sixCtlAlt.joystickVal.y, 0f) * joystickScale);
		if (!sixCtlAlt.triggerPressed) transform.LookAt(origin);
	}
	*/

}
