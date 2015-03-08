using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public bool useFixedUpdate = false;
	public bool xFollow = true;
	public bool yFollow = true;
	public float smoothTime = 0.2f;
	public Camera cam;

	private Vector3 delta = Vector3.zero;
	private Vector3 smooth;

	void Start () {
		UpdateDelta();
	}

	public void UpdateDelta() {
		delta = cam.transform.position - transform.position;
	}
	
	void Update () {
		if (useFixedUpdate) return;

		UpdateCamPosition();
	}

	void FixedUpdate() {
		if (!useFixedUpdate) return;

		UpdateCamPosition();
	}

	void UpdateCamPosition() {
		Vector3 pos = cam.transform.position;
		if (xFollow) pos.x = transform.position.y + delta.x;
		if (yFollow) pos.y = transform.position.y + delta.y;
		cam.transform.position = Vector3.SmoothDamp(cam.transform.position, pos, ref smooth, smoothTime);
	}
}
