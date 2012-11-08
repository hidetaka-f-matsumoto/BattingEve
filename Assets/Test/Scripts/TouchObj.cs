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
	public struct t_Touch
	{
		public bool			m_bTouch;
		public Vector2		m_vParam1;
		public Vector2		m_vParam2;
		public void Init()
		{
			m_bTouch = false;
			m_vParam1.Set(0.0f,0.0f);
			m_vParam2.Set(0.0f,0.0f);
		}
	};

	protected e_Mode		m_eMode;
	protected t_Touch		m_Tap;

	protected virtual void Start()
	{
		Init();
	}

	protected virtual void Init()
	{
		m_eMode = e_Mode.NONE;
		m_Tap.Init();
	}

	protected virtual void Update()
	{
		if( e_Mode.NONE != (e_Mode.TAP & m_eMode) && m_Tap.m_bTouch )
		{
			gameObject.transform.position = ConvScreenPos2ObjPos( m_Tap.m_vParam1 );
			m_Tap.m_bTouch = false;
		}
	}

	// Convert touch position to object position in the World.
	protected virtual Vector3 ConvScreenPos2ObjPos( Vector2 _vSrc )
	{
		Vector3 vSrc = new Vector3( _vSrc.x, _vSrc.y, 1.0f ); // z=0 is dangerous.
		Vector3 vDst = Camera.main.ScreenToWorldPoint( vSrc );
		vDst.z = gameObject.transform.position.z;
		return vDst;
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
		m_Tap.m_bTouch = true;
		m_Tap.m_vParam1 = fingerPos;
    }
	
	public void SetTouchMode( e_Mode _eMode )
	{
		m_eMode = _eMode;
	}
	
	public void AddTouchMode( e_Mode _eMode )
	{
		m_eMode |= _eMode;
	}
	
	public void RemoveTouchMode( e_Mode _eMode )
	{
		m_eMode &= ~_eMode;
	}
}
