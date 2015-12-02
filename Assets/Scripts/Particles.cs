using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider other)
	{
		if (transform.parent.GetComponent<ParticleSystem> ().isPlaying == true && other.tag == "MainCamera") {
			other.GetComponent<CameraController> ().discretion -= 20;
		}
	}
}
