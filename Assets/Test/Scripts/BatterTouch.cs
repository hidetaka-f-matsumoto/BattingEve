using UnityEngine;
using System.Collections;
using SmoothMoves;

public class BatterTouch : TouchObj
{
	public enum e_Stat {
		NONE,
		STAND,
		BACKSWING,
		SWING,
		
		END
	};
	public GameObject		m_ComInfo;
	CommonInfo				m_ComInfoScript;
	public BoneAnimation	m_MyAnim;
	public float			m_fSwingTime;
	float					m_fSwingTimer;
	e_Stat					m_eStat;

	protected override void Start()
	{
		Init( true );
		AddTouchMode( TouchObj.e_Mode.TAP );
		AddTouchMode( TouchObj.e_Mode.DTAP );
	}
	
	protected override void Init( bool _bMode )
	{
		base.Init( _bMode );
		m_fSwingTimer = m_fSwingTime;
		Stand();
	}
	
	void OnEnable()
	{
		m_ComInfoScript = m_ComInfo.GetComponent<CommonInfo>();
	}

	protected override void Update()
	{
		base.Update();

		// Change status by situation.
		switch( m_ComInfoScript.m_eGameSeq ) {
		case e_GameSeq.PLAYBALL:
		case e_GameSeq.PITCHER_SET:
			Stand();
			break;
		case e_GameSeq.PITCHER_THROW:
			BackSwing();
			break;
		default:
			break;
		}

		switch( m_eStat ) {
		case e_Stat.SWING:
			m_fSwingTimer -= Time.deltaTime;
			if( 0.0f > m_fSwingTimer ) { Init( false ); }
			break;
		default:
			break;
		}
	}
	
	protected override void OnTap()
	{
		Swing();
		m_Touch.m_ePhase = e_TouchPhase.HANDLE;
	}

	public void Stand()
	{
		m_eStat = e_Stat.STAND;
		m_MyAnim.CrossFade( "Stand" );
	}
	
	public void Swing()
	{
		switch( m_eStat ) {
		case e_Stat.STAND:
		case e_Stat.BACKSWING:
			m_eStat = e_Stat.SWING;
			m_MyAnim.CrossFade( "Swing" );
			break;
		default:
			break;
		}
	}

	public void BackSwing()
	{
		switch( m_eStat ) {
		case e_Stat.STAND:
			m_eStat = e_Stat.BACKSWING;
			m_MyAnim.CrossFade( "BackSwing" );
			break;
		default:
			break;
		}
	}
}
