using UnityEngine;
using System.Collections;

public class BattSwingPlane : MoveObj {
	public GameObject			m_BattHitPoint;
	
	// Update is called once per frame
	protected override void Update()
	{
		if( m_bPos ) {
			// rescale.
			Vector3 vDiffTgt = m_vPos - transform.position;
			Vector3 vTmpScl = transform.localScale;
			vTmpScl.z = vDiffTgt.magnitude * 2;
			//transform.localScale = vTmpScl;
			
			// reangle.
			transform.LookAt( m_vPos );

			m_bPos = false;
		}
	}

	public override void Rotate( Quaternion _qRot )
	{
		// not rotate.
	}
}
