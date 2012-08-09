using UnityEngine;
using System.Collections;

public class MoveObjByGyro : MonoBehaviour {
	// Sensor parms
	protected ParamGyro			m_GyParams;

	// Use this for initialization
	protected virtual void Start()
	{
		m_GyParams = new ParamGyro();
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
	}
	
	protected virtual void OnGUI()
	{
		GUI.Label( new Rect(10,200,200,20), m_GyParams.m_vRotRate.ToString() );
		GUI.Label( new Rect(10,220,200,20), m_GyParams.m_vRotRateUnbd.ToString() );
		GUI.Label( new Rect(10,240,200,20), m_GyParams.m_vGrav.ToString() );
		GUI.Label( new Rect(10,260,200,20), m_GyParams.m_qAttd.ToString() );
		GUI.Label( new Rect(10,280,200,20), m_GyParams.m_vUsrAcc.ToString() );
	}

	protected virtual Vector3 ConvCoord_iPhone2Unity( Vector3 vSrc )
	{
		Vector3 vDst;
		vDst.x = -1.0f * vSrc.y;
		vDst.y = vSrc.z;
		vDst.z = vSrc.x;
		return vDst;
	}

	protected virtual Vector3 ConvCoord_iPhone2Unity_Rot( Vector3 vSrc )
	{
		Vector3 vDst;		
		vDst.x = -1.0f * vSrc.y;
		vDst.y = vSrc.x;
		vDst.z = vSrc.z;
		return vDst;
	}

	public virtual void Gyro( ParamGyro _params )
	{
		m_GyParams = _params;
	}
}
