using UnityEngine;
using System.Collections;

public enum FlipperType {
	Left,
	Right
}

public class Flipper : MonoBehaviour {
	public FlipperType flipperType;
	public float pointCooldown = 0.2f;
	public float flipCooldown = 0.2f;
	public int pointValue = 0;
	public float torque = 100;

	public bool canGivePoints {
		get {
			return pointCooldownTimer >= pointCooldown && isFlipping;
		}
	}

	public bool isFlipping {
		get {
			return flipCooldownTimer < flipCooldown;
		}
	}

	private float flipCooldownTimer = 0;
	private float pointCooldownTimer = 0;
	private bool flipOnFixed = false;

	void Start () {
		pointCooldownTimer = pointCooldown;
		flipCooldownTimer = flipCooldown;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (!isFlipping) flipOnFixed = true;
		}
	}

	void FixedUpdate() {
		if (flipOnFixed) {
			Flip();
			flipOnFixed = false;
		}

		flipCooldownTimer += Time.fixedDeltaTime;
		pointCooldownTimer += Time.fixedDeltaTime;
	}

	public void Flip() {
		float t = 0;
		if (flipperType == FlipperType.Right) t = -torque;
		else if (flipperType == FlipperType.Left) t = torque;

		flipCooldownTimer = 0;

		rigidbody.AddTorque(0, 0, t * rigidbody.mass, ForceMode.Impulse);
	}

	public int GivePoints() {
		pointCooldownTimer = 0;
		return pointValue;
	}
}
