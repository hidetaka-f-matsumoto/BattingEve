using UnityEngine;
using System.Collections;

public class BattingCursor : MoveObj
{
	public GameObject		m_ComInfo;
	CommonInfo				m_ComInfoScript;
	
	protected override void Start()
	{
		base.Start();
	}
	
	void OnEnable()
	{
		m_ComInfoScript = m_ComInfo.GetComponent<CommonInfo>();
	}

	//	BattSwingPlane script = m_BattSwingPlane.GetComponent<BattSwingPlane>();
//	script.Move(gameObject.transform.position);
}
