using UnityEngine;
using System.Collections;

public class Ball : MoveObj {
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
		SLOW,
		STRAIGHT,
		SLIDER,
		CURVE,
		FORK,
		SINKER,
		SHUTE,
		
		END
	};
	public GameObject	m_Camera;
	public GameObject	m_Batter;
	public float		m_fPitchTime;
	float				m_fPitchTimer;
	e_Stat				m_eStat;
	e_Stuff				m_eStuff;

	protected override void Init()
	{
		base.Init();
		m_fPitchTimer = m_fPitchTime;
		m_eStat = e_Stat.NONE;
		m_eStuff = e_Stuff.NONE;
		gameObject.rigidbody.useGravity = false;
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.angularVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		switch( m_eStat ) {
		case e_Stat.NONE:
			m_fPitchTimer -= Time.deltaTime;
			if( 0.0f > m_fPitchTimer ) {
				if( e_Stuff.NONE == m_eStuff ) {
					Throw( e_Stuff.SLOW );
				} else {
					Throw( m_eStuff );
				}
				m_fPitchTimer = m_fPitchTime;
			}
			break;
		case e_Stat.THROWING:
			switch( m_eStuff ) {
			case e_Stuff.SLOW:
				gameObject.rigidbody.velocity = new Vector3(0.0f,1.6f,-4.0f);
				gameObject.rigidbody.useGravity = true;
				Physics.gravity = new Vector3(0.0f,-3.0f,0.0f);
				m_eStat = e_Stat.THROWED;
				
				m_Batter.SendMessage( "BackSwing" );
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
			break;
		case e_Stat.THROWED:
			if( ShouldReturn() ) {
				Return();
			}
			break;
		case e_Stat.HITTED:
			if( ShouldReturn() ) {
				Return();
			}
			break;
		default:
			break;
		}
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
	
	public void Throw( e_Stuff _eStuff )
	{
		if( e_Stat.NONE != m_eStat ) return;
		if( e_Stuff.NONE == _eStuff ) _eStuff = e_Stuff.SLOW;
		m_eStuff = _eStuff;
		m_eStat = e_Stat.THROWING;
	}
	
	public void SetStuff( e_Stuff _eStuff )
	{
		m_eStuff = _eStuff;
	}

	public void Return()
	{
		m_Camera.SendMessage( "Return" );
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
