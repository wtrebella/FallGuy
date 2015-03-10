using UnityEngine;
using System.Collections;

public class PlayerPiece : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll) {
		Flipper flipper = coll.gameObject.GetComponent<Flipper>();
		if (flipper) {
			if (flipper.canGivePoints) GameManager.instance.AddToScore(flipper.GivePoints());
		}
	}
}
