using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixenseCtl : MonoBehaviour {

	public SixenseSettings sixenseSettings;
	public Renderer[] ren;
	public int ctlNum = 0;
	public Vector3 pos = Vector3.zero;
	public Quaternion rot = Quaternion.identity;

	/*
	0. START
	1. THREE
	2. FOUR
	3. ONE
	4. TWO
	5. BUMPER
	6. JOYSTICK
	7. TRIGGER
	*/

	public bool startPressed = false;
	public bool button1Pressed = false;
	public bool button2Pressed = false;
	public bool button3Pressed = false;
	public bool button4Pressed = false;
	public bool bumperPressed = false;
	public bool joystickPressed = false;
	public bool triggerPressed = false;

	[HideInInspector] public bool startDown = false;
	[HideInInspector] public bool button1Down = false;
	[HideInInspector] public bool button2Down = false;
	[HideInInspector] public bool button3Down = false;
	[HideInInspector] public bool button4Down = false;
	[HideInInspector] public bool bumperDown = false;
	[HideInInspector] public bool joystickDown = false;
	[HideInInspector] public bool triggerDown = false;

	[HideInInspector] public bool startUp = false;
	[HideInInspector] public bool button1Up = false;
	[HideInInspector] public bool button2Up = false;
	[HideInInspector] public bool button3Up = false;
	[HideInInspector] public bool button4Up = false;
	[HideInInspector] public bool bumperUp = false;
	[HideInInspector] public bool joystickUp = false;
	[HideInInspector] public bool triggerUp = false;

	public float triggerVal = 0f;
	public Vector2 joystickVal = Vector2.zero;

	[HideInInspector] public bool firstRun = true;

	void Update() {
		/*
		startDown = false;
		button3Down = false;
		button4Down = false;
		button1Down = false;
		button2Down = false;
		bumperDown = false;
		joystickDown = false;
		triggerDown = false;

		startUp = false;
		button3Up = false;
		button4Up = false;
		button1Up = false;
		button2Up = false;
		bumperUp = false;
		joystickUp = false;
		triggerUp = false;
		*/

		if (SixenseInput.Controllers[ctlNum].Enabled) {
			pos = Vector3.Scale (SixenseInput.Controllers[ctlNum].Position, new Vector3 (-sixenseSettings.scale, sixenseSettings.scale, -sixenseSettings.scale)) + sixenseSettings.offset;
			rot = SixenseInput.Controllers[ctlNum].Rotation;
			rot.eulerAngles = new Vector3 (-rot.eulerAngles.x, rot.eulerAngles.y, -rot.eulerAngles.z);
			SixenseInput.Controllers[ctlNum].TriggerButtonThreshold = sixenseSettings.triggerThreshold;

			int buttonCounter = 0;
			foreach (SixenseButtons button in System.Enum.GetValues(typeof(SixenseButtons))) {
				bool press = SixenseInput.Controllers[ctlNum].GetButton(button);
				bool pressDown = SixenseInput.Controllers[ctlNum].GetButtonDown(button);
				bool pressUp = SixenseInput.Controllers[ctlNum].GetButtonUp(button);

				if (buttonCounter == 0) { // start
					startPressed = press;
					startDown = pressDown;
					startUp = pressUp;
				} else if (buttonCounter == 1) { // button3
					button3Pressed = press;
					button3Down = pressDown;
					button3Up = pressUp;
				} else if (buttonCounter == 2) { // button4
					button4Pressed = press;
					button4Down = pressDown;
					button4Up = pressUp;
				} else if (buttonCounter == 3) { // button1
					button1Pressed = press;
					button1Down = pressDown;
					button1Up = pressUp;
				} else if (buttonCounter == 4) { // button2
					button2Pressed = press;
					button2Down = pressDown;
					button2Up = pressUp;
				} else if (buttonCounter == 5) { // bumper
					bumperPressed = press;
					bumperDown = pressDown;
					bumperUp = pressUp;
				} else if (buttonCounter == 6) { // joystick
					joystickPressed = press;
					joystickDown = pressDown;
					joystickUp = pressUp;
				} else if (buttonCounter == 7) { // trigger
					triggerPressed = press;
					triggerDown = pressDown;
					triggerUp = pressUp;
				}

				buttonCounter++;
			}
				
			triggerVal = SixenseInput.Controllers[ctlNum].Trigger;

			if (triggerDown) {
				for (int i = 0; i < ren.Length; i++) {
					ren [i].enabled = false;
				}
			} else if (triggerUp) {
				for (int i = 0; i < ren.Length; i++) {
					ren [i].enabled = true;
				}
			}

			joystickVal = new Vector2 (SixenseInput.Controllers[ctlNum].JoystickX, SixenseInput.Controllers[ctlNum].JoystickY);

			//~
			//Debug.Log ("pos: " + pos + "\n" + "rot: " + rot + "\n" + "trigger: " + triggerPressed);
			//~
			transform.position = pos;
			transform.rotation = rot;
		}

		if (triggerUp && firstRun) firstRun = false;
	}

}
