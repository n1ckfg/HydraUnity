using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixenseCtl : MonoBehaviour {

	public SixenseSettings sixenseSettings;
	public Renderer[] ren;
	public int ctlNum = 0;
	public Vector3 pos = Vector3.zero;
	public Quaternion rot = Quaternion.identity;

	public bool triggerPressed = false;
	public bool trigger2Pressed = false;
	public bool button1Pressed = false;
	public bool button2Pressed = false;
	public bool button3Pressed = false;
	public bool button4Pressed = false;
	public bool joystickPressed = false;
	public bool startPressed = false;

	public bool triggerDown = false;
	public bool trigger2Down = false;
	public bool button1Down = false;
	public bool button2Down = false;
	public bool button3Down = false;
	public bool button4Down = false;
	public bool joystickDown = false;
	public bool startDown = false;

	public bool triggerUp = false;
	public bool trigger2Up = false;
	public bool button1Up = false;
	public bool button2Up = false;
	public bool button3Up = false;
	public bool button4Up = false;
	public bool joystickUp = false;
	public bool startUp = false;

	public float triggerVal = 0f;
	public Vector2 joystickVal = Vector2.zero;

	[HideInInspector] public bool firstRun = true;

	void Update() {
		triggerDown = false;
		trigger2Down = false;
		button1Down = false;
		button2Down = false;
		button3Down = false;
		button4Down = false;
		joystickDown = false;
		startDown = false;

		triggerUp = false;
		trigger2Up = false;
		button1Up = false;
		button2Up = false;
		button3Up = false;
		button4Up = false;
		joystickUp = false;
		startUp = false;

		if (SixenseInput.Controllers [ctlNum].Enabled) {
			pos = Vector3.Scale (SixenseInput.Controllers [ctlNum].Position, new Vector3 (-sixenseSettings.scale, sixenseSettings.scale, -sixenseSettings.scale)) + sixenseSettings.offset;
			rot = SixenseInput.Controllers [ctlNum].Rotation;
			rot.eulerAngles = new Vector3 (-rot.eulerAngles.x, rot.eulerAngles.y, -rot.eulerAngles.z);

			//foreach (SixenseButtons button in System.Enum.GetValues( typeof( SixenseButtons ) )) {
			//trigger = SixenseInput.Controllers[ctlNum].GetButton(button);
			//}

			triggerVal = SixenseInput.Controllers [ctlNum].Trigger;
			if (triggerVal > 0f && !triggerPressed) {
				triggerPressed = true;
				triggerDown = true;
				for (int i = 0; i < ren.Length; i++) {
					ren [i].enabled = false;
				}
			} else if (triggerVal <= 0f && triggerPressed) {
				triggerPressed = false;
				triggerUp = true;
				for (int i = 0; i < ren.Length; i++) {
					ren [i].enabled = true;
				}
			}

			joystickVal = new Vector2 (SixenseInput.Controllers [ctlNum].JoystickX, SixenseInput.Controllers [ctlNum].JoystickY);

			//~
			//Debug.Log ("pos: " + pos + "\n" + "rot: " + rot + "\n" + "trigger: " + triggerPressed);
			//~
			transform.position = pos;
			transform.rotation = rot;
		}

		if (triggerUp && firstRun) firstRun = false;
	}

}
