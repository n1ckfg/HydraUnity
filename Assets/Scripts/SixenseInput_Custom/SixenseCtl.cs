using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixenseCtl : MonoBehaviour {

	public int ctlNum = 0;
	public Vector3 pos = Vector3.zero;
	public Quaternion rot = Quaternion.identity;
	public Vector3 scale = new Vector3(-0.1f, 0.1f, -0.1f);
	public Vector3 offset = Vector3.zero;
	public bool trigger = false;
	public float triggerVal = 0f;
	public bool button1 = false;
	public bool button2 = false;
	public bool button3 = false;
	public bool button4 = false;
	public Vector2 joystick = Vector2.zero;

	void Update() {
		if (SixenseInput.Controllers[ctlNum].Enabled) {
			pos = Vector3.Scale(SixenseInput.Controllers[ctlNum].Position, scale) + offset;
			rot = SixenseInput.Controllers[ctlNum].Rotation;
				
			//foreach (SixenseButtons button in System.Enum.GetValues( typeof( SixenseButtons ) )) {
				//trigger = SixenseInput.Controllers[ctlNum].GetButton(button);
			//}

			triggerVal = SixenseInput.Controllers[ctlNum].Trigger;
			if (triggerVal > 0f) {
				trigger = true;
			} else {
				trigger = false;
			}

			//~
			Debug.Log ("pos: " + pos + "\n" + "rot: " + rot + "\n" + "trigger: " + trigger);
			//~
			transform.position = pos;
			transform.rotation = rot;
		}
	}

}
