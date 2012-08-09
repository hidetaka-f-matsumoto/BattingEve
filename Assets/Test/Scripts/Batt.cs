using UnityEngine;
using System.Collections;

public class Batt : MoveObjByTap {
	public float		m_fSwingTime;
	int					m_iPhase;

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
	}
	
	// Init Params
	protected override void Init()
	{
		m_iPhase = 0;
		base.Init();
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		switch( m_iPhase ) {
		case 0:
			break;
		case 1:
			OnSwing();
			break;
		case 2:
			break;
		case 3:
			Return();
			m_iPhase = 0;
			break;
		default:
			break;
		}
	}
	
	void OnSwing()
	{
		iTween.RotateTo( gameObject, iTween.Hash( 	"rotation",new Vector3(0.0f,90.0f,0.0f),
													"islocal",true,
													"time",m_fSwingTime,
													"delay",0.0f,
													"easetype",iTween.EaseType.easeInQuad,
													"oncomplete","OnSwinged" ) );
		m_iPhase++;
	}
	
	void OnSwinged()
	{
		m_iPhase++;
	}
	
	public void Swing()
	{
		if( 0 == m_iPhase ) {
			m_iPhase++;
		}
	}
}
