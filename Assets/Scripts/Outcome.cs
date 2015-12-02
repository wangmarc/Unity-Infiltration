using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Outcome : MonoBehaviour {

	public CameraController camera;

	// Use this for initialization
	void Start () {
		camera.Failed += FailListener;
		camera.Complete += CompleteListener;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CompleteListener()
	{
		StartCoroutine (Winrar ());
	}

	void FailListener()
	{
		StartCoroutine (Noob ());
	}

	IEnumerator Noob()
	{
		transform.FindChild ("Lost").gameObject.SetActive (true);
		yield return new WaitForSeconds (2f);
		Application.LoadLevel (Application.loadedLevel);
	}

	IEnumerator Winrar()
	{
		transform.FindChild ("Winrar").gameObject.SetActive (true);
		yield return new WaitForSeconds (2f);
		Application.LoadLevel (Application.loadedLevel);
	}
}