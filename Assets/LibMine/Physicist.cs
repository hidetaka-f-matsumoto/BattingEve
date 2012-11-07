using UnityEngine;
using System.Collections;

public class Physicist : MonoBehaviour {
	public GameObject	m_PhysObj;

	bool				m_bPhysAcc;
	int					m_iPhysAcc;
	float				m_fPhysAcc;
	// Sensor parms
	ParamGyro			m_GyParams;
	Vector3				m_vGyGrav, m_vGyAccNow, m_vGyAccPre, m_vAccNow, m_vAccPre;
	// World physics
	Vector3				m_vWldGrav, m_vWldIForce, m_vWldVelo;
	Vector3		 		m_vWldIForceMax, m_vWldVeloMax;
	int					m_iMeanIdx, m_iMeanNum;
	Vector3[]			m_vWldVeloTmp;
	
	// Use this for initialization
	void Start()
	{
		m_GyParams = new ParamGyro();

		m_vGyGrav = new Vector3(0.0f, 0.0f, 0.0f);
		m_vGyAccNow = new Vector3(0.0f, 0.0f, 0.0f);
		m_vGyAccPre = new Vector3(0.0f, 0.0f, 0.0f);
		m_vAccNow = new Vector3(0.0f, 0.0f, 0.0f);
		m_vAccPre = new Vector3(0.0f, 0.0f, 0.0f);

		m_vWldGrav = new Vector3(0.0f, -9.8f, 0.0f);
		m_vWldIForce = new Vector3(0.0f, 0.0f, 0.0f);
		m_vWldVelo = new Vector3(0.0f, 0.0f, 0.0f);

		m_vWldIForceMax = new Vector3(0.0f, 0.0f, 0.0f);
		m_vWldVeloMax = new Vector3(0.0f, 0.0f, 0.0f);
		
		m_iMeanIdx = 0;
		m_iMeanNum = 10;
		m_vWldVeloTmp = new Vector3[m_iMeanNum];

		Init();
	}
	
	// Initialization
	void Init()
	{
		m_bPhysAcc = false;
		m_iPhysAcc = 0;
		m_fPhysAcc = 1.0f;

		m_vGyGrav = m_vGyAccNow =  m_vGyAccPre = m_vAccNow = m_vAccPre = Vector3.zero;

		m_vWldGrav.x = 0.0f; m_vWldIForce.y = -9.8f; m_vWldIForce.z = 0.0f;
		m_vWldIForce = m_vWldVelo = Vector3.zero;
		m_vWldIForceMax = m_vWldVeloMax = Vector3.zero;
		for( int i=0; i<m_iMeanNum; i++ ) {
			m_vWldVeloTmp[i] = Vector3.zero;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		/*
		InputToPhysics();

		AcceleratePhysics();

		WorldPhysics();
		//PhysicsToRices();
		*/
	}
	
	void OnGUI()
	{
		if( m_vWldIForceMax.magnitude < m_vWldIForce.magnitude ) {
			m_vWldIForceMax = m_vWldIForce;
		}
		if( m_vWldVeloMax.magnitude < m_vWldVelo.magnitude ) {
			m_vWldVeloMax = m_vWldVelo;
		}
		/*
		GUILayout.BeginVertical("box");

		GUILayout.Label( (100+m_iPhysAcc).ToString() );
		GUILayout.Label( m_vWldGrav.ToString() );
		GUILayout.Label( m_vWldIForce.ToString() );
		GUILayout.Label( m_vWldIForceMax.ToString() );
		GUILayout.Label( m_vWldVelo.ToString() );
		GUILayout.Label( m_vWldVeloMax.ToString() );

		GUILayout.Label( m_GyParams.m_vRotRate.ToString() );
		GUILayout.Label( m_GyParams.m_vRotRateUnbd.ToString() );
		GUILayout.Label( m_GyParams.m_vGrav.ToString() );
		GUILayout.Label( m_GyParams.m_qAttd.ToString() );
		GUILayout.Label( m_GyParams.m_vUsrAcc.ToString() );
		GUILayout.Label( m_vAccNow.ToString() );

		GUILayout.EndVertical();
		*/
	}
	
	void InputToPhysics()
	{
		// gravity by the rotation of the device.
		m_vWldGrav = 9.8f * ConvCoord_iPhone2Unity( m_GyParams.m_vGrav );

		// interial force by the device's acceleration.
		Vector3 vGyAccMod = Mathf.Pow( m_GyParams.m_vUsrAcc.magnitude, 0.3f ) * m_GyParams.m_vUsrAcc.normalized;
		m_vWldIForce = -9.8f * ConvCoord_iPhone2Unity( vGyAccMod );
		
		// relative velocity by the device's move.
		/*
		m_vWldVeloTmp[m_iMeanIdx] = ConvCoord_iPhone2Unity( m_vGyAccNow - m_vGyAccPre );
		if( m_iMeanIdx == m_iMeanNum-1 ) {
			m_iMeanIdx = 0;
		} else {
			m_iMeanIdx++;
		}
		for( int i=0; i<m_iMeanNum; i++ ) {
			m_vWldVelo += m_vWldVeloTmp[i];
		}
		m_vWldVelo /= (float)m_iMeanNum;
		*/
		//m_vWldVelo += 10.0f*ConvCoord_iPhone2Unity( m_vGyAccNow - m_vGyAccPre );
	}

	void WorldPhysics()
	{
		// gravity.
		Physics.gravity = m_vWldGrav;
	}
	
	void PhysicsToRices()
	{
		// interial force.
		if( 1.0f < m_vWldIForce.magnitude ) {
			//m_PhysObj.SendMessage( "InertialForce", m_vWldIForce );
			//m_Rices.BroadcastMessage( "InertialForce", m_vWldIForce, SendMessageOptions.DontRequireReceiver );
		}
		
		// relative velocity.
		m_PhysObj.BroadcastMessage( "Velocity", m_vWldVelo, SendMessageOptions.DontRequireReceiver );
	}
	
	void AcceleratePhysics()
	{
		if( !m_bPhysAcc ) return;

		m_vWldGrav *= m_fPhysAcc;
		m_vWldIForce *= m_fPhysAcc;
		m_vWldVelo *= m_fPhysAcc;
		
		m_bPhysAcc = false;
	}
	
	Vector3 ConvCoord_iPhone2Unity( Vector3 vSrc )
	{
		Vector3 vDst;
		vDst.x = -1.0f * vSrc.y;
		vDst.y = vSrc.z;
		vDst.z = vSrc.x;
		return vDst;
	}
	/*
	public void GyroGravity( Vector3 _vGrav )
	{
		m_vGyGrav = _vGrav;
	}
	
	public void GyroAcceleration( Vector3 _vAcc )
	{
		if( 0.2f > _vAcc.magnitude ) {
			_vAcc = Vector3.zero;
		}
		m_vGyAccPre = m_vGyAccNow;
		m_vGyAccNow = _vAcc;
	}
	*/
	public void Gyro( ParamGyro _params )
	{
		m_GyParams = _params;
	}
	
	public void Acceleration( Vector3 _vAcc )
	{
		m_vAccPre = m_vAccNow;
		m_vAccNow = _vAcc;
	}
	
	public void PhysAccelerate( bool _b )
	{
		m_bPhysAcc = true;
		m_iPhysAcc += _b ? 10 : -10;
		m_fPhysAcc = _b ? 1.1f : 1.0f/1.1f;
	}
}
