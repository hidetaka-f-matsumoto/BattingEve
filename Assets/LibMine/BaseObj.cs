using UnityEngine;
using System.Collections;

public class BaseObj : MonoBehaviour
{
	public bool			m_bDebug;

	// Debug Trace
	public void DebugTrace()
	{
		if( m_bDebug ) Debug.Log(this.GetType().FullName + "::" +System.Reflection.MethodInfo.GetCurrentMethod().Name);
	}
}
