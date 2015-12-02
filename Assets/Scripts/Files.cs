using UnityEngine;
using System.Collections;

public class Files : MonoBehaviour {

	public delegate void Outcome ();
	public event Outcome MissionComplete;

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
			gameObject.SetActive(false);
			other.GetComponent<CameraController>().files = true;
		}
	}
}
