using UnityEngine;
using System.Collections;

public class BallMove : MoveObj
{
	public enum e_Stat
	{
		NONE = 0,
		THROWING,
		THROWED,
		HITTED,

		END
	};
	public enum e_Stuff
	{
		NONE = 0,
		BEGIN,
		SLOW = BEGIN,
		STRAIGHT,
		SLIDER,
		CURVE,
		FORK,
		SINKER,
		SHUTE,
		
		END
	};
	public struct ThrowParam
	{
		public e_Stuff	m_eStuff;
		public int		m_iX;
		public int		m_iY;
		public void Init()
		{
			m_eStuff = BallMove.e_Stuff.NONE;
			m_iX = 0;
			m_iY = 0;
		}
		public void Copy( ThrowParam _param )
		{
			m_eStuff = _param.m_eStuff;
			m_iX = _param.m_iX;
			m_iY = _param.m_iY;
		}
	};
	public GameObject		m_ComInfo;
	CommonInfo				m_ComInfoScript;
	public GameObject		m_Camera;
	public GameObject		m_Batter;
	public float			m_fPitchTime;
	float					m_fPitchTimer;
	e_Stat					m_eStat;
	ThrowParam				m_Throw;
	
	protected override void Start()
	{
		base.Start();
	}
	
	void OnEnable()
	{
		m_ComInfoScript = m_ComInfo.GetComponent<CommonInfo>();
	}
	
	public void Init()
	{
		m_fPitchTimer = m_fPitchTime;
		m_eStat = e_Stat.NONE;
	 	m_Throw.Init();
		gameObject.rigidbody.useGravity = false;
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.angularVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	private void Update()
	{
		switch( m_eStat ) {
		case e_Stat.NONE:
			m_fPitchTimer -= Time.deltaTime;
			if( 0.0f > m_fPitchTimer ) {
				Throw( m_Throw );
				m_fPitchTimer = m_fPitchTime;
			}
			break;
		case e_Stat.THROWING:
			switch( m_Throw.m_eStuff ) {
			case e_Stuff.NONE:
			case e_Stuff.SLOW:
				gameObject.rigidbody.velocity = new Vector3(0.0f,1.6f,-4.0f);
				gameObject.rigidbody.useGravity = true;
				Physics.gravity = new Vector3(0.0f,-3.0f,0.0f);
				m_eStat = e_Stat.THROWED;
				break;
			case e_Stuff.STRAIGHT:
				gameObject.rigidbody.velocity = new Vector3(0.0f,0.0f,-8.0f);
				gameObject.rigidbody.useGravity = true;
				Physics.gravity = new Vector3(0.0f,-1.0f,0.0f);
				m_eStat = e_Stat.THROWED;
				break;
			default:
				break;
			}
			m_ComInfoScript.m_eGameSeq = e_GameSeq.PITCHER_THROW;
			break;
		case e_Stat.THROWED:
			if( ShouldReturn() ) {
				Return();
				m_ComInfoScript.m_eGameSeq = e_GameSeq.BEGIN;
			}
			break;
		case e_Stat.HITTED:
			if( ShouldReturn() ) {
				Return();
				m_ComInfoScript.m_eGameSeq = e_GameSeq.BEGIN;
			}
			break;
		default:
			break;
		}
	}
	
	void OnGUI()
	{
		GUILayout.BeginVertical("box");
		GUILayout.Label( m_Throw.m_eStuff.ToString() );
		GUILayout.EndVertical();
	}

	bool ShouldReturn()
	{
		if( 0.16f > rigidbody.velocity.magnitude
			|| -1.0f > transform.position.y
		) {
			return true;
		}
		return false;
	}
	
	public void Throw( ThrowParam _param )
	{
		if( e_Stat.NONE != m_eStat ) return;
		m_Throw.Copy( _param );
		m_eStat = e_Stat.THROWING;
	}
	
	public void SetStuff( ThrowParam _param )
	{
		m_Throw = _param;
	}

	public void NextStuff()
	{
		m_Throw.m_eStuff++;
		if( e_Stuff.END == m_Throw.m_eStuff ) m_Throw.m_eStuff = e_Stuff.BEGIN;
	}

	public void Return()
	{
		m_Camera.SendMessage( "Return" );
		Init();
		base.Return();
	}
	
	public void ImpactForce( Vector3 _vF )
	{
		gameObject.rigidbody.useGravity = true;
		Physics.gravity = new Vector3(0.0f,-3.0f,0.0f);
		gameObject.rigidbody.AddForce( _vF, ForceMode.Impulse );
		m_Camera.SendMessage( "Trace" );
		m_eStat = e_Stat.HITTED;
	}
}
