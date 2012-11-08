using UnityEngine;
using System.Collections;

public class BattingCursor : MoveObj
{
	public GameObject		m_ComInfo;
	CommonInfo				m_ComInfoScript;
	
	protected override void Start()
	{
		m_ComInfoScript = m_ComInfo.GetComponent<CommonInfo>();
		base.Start();
	}

	//	BattSwingPlane script = m_BattSwingPlane.GetComponent<BattSwingPlane>();
//	script.Move(gameObject.transform.position);
}
