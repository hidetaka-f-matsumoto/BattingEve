using UnityEngine;
using System.Collections;

public class TouchObj : MonoBehaviour {
	public enum e_Mode
	{
		NONE 			= 0x00000000,
		TAP				= 0x00000001,
		DTAP			= 0x00000002,
		SWAP			= 0x00000004,
		DRAG			= 0x00000008,
	};

	protected e_Mode		m_eMode;

    void OnEnable()
    {
        // register input events
        FingerGestures.OnFingerTap += FingerGestures_OnFingerTap;
    }

    void OnDisable()
    {
        // unregister finger gesture events
        FingerGestures.OnFingerTap -= FingerGestures_OnFingerTap;
    }

    void FingerGestures_OnFingerTap( int fingerIndex, Vector2 fingerPos )
    {
    }
}
