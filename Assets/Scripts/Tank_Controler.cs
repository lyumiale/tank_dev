using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tank_Controler : MonoBehaviour {

	private float accell_value;
	private float battery_value;
	Slider accell_slider;
	Slider battery_slider;

	private GameObject battery = null;

	private GameObject wheel1 = null;
	private GameObject wheel2 = null;
	private GameObject wheel3 = null;
	private GameObject wheel4 = null;
	private GameObject wheel5 = null;
	private GameObject wheel6 = null;
	private GameObject wheel7 = null;

	private float wheel_speed = -5.0f;

	void Start () {
		battery = GameObject.Find ("battery");
		accell_slider = GameObject.Find ("Accell_Slider").GetComponent<Slider> ();
		battery_slider = GameObject.Find ("Battery_Slider").GetComponent<Slider> ();
		wheel1 = GameObject.Find ("wheel1");
		wheel2 = GameObject.Find ("wheel2");
		wheel3 = GameObject.Find ("wheel3");
		wheel4 = GameObject.Find ("wheel4");
		wheel5 = GameObject.Find ("wheel5");
		wheel6 = GameObject.Find ("wheel6");
		wheel7 = GameObject.Find ("wheel7");

	}

	void Update () {
		accell_value = accell_slider.value;
		battery_value = battery_slider.value;

		if (accell_value == 2) {
			wheel1.transform.Rotate (0, 0, wheel_speed);
			wheel2.transform.Rotate (0, 0, wheel_speed);
			wheel3.transform.Rotate (0, 0, wheel_speed);
			wheel4.transform.Rotate (0, 0, wheel_speed);
			wheel5.transform.Rotate (0, 0, wheel_speed);
			wheel6.transform.Rotate (0, 0, wheel_speed);
			wheel7.transform.Rotate (0, 0, wheel_speed);
		}

		iTween.RotateTo(battery,iTween.Hash("z",battery_value , "time", 1));
			
	}
}
