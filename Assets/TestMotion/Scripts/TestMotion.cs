using UnityEngine;
using System.Collections;

public class TestMotion : MonoBehaviour {
	public GameObject			m_Batter;
	public GameObject			m_Batt;

	// Use this for initialization
	void Start()
	{
		Init();
	}
	
	void Init()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
	}
	
	void OnGUI () {
		int sWidth = Screen.width;
		if( GUI.Button(new Rect(sWidth - 100,0,100,100), "Init") ) {
			Application.LoadLevel(Application.loadedLevel);	
		}
		if( GUI.Button(new Rect(sWidth - 100,100,100,100), "Swing") ) {
			m_Batter.SendMessage( "Swing" );
			m_Batt.SendMessage( "Swing" );
		}
	}
}
