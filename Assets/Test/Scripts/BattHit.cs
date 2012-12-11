using UnityEngine;
using System.Collections;

public class BattHit : BaseObj
{
	public float		m_fForceMax;
	public float		m_fJustTiming;
	float				m_fHitTimer;
	bool				m_bHit;

	// Use this for initialization
	void Start()
	{
		Init();
	}
	
	void Init()
	{
		m_fHitTimer = -1.0f;
		m_bHit = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		// return timer if 2 times of JustTiming passed after swing.
		if( 2*m_fJustTiming < m_fHitTimer ) {
			Init();
			return;
		}
		// return if not swinged.
		if( !IsSwing() ) {
			return;
		}
		// renew timer.
		m_fHitTimer += Time.deltaTime;
	}
	
	void OnTriggerEnter( Collider collider ) {
		if( collider.tag != "Ball" ) {
			return;
		}
		// return if not swinged or already hitted.
		if( !IsSwing() || m_bHit ) {
			return;
		}
		// get impact timing.
		float fTimingRate = 0.0f;
		if( !GetImpactTimingRate( ref fTimingRate ) ) {
			return;
		}
		// get impact point.
		Vector3 vPoint = collider.transform.position - transform.position;
		// calc impact force direction.
		Vector3 vFDir = CalcImpactForceDir( fTimingRate, vPoint );
		// calc impact force magnitude.
		float fFAmp = CalcImpactForceAmp( fTimingRate, vPoint );
		// add force to Ball.
		collider.gameObject.SendMessage( "ImpactForce", fFAmp*vFDir );
		m_bHit = true;
		Debug.Log("hit" + fTimingRate + "," + fFAmp + "," + vFDir);
	}

	// calc impact force direction.
	Vector3 CalcImpactForceDir( float fTimingRate, Vector3 vPoint )
	{
		float fPsi = -90.0f * fTimingRate / 100.0f;
		Vector3 vDir = new Vector3(0.0f, vPoint.y, vPoint.z);
		vDir = Quaternion.AngleAxis( fPsi, Vector3.up ) * vDir;
		vDir = Quaternion.AngleAxis( -10.0f, Vector3.right ) * vDir;
		return vDir.normalized;
	}

	// calc impact force amplitude.
	float CalcImpactForceAmp( float fTimingRate, Vector3 vPoint )
	{
		float fRateX = Mathf.Abs(vPoint.x / transform.lossyScale.x);
		float fRateY = Mathf.Abs(vPoint.y / transform.lossyScale.y);
		float fFAmp = m_fForceMax / (1.0f + fRateX + fRateY/2.0f);
		if( 75.0f < fTimingRate ) {
			fFAmp *= 0.85f;
		} else if( 50.0f < fTimingRate ) {
			fFAmp *= 0.92f;
		} else if( 25.0f < fTimingRate ) {
			fFAmp *= 0.98f;
		} else if( 0.0f < fTimingRate ) {
			//  *= 1.0f;
		} else if( -10.0f < fTimingRate ) {
			fFAmp *= 0.95f;
		} else if( -30.0f < fTimingRate ) {
			fFAmp *= 0.9f;
		} else if( -45.0f < fTimingRate ) {
			fFAmp *= 0.82f;
		} else {
			fFAmp *= 0.7f;
		}
		return fFAmp;
	}

	bool IsSwing()
	{
		return 0.0f <= m_fHitTimer;
	}
	
	bool GetImpactTimingRate( ref float fTimingRate )
	{
		fTimingRate = 100.0f * (m_fHitTimer - m_fJustTiming) / Mathf.Abs(m_fJustTiming);
		if( 100.0f < Mathf.Abs(fTimingRate) ) {
			return false;
		}
		return true;
	}
			
	public void Swing()
	{
		// start timer.
		m_fHitTimer = 0.0f;
	}
}
