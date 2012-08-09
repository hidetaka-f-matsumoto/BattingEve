using UnityEngine;
using System.Collections;

public class BattingCursor : MoveObjByGyroRot {
	public GameObject			m_BattSwingPlane;

	// Use this for initialization
	protected override void Start()
	{
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
		BattSwingPlane script = m_BattSwingPlane.GetComponent<BattSwingPlane>();
		script.Move(gameObject.transform.position);
		//m_BattSwingPlane.SendMessage( "Move", gameObject.transform.position );
	}
	
	protected override Vector3 ConvCoord_iPhone2Unity_Rot( Vector3 vSrc )
	{
		Vector3 vDst;
		vDst.x = vSrc.x;
		vDst.y = vSrc.y;
		vDst.z = 0.0f;
		return vDst;
	}
}
