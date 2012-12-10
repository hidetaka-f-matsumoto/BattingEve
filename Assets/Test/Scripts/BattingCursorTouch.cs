using UnityEngine;
using System.Collections;

public class BattingCursorTouch : TouchObj
{
	protected override void OnTap()
	{
		gameObject.transform.position = ConvScreenPos2ObjPos( m_Touch.m_vParam1 );
		m_Touch.m_ePhase = TouchObj.e_TouchPhase.HANDLE;
	}
}
