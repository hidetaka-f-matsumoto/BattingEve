using UnityEngine;
using System.Collections;

public class TouchWatcher : BaseObj
{
	public TouchParam	m_TchParam;

	void Start()
	{
		m_TchParam.Init();
	}

	void LastUpdate()
	{
		m_TchParam.Init();
	}
	
	void OnEnable()
    {
        FingerGestures.OnFingerTap += FingerGestures_OnFingerTap;
    }

    void OnDisable()
    {
        FingerGestures.OnFingerTap -= FingerGestures_OnFingerTap;
    }

    void FingerGestures_OnFingerTap( int fingerIndex, Vector2 fingerPos )
    {
		m_TchParam.Set( TouchParam.e_Type.TAP, fingerPos, Vector2.zero );
    }	
}
