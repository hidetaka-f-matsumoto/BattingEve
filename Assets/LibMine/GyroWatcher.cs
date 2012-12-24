using UnityEngine;
using System.Collections;

public class GyroWatcher : BaseObj
{
	public ParamGyro		m_GyParams;
	bool					m_bTest;

	void Start()
	{
		Input.gyro.enabled = true;
		m_GyParams = new ParamGyro();
		m_bTest = false;
	}

	void Update()
	{
		if( m_bTest )
		{
			m_bTest = false;
			return;
		}
		m_GyParams.Set( Input.gyro );
	}
	
	// Test
	public virtual void GyroTest( ParamGyro _params )
	{
		m_GyParams = _params;
		m_bTest = true;
	}
}
