using UnityEngine;
using System.Collections;

public class SwitchUnit : MonoBehaviour {

	public Material openUnit;

	private AudioSource ausou;
	private bool opening = false;
	private int lol = 0;

	// Use this for initialization
	void Start () {
		ausou = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (opening == true && lol < 16)
		{
			transform.GetChild (1).transform.position += transform.right / 8;
			lol++;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "MainCamera" && Input.GetKeyDown ("e") && other.GetComponent<CameraController> ().keycard == true) {
			transform.GetChild (1).GetComponent<AudioSource>().Play ();
			//transform.GetChild (1).gameObject.SetActive (false);
			opening = true;
			transform.GetChild (0).GetComponent<MeshRenderer> ().material = openUnit;
		}
		else if (other.tag == "MainCamera" && Input.GetKeyDown ("e"))
		{
			ausou.Play();
		}
	}

}
