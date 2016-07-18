using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tank_Controler : MonoBehaviour {

	private float accell_value;
	private float battery_value;
	Slider accell_slider;
	Slider battery_slider;

	//tank
	private GameObject main_tank = null;
	private float tank_speed;

	private GameObject battery = null;

	//wheel系
	private GameObject wheel1 = null;
	private GameObject wheel2 = null;
	private GameObject wheel3 = null;
	private GameObject wheel4 = null;
	private GameObject wheel5 = null;
	private GameObject wheel6 = null;
	private GameObject wheel7 = null;
	private float wheel_speed;

	//BG系
	private float scroll;
	private float bg_1_speed = 0.01f;
	private MeshRenderer bg_1_MeshRen = null;
	private GameObject bg_1 = null;

	private GameObject m_camera = null;
	private Vector3 def_offset = Vector3.zero;

	void Start () {
		m_camera = GameObject.Find ("Main Camera");

		main_tank = GameObject.Find ("tank");

		//BG系
		bg_1_MeshRen = GameObject.Find("BG_1").GetComponent<MeshRenderer>();
		bg_1 = GameObject.Find ("BG_1");
		def_offset = bg_1.transform.position - m_camera.transform.position;

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
		//アクセルからのwheelの挙動制御
		accell_value = accell_slider.value;
		battery_value = battery_slider.value;

		//switchで使うためintパース
		int I_accell_value = Mathf.CeilToInt (accell_value);

		//各ステータスでのスピード指定
		if (I_accell_value != 1) {
			switch (I_accell_value) {
			case 2:
				wheel_speed = -3.0f;
				break;
			case 3:
				wheel_speed = -5.0f;
				break;
			case 4:
				wheel_speed = -8.0f;
				break;
			case 0:
				wheel_speed = 3.0f;
				break;
			}

			Move_Tank ();
			Move_BG ();
		}
			
		iTween.RotateTo(battery,iTween.Hash("z",battery_value , "time", 1 ,"easeType",iTween.EaseType.linear));
			
	}

	//車体の移動とタイヤの回転
	private void Move_Tank(){
		//実際に車輪を回転させる
		wheel1.transform.Rotate (0, 0, wheel_speed);
		wheel2.transform.Rotate (0, 0, wheel_speed);
		wheel3.transform.Rotate (0, 0, wheel_speed);
		wheel4.transform.Rotate (0, 0, wheel_speed);
		wheel5.transform.Rotate (0, 0, wheel_speed);
		wheel6.transform.Rotate (0, 0, wheel_speed);
		wheel7.transform.Rotate (0, 0, wheel_speed);

		//postionの移動
		main_tank.transform.Translate(0.05f,0,0);
	}

	private void Move_BG(){
		scroll = Mathf.Repeat (Time.time * bg_1_speed, 1);
		Vector2 offset = new Vector2 (scroll, 0);
		bg_1_MeshRen.sharedMaterial.SetTextureOffset ("_MainTex", offset);

		//カメラの位置が動くのに合わせて背景のpositionも移動させる
		Vector3 new_position = m_camera.transform.position + def_offset;
		bg_1.transform.position = new_position;
	}
}
