using UnityEngine;
using System.Collections;

public class SensorWatcher : MonoBehaviour {
	public GameObject		m_Cursor;
	ParamGyro				m_GyParams;

	// Use this for initialization
	void Start()
	{
		Input.gyro.enabled = true;
		m_GyParams = new ParamGyro();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		SensorToPhysicist();
	}

	// Send Sensor params to Physicist
	void SensorToPhysicist()
	{
		m_GyParams.Set( Input.gyro );
		m_Cursor.SendMessage("Gyro", m_GyParams );
	}
}
