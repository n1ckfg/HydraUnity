using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SixenseHand))]
public class Sixense_NewController : MonoBehaviour {

    public SixenseHandsController handsController;

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

    public float triggerVal = 0f;
    public Vector2 joystickVal = Vector2.zero;

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

    private SixenseHand hand;

    private void Awake() {
        hand = GetComponent<SixenseHand>();
    }

    private void Update() {
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

        if (isEnabled()) {
			int buttonCounter = 0;

			foreach (SixenseButtons button in System.Enum.GetValues(typeof(SixenseButtons))) {
				bool press = hand.m_controller.GetButton(button);
				bool pressDown = hand.m_controller.GetButtonDown(button);
				bool pressUp = hand.m_controller.GetButtonUp(button);

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
				
			triggerVal = hand.m_controller.Trigger;

			joystickVal = new Vector2(hand.m_controller.JoystickX, hand.m_controller.JoystickY);
		}
	}

    public bool isEnabled() {
        return handsController.IsControllerActive(hand.m_controller);
    }

}
