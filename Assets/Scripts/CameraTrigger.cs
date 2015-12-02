using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "MainCamera")
			other.GetComponent<CameraController>().discretion += 20;
	}
}
