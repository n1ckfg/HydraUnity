using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixenseSettings : MonoBehaviour {

	public float scale = 0f;
	public float triggerThreshold = 0.1f;
	public Vector3 offset = Vector3.zero;
	public bool showCursor = true;

	void Start() {
		Cursor.visible = showCursor;
	}

}
