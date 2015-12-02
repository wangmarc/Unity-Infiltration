using UnityEngine;
using System.Collections;

public class Keycard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "MainCamera" && Input.GetKeyDown ("e"))
		{
			other.GetComponent<CameraController> ().keycard = true;
			gameObject.SetActive(false);
		}
	}

}
