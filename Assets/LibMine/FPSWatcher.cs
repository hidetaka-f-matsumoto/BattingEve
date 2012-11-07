using UnityEngine;
using System.Collections;

public class FPSWatcher : MonoBehaviour
{
	float				m_fFps;

	// Use this for initialization
	void Start ()
	{
		m_fFps = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( Time.frameCount % Application.targetFrameRate == 0 )
		{
			m_fFps = 1.0f / Time.deltaTime;
		}
	}
	
	void OnGUI ()
	{
		/*
		GUILayout.BeginVertical("box");
		GUILayout.Label( "FPS =" + m_fFps );
		GUILayout.EndVertical();
		*/
	}
}
