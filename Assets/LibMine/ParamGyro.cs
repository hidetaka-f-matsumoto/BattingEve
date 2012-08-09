using UnityEngine;
using System.Collections;

public class ParamGyro {
	public Vector3			m_vRotRate = new Vector3();
	public Vector3			m_vRotRateUnbd = new Vector3();
	public Vector3			m_vGrav = new Vector3();
	public Vector3			m_vUsrAcc = new Vector3();
	public Quaternion		m_qAttd = new Quaternion();
	
	public void Set( Gyroscope _gyro )
	{
		m_vRotRate		= _gyro.rotationRate;
		m_vRotRateUnbd	= _gyro.rotationRateUnbiased;
		m_vGrav 		= _gyro.gravity;
		m_vUsrAcc		= _gyro.userAcceleration;
		m_qAttd			= _gyro.attitude;
	}
}
