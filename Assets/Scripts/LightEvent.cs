using UnityEngine;
using System.Collections;

public class LightEvent : MonoBehaviour {

	private Light lc;

	// Use this for initialization
	void Start () {
		lc = GetComponent<Light> ();
		StartCoroutine (ChangeIntensity());

	}
	
	// Update is called once per frame
	void Update () {
		if (lc.intensity < 2f)
			lc.intensity += 0.4f;
	}

	IEnumerator ChangeIntensity()
	{
		while (true)
		{
			lc.intensity = 0f;
			yield return new WaitForSeconds(Random.Range(0.1f, 1f));
		}
	}
}
