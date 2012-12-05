using UnityEngine;
using System.Collections;

public class MoveObj : MonoBehaviour
{
	protected Vector3			m_vBasePos, m_vBasePosL;
	protected Quaternion		m_qBaseRot, m_qBaseRotL;

	// Use this for initialization
	protected virtual void Start()
	{
		Store();
	}

	// Store 
	protected virtual void Store()
	{
		Store_Pos();
		Store_Rot();
	}

	// Store Position
	protected virtual void Store_Pos()
	{
		m_vBasePos = transform.position;
		m_vBasePosL = transform.localPosition;
	}

	// Store Rotation
	protected virtual void Store_Rot()
	{
		m_qBaseRot = transform.rotation;
		m_qBaseRotL = transform.localRotation;
	}

	// Restore
	protected virtual void Restore()
	{
		Restore_Pos();
		Restore_Rot();
	}

	// Restore Position
	protected virtual void Restore_Pos()
	{
		transform.position = m_vBasePos;
		transform.localPosition = m_vBasePosL;
	}

	// Restore Rotation
	protected virtual void Restore_Rot()
	{
		transform.rotation = m_qBaseRot;
		transform.localRotation = m_qBaseRotL;
	}

	// Return
	protected virtual void Return()
	{
		Restore();
	}

	// Set Position Directly.
	public virtual void SetPos( Vector3 _vPos )
	{
		transform.position = _vPos;
	}

	// Set Rotation Directly.
	public virtual void SetRot( Quaternion _qRot )
	{
		transform.rotation = _qRot;
	}
}
