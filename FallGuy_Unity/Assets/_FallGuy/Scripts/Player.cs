using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	void Start () {
	
	}
	
	void Update () {
	
	}

	void FixedUpdate() {

	}

	void OnCollisionEnter(Collision coll) {
		Flipper flipper = coll.gameObject.GetComponent<Flipper>();
		if (flipper) {
			if (flipper.canGivePoints) GameManager.instance.AddToScore(flipper.GivePoints());
		}
	}
}
