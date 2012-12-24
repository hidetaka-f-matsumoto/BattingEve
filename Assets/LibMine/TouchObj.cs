using UnityEngine;
using System.Collections;

public class TouchObj : BaseObj
{
	public GameObject		m_TchWatcher;
	protected TouchWatcher	m_TchScript;
	protected bool[]		m_bSW = new bool[(int)TouchParam.e_Type.MAX];

	protected virtual void Start()
	{
		Init();
	}

	protected virtual void Awake()
	{
		m_TchScript = m_TchWatcher.GetComponent<TouchWatcher>();
	}

	protected virtual void Init( bool _bMode = true )
	{
		for(int i=0; i<(int)TouchParam.e_Type.MAX; i++) { m_bSW[i] = false; }
	}

	protected virtual void Update()
	{
		if( m_bSW[(int)TouchParam.e_Type.TAP] ) OnTap();
	}
	
	protected virtual void OnTap()
	{
	}
	
	protected virtual void OnDoubleTap()
	{
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

	public void SetTouchMode( TouchParam.e_Type _eType, bool _bOn )
	{
		DebugTrace();
		m_bSW[(int)_eType] = _bOn;
	}
}
