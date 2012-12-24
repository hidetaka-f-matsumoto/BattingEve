using UnityEngine;
using System.Collections;

public class TouchParam
{
	public enum e_Type
	{
		NONE = -1,
		TAP = 0,
		DTAP,
		SWAP,
		DRAG,
		
		MAX
	};
	public struct t_ParamOne
	{
		public Vector2			m_vParam1;
		public Vector2			m_vParam2;
		public void Init()
		{
			m_vParam1.Set(0.0f,0.0f);
			m_vParam2.Set(0.0f,0.0f);
		}
		public string ToString()
		{
			return (m_vParam1 + ", " + m_vParam2);
		}
	}

	// params
	t_ParamOne[] m_Param = new t_ParamOne[(int)e_Type.MAX];

	// funcs
	public void Init()
	{
		for(int i=0; i<(int)e_Type.MAX; i++)
		{
			m_Param[i].Init();
		}
	}

	public string ToString()
	{
		string str = "";
		for(int i=0; i<(int)e_Type.MAX; i++)
		{
			str += "TouchParam: " + i + ": " + m_Param[i].ToString() + "¥n";
		}
		return str;
	}
	
	public void Set( e_Type _type, Vector2 _param1, Vector2 _param2 )
	{
		m_Param[(int)_type].m_vParam1 = _param1;
		m_Param[(int)_type].m_vParam2 = _param2;
	}
	
	public void Get( e_Type _type, ref Vector2 _param1, ref Vector2 _param2 )
	{
		_param1 = m_Param[(int)_type].m_vParam1;
		_param2 = m_Param[(int)_type].m_vParam2;
	}
}
