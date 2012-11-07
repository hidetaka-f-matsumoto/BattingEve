using UnityEngine;
using System.Collections;

public class GyroObj : MonoBehaviour
{
	public enum e_Mode
	{
		NONE 			= 0x00000000,
		ACCELERATION	= 0x00000001,
		ROTATION		= 0x00000002,
	};
	
	public GameObject		m_GyWatcher;
	GyroWatcher				m_GyScript;
	e_Mode					m_eMode;

	// Use this for initialization
	protected virtual void Start()
	{
		m_eMode = e_Mode.NONE;
		m_GyScript = m_GyWatcher.GetComponent<GyroWatcher>();
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		Debug.Log(m_GyScript.m_GyParams.m_vRotRate.ToString());

		if( e_Mode.NONE != (e_Mode.ACCELERATION & m_eMode) )
		{
			gameObject.rigidbody.transform.position += 0.02f * ConvCoord_iPhone2Unity( m_GyScript.m_GyParams.m_vRotRate );
		}
		if( e_Mode.NONE != (e_Mode.ROTATION & m_eMode) )
		{
			gameObject.rigidbody.transform.position += 0.02f * ConvCoord_iPhone2Unity_Rot( m_GyScript.m_GyParams.m_vRotRate );
		}
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

	public virtual void SetMode( e_Mode _eMode )
	{
		m_eMode = _eMode;
	}
}
