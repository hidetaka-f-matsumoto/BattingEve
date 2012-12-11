using UnityEngine;
using System.Collections;

public class TouchObj : BaseObj
{
	public enum e_Mode
	{
		NONE 			= 0x00000000,
		TAP				= 0x00000001,
		DTAP			= 0x00000002,
		SWAP			= 0x00000004,
		DRAG			= 0x00000008,
	};
	public enum e_TouchPhase
	{
		NONE = 0,
		DETECT,
		HANDLE,

		END
	};
	public struct t_Touch
	{
		public e_TouchPhase	m_ePhase;
		public Vector2		m_vParam1;
		public Vector2		m_vParam2;
		public void Init()
		{
			m_ePhase = e_TouchPhase.NONE;
			m_vParam1.Set(0.0f,0.0f);
			m_vParam2.Set(0.0f,0.0f);
		}
		public string ToString()
		{
			return ("TouchParam: " + m_ePhase + ", " + m_vParam1 + ", " + m_vParam2);
		}
	};

	protected e_Mode		m_eMode;
	protected t_Touch		m_Touch;

	protected virtual void Start()
	{
		DebugTrace();
		Init();
	}

	protected virtual void Init( bool _bMode = true )
	{
		DebugTrace();
		if( _bMode ) m_eMode = e_Mode.NONE;
		m_Touch.Init();
	}

	protected virtual void Update()
	{
		Debug.Log(m_Touch.ToString());

		if( e_Mode.NONE != (e_Mode.TAP & m_eMode) &&
			e_TouchPhase.DETECT == m_Touch.m_ePhase ) OnTap();
		
		if( e_TouchPhase.HANDLE == m_Touch.m_ePhase ) m_Touch.Init();
	}
	
	protected virtual void OnTap()
	{
		DebugTrace();
		m_Touch.m_ePhase = e_TouchPhase.HANDLE;
	}
	
	protected virtual void OnDoubleTap()
	{
		DebugTrace();
		m_Touch.m_ePhase = e_TouchPhase.HANDLE;
	}
	
	// Convert touch position to object position in the World.
	protected virtual Vector3 ConvScreenPos2ObjPos( Vector2 _vSrc )
	{
		Debug.Log(this.GetType().FullName + "::" +System.Reflection.MethodInfo.GetCurrentMethod().Name);
		Vector3 vSrc = new Vector3( _vSrc.x, _vSrc.y, 1.0f ); // z=0 is dangerous.
		Vector3 vDst = Camera.main.ScreenToWorldPoint( vSrc );
		vDst.z = gameObject.transform.position.z;
		return vDst;
	}

	void OnEnable()
    {
		DebugTrace();
        FingerGestures.OnFingerTap += FingerGestures_OnFingerTap;
    }

    void OnDisable()
    {
		DebugTrace();
        FingerGestures.OnFingerTap -= FingerGestures_OnFingerTap;
    }

    void FingerGestures_OnFingerTap( int fingerIndex, Vector2 fingerPos )
    {
		DebugTrace();
		m_Touch.m_ePhase = e_TouchPhase.DETECT;
		m_Touch.m_vParam1 = fingerPos;
    }
	
	public void SetTouchMode( e_Mode _eMode )
	{
		DebugTrace();
		m_eMode = _eMode;
	}
	
	public void AddTouchMode( e_Mode _eMode )
	{
		DebugTrace();
		m_eMode |= _eMode;
	}
	
	public void RemoveTouchMode( e_Mode _eMode )
	{
		DebugTrace();
		m_eMode &= ~_eMode;
	}
}
