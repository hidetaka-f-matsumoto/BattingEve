using UnityEngine;
using System.Collections;

public class MoveObjByGyroRot : MoveObjByGyro {
	bool		m_bEnable;

	// Use this for initialization
	protected virtual void Start()
	{
		m_bEnable = true;
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		if( !m_bEnable ) return;
		gameObject.rigidbody.transform.position += 0.02f * ConvCoord_iPhone2Unity_Rot( m_GyParams.m_vRotRate );
	}
	
	// Enable Gyro
	protected virtual void OnOff( bool bOn )
	{
		m_bEnable = bOn;
	}
}
