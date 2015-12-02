using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {

	public CameraController camera;

	private Light lc;
	private int lightGlow = 1;
	private AudioSource ausou;
	
	// Use this for initialization
	void Start ()
	{
		lc = GetComponent<Light> ();
		lc.enabled = false;
		ausou = GetComponent<AudioSource> ();
		camera.OnAlarmTriggered += AlarmListener;
		camera.OnAlarmDisabled += AlarmDisabler;
		StartCoroutine (ChangeIntensity());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lc.enabled == true)
		{
			lc.intensity += 0.2f * lightGlow;
		}
	}

	void AlarmListener()
	{
		lc.enabled = true;
		if (ausou.isPlaying == false)
			ausou.Play ();
	}

	void AlarmDisabler()
	{
		lc.enabled = false;
		if (ausou.isPlaying)
			ausou.Stop ();
	}

	IEnumerator ChangeIntensity()
	{
		while (true)
		{
			if (lc.enabled == true)
				lightGlow = -lightGlow;
			yield return new WaitForSeconds(0.8f);

		}
	}
}
