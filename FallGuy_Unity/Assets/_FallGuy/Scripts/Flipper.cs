using UnityEngine;
using System.Collections;

public enum FlipperType {
	Left,
	Right
}

public class Flipper : MonoBehaviour {
	public FlipperType flipperType;
	public float torque = 100;

	private bool flipOnFixed = false;

	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) flipOnFixed = true;
	}

	void FixedUpdate() {
		if (flipOnFixed) {
			Flip();
			flipOnFixed = false;
		}
	}

	public void Flip() {
		float t = 0;
		if (flipperType == FlipperType.Right) t = -torque;
		else if (flipperType == FlipperType.Left) t = torque;

		rigidbody.AddTorque(0, 0, t * rigidbody.mass, ForceMode.Impulse);
	}
}
