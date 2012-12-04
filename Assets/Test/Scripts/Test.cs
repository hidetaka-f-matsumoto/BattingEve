using UnityEngine;
using System.Collections;

public enum e_DebugDisp
{
	START = 0,
	MAIN,
	PHYS,
	BALL,
};

public class Test : MonoBehaviour
{
	public enum e_GameMode
	{
		NONE = 0,
		BEGIN,
		GYRO = BEGIN,
		TAPPOS,
		
		END
	};
	public struct t_GameMode
	{
		public bool			m_bChg;
		public e_GameMode	m_eMode;
		public void Init()
		{
			m_bChg = false;
			m_eMode = e_GameMode.NONE;
		}
		public void Start()
		{
			m_bChg = true;
			m_eMode = e_GameMode.BEGIN;
		}
		public void Next()
		{
			m_bChg = true;
			m_eMode++;
			if( m_eMode == e_GameMode.END ) m_eMode = e_GameMode.BEGIN;
		}
	};
	public GameObject		m_ComInfo;
	CommonInfo				m_ComInfoScript;
	public GameObject		m_Gyro;
	public GameObject		m_Camera;
	public GameObject		m_Cursor;
	public GameObject		m_Ball;
	public GameObject		m_Batter;
	public GameObject		m_BattHit;
	float					m_fBallTimer;
	t_GameMode				m_tGameMode;

	// Use this for initialization
	void Start()
	{
		m_ComInfoScript = m_ComInfo.GetComponent<CommonInfo>();
		Physics.gravity = new Vector3(0.0f,-4.9f,0.0f);
		m_fBallTimer = 0.0f;
		m_tGameMode.Start();
	}
	
	// Update is called once per frame
	void Update()
	{
		UpdateGameMode();
	}
	
	void UpdateGameMode()
	{
		if( !m_tGameMode.m_bChg ) return;
		switch( m_tGameMode.m_eMode ) {
		case e_GameMode.GYRO:
			m_Cursor.SendMessage( "SetGyroMode", GyroObj.e_Mode.ROTATION );
			m_Cursor.SendMessage( "SetTouchMode", TouchObj.e_Mode.NONE );
			break;
		case e_GameMode.TAPPOS:
			m_Cursor.SendMessage( "SetGyroMode", GyroObj.e_Mode.NONE );
			m_Cursor.SendMessage( "SetTouchMode", TouchObj.e_Mode.TAP );
			break;
		default:
			m_tGameMode.m_eMode = e_GameMode.GYRO;
			m_Cursor.SendMessage( "SetGyroMode", GyroObj.e_Mode.NONE );
			m_Cursor.SendMessage( "SetTouchMode", TouchObj.e_Mode.NONE );
			break;
		}
		m_tGameMode.m_bChg = false;
	}

	void OnGUI () {
		int sWidth = Screen.width;
		GUI.Label(new Rect(sWidth - 100,0,50,50),"Time:" + m_fBallTimer);
		if( GUI.Button(new Rect(sWidth - 200,0,100,100),"Init") ){
			Application.LoadLevel(Application.loadedLevel);	
		}
		if( GUI.Button(new Rect(sWidth - 200,100,100,100),"SWMode") ){
			m_tGameMode.Next();
		}
		if( GUI.Button(new Rect(sWidth - 200,200,100,100),"SChg") ){
			m_Ball.SendMessage( "NextStuff" );
		}
		if( GUI.Button(new Rect(sWidth - 200,400,100,100),"Ret") ){
			m_Ball.SendMessage( "Return" );
		}

		if( GUI.Button(new Rect(sWidth - 100,0,100,100),"RotX+") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(1.0f,0.0f,0.0f);
			m_Gyro.SendMessage( "GyroTest", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,100,100,100),"RotX-") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(-1.0f,0.0f,0.0f);
			m_Gyro.SendMessage( "GyroTest", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,200,100,100),"RotY+") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,1.0f,0.0f);
			m_Gyro.SendMessage( "GyroTest", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,300,100,100),"RotY-") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,-1.0f,0.0f);
			m_Gyro.SendMessage( "GyroTest", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,400,100,100),"RotZ+") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,0.0f,1.0f);
			m_Gyro.SendMessage( "GyroTest", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,500,100,100),"RotZ-") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,0.0f,-1.0f);
			m_Gyro.SendMessage( "GyroTest", gyParam );
		}
	}
	/*
    #region Gesture event registration/unregistration

    void OnEnable()
    {
        Debug.Log( "Registering finger gesture events from C# script" );

        // register input events
        FingerGestures.OnFingerTap += FingerGestures_OnFingerTap;
    }

    void OnDisable()
    {
        // unregister finger gesture events
        FingerGestures.OnFingerTap -= FingerGestures_OnFingerTap;
    }

    #endregion

    #region Reaction to gesture events

    void FingerGestures_OnFingerTap( int fingerIndex, Vector2 fingerPos )
    {
		m_Batter.SendMessage( "Swing" );
		m_BattHit.SendMessage( "Swing" );
    }

    #endregion
    */
}
