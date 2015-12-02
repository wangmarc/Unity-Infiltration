using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public int discretion = 0;
	public int speed;
	public int mouseSens;
	public bool keycard = false;
	public bool files = false;
	public Image discretionBar;
	public Image alarmBar;
	
	public delegate void AlarmEvent ();
	public delegate void Outcome ();
	public event AlarmEvent OnAlarmTriggered;
	public event AlarmEvent OnAlarmDisabled;
	public event Outcome Failed;
	public event Outcome Complete;

	private bool alarmTriggered = false;
	private CharacterController cc;
	private Image img;
	private Vector3 direction;
	private int sprint = 1;
	private AudioSource[] ausou;
	
	float rotationY = 0.0f;
	float rotationX = 180.0f;
	
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		discretionBar.enabled = true;
		alarmBar.enabled = false;
		ausou = GetComponents<AudioSource> ();
		ausou[0].Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w"))
			direction += transform.forward;
		if (Input.GetKey ("s"))
			direction += -transform.forward;
		if (Input.GetKey ("a"))
			direction += -transform.right;
		if (Input.GetKey ("d"))
			direction += transform.right;

		if (Input.GetKey (KeyCode.LeftShift) && direction != Vector3.zero) {
			sprint = 2;
			discretion += 10;
			if (ausou[2].isPlaying == false)
				ausou[2].Play ();
		}
		else if (Input.GetKeyUp (KeyCode.LeftShift))
		{
			sprint = 1;
			ausou[2].Stop();
		}
		cc.SimpleMove (direction.normalized * Time.deltaTime * speed * sprint);

		rotationX += Input.GetAxis ("Mouse X") * mouseSens * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * mouseSens * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, -90, 90);
		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		
		direction = Vector3.zero;

		discretion -= 1;

		if (discretion > 750)
		{
			discretionBar.enabled = false;
			alarmBar.enabled = true;
			alarmBar.fillAmount = discretion * 0.001f;
			if (ausou[0].isPlaying)
			{
				ausou[0].Stop();
				ausou[1].Play();
			}
			if (alarmTriggered == false)
			{
				OnAlarmTriggered();
				alarmTriggered = true;
			}
			if (discretion > 1000)
			{
				Failed();
			}
		}
		else
		{
			discretionBar.enabled = true;
			alarmBar.enabled = false;
			discretionBar.fillAmount = discretion * 0.001f;
			if (ausou[1].isPlaying)
			{
				ausou[1].Stop();
				ausou[0].Play();
			}
			if (alarmTriggered == true)
			{
				OnAlarmDisabled();
				alarmTriggered = false;
			}
		}
		if (discretion < 0)
			discretion = 0;
		if (files == true)
			Complete ();
	}
}