using UnityEngine;
using System.Collections;

public class BattingCursorGyro : GyroObj
{
	protected override void OnAcceleration()
	{
		gameObject.rigidbody.transform.position += 0.02f * ConvCoord_iPhone2Unity( m_GyScript.m_GyParams.m_vRotRate );
	}

	protected override void OnRotation()
	{
		gameObject.rigidbody.transform.position += 0.02f * ConvCoord_iPhone2Unity_Rot( m_GyScript.m_GyParams.m_vRotRate );
	}
}
