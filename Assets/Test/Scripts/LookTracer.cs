using UnityEngine;
using System.Collections;

public class LookTracer : MoveObj
{
	public GameObject		m_Ball;
	bool					m_bTrace;

	// Init Params	
	void Init()
	{
		m_bTrace = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if( m_bTrace ) {
			transform.LookAt( m_Ball.transform.position );
		}
	}
	
	public void Trace()
	{
		m_bTrace = true;
	}
}
