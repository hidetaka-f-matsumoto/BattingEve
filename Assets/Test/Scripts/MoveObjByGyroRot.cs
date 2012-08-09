using UnityEngine;
using System.Collections;

public class MoveObjByGyroRot : MoveObjByGyro {

	// Use this for initialization
	protected virtual void Start()
	{
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		gameObject.rigidbody.transform.position += 0.02f * ConvCoord_iPhone2Unity_Rot( m_GyParams.m_vRotRate );
	}
}
