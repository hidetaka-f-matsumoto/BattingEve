using UnityEngine;
using System.Collections;

public class MoveObj : MonoBehaviour {
	protected Vector3			m_vPos, m_vFirstPos, m_vFirstPosL;
	protected Quaternion		m_qRot, m_qFirstRot, m_qFirstRotL;
	protected bool				m_bPos, m_bRot;

	// Use this for initialization
	protected virtual void Start()
	{
		m_vFirstPos = transform.position;
		m_qFirstRot = transform.rotation;
		m_vFirstPosL = transform.localPosition;
		m_qFirstRotL = transform.localRotation;
		Init();
	}
	
	// Init Params
	protected virtual void Init()
	{
		m_vPos = m_vFirstPos;
		m_qRot = m_qFirstRot;
		m_bPos = m_bRot = false;
	}

	// Return to Fist
	protected virtual void Return()
	{
		Init();
		transform.position = m_vFirstPos;
		transform.rotation = m_qFirstRot;
		transform.localPosition = m_vFirstPosL;
		transform.localRotation = m_qFirstRotL;
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		if( m_bPos ) {
			transform.position = m_vPos;
			m_bPos = false;
		}
		if( m_bRot ) {
			transform.rotation = m_qRot;
			m_bRot = false;
		}
	}

	public virtual void Move( Vector3 _vPos )
	{
		m_vPos = _vPos;
		m_bPos = true;
	}

	public virtual void Rotate( Quaternion _qRot )
	{
		m_qRot = _qRot;
		m_bRot = true;
	}
}
