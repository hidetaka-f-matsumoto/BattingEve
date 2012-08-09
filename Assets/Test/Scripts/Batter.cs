using UnityEngine;
using System.Collections;
using SmoothMoves;

public class Batter : MonoBehaviour {
	public enum e_Stat {
		NONE,
		STAND,
		BACKSWING,
		SWING,
		
		END
	};
	public BoneAnimation	m_MyAnim;
	public float			m_fSwingTime;
	float					m_fSwingTimer;
	e_Stat					m_eStat;
	bool					m_bSwitchAnim;

	// Use this for initialization
	void Start()
	{
		Init();
	}
	
	void Init()
	{
		m_fSwingTimer = m_fSwingTime;
		m_eStat = e_Stat.STAND;
		m_bSwitchAnim = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		switch( m_eStat ) {
		case e_Stat.SWING:
			m_fSwingTimer -= Time.deltaTime;
			if( 0.0f > m_fSwingTimer ) {
				Init();
			}
			break;
		default:
			break;
		}
		
		SwitchAnim();
	}

	// Switch Animation by state
	void SwitchAnim()
	{
		if( m_bSwitchAnim ) {
			switch( m_eStat ) {
			case e_Stat.STAND:
				m_MyAnim.CrossFade( "Stand" );
				break;
			case e_Stat.BACKSWING:
				m_MyAnim.CrossFade( "BackSwing" );
				break;
			case e_Stat.SWING:
				m_MyAnim.CrossFade( "Swing" );
				break;
			default:
				break;
			}
			m_bSwitchAnim = false;
		}
	}
	
	public void Swing()
	{
		switch( m_eStat ) {
		case e_Stat.STAND:
		case e_Stat.BACKSWING:
			m_eStat = e_Stat.SWING;
			m_bSwitchAnim = true;
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
			m_bSwitchAnim = true;
			break;
		default:
			break;
		}
	}
}
