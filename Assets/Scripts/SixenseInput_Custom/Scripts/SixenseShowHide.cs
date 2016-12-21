using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixenseShowHide : MonoBehaviour {

	public SixenseCtl sixCtl;
	public GameObject[] target;

	void Start() {
		for (int i = 0; i < target.Length; i++) {
			target[i].SetActive (false);
		}
	}

	void Update() {
		 if (sixCtl.button3Down) {
			for (int i = 0; i < target.Length; i++) {
				target[i].SetActive(true);
			}
		} else if (sixCtl.button3Up) {
			for (int i = 0; i < target.Length; i++) {
				target[i].SetActive (false);
			}
		}
	}

}
