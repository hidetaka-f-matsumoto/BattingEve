using UnityEngine;
using System.Collections;

public class BattingCursorTouch : TouchObj
{
	protected override void OnTap()
	{
		Vector2 vTapPos = new Vector2(0.0f,0.0f);
		Vector2 vDummy = new Vector2(0.0f,0.0f);
		m_TchScript.m_TchParam.Get( TouchParam.e_Type.TAP, ref vTapPos, ref vDummy );
		gameObject.transform.position = ConvScreenPos2ObjPos( vTapPos );
	}
}
