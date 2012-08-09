using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public GameObject		m_Camera;
	public GameObject		m_Cursor;
	public GameObject		m_Ball;
	public GameObject		m_Batt;
	public GameObject		m_Batter;
	public GameObject		m_BattHit;
	float					m_fBallTimer;
	int						m_iThrowType;

	// Use this for initialization
	void Start()
	{
		Physics.gravity = new Vector3(0.0f,-4.9f,0.0f);
		m_fBallTimer = 0.0f;
		m_iThrowType = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
	}

	void OnGUI () {
		int sWidth = Screen.width;
		GUI.Label(new Rect(sWidth - 100,0,50,50),"Time:" + m_fBallTimer);
		if( GUI.Button(new Rect(sWidth - 200,0,100,100),"Init") ){
			Application.LoadLevel(Application.loadedLevel);	
		}
		if( GUI.Button(new Rect(sWidth - 200,100,100,100),"Swing") ){
			m_Batt.SendMessage( "Swing" );
			m_Batter.SendMessage( "Swing" );
			m_BattHit.SendMessage( "Swing" );
		}
		if( GUI.Button(new Rect(sWidth - 200,300,100,100),"P Slo") ){
			m_iThrowType = 0;
			/*
			m_Ball.SendMessage( "Throw", Ball.e_Stuff.SLOW );
			m_Batter.SendMessage( "BackSwing" );
			*/
		}
		if( GUI.Button(new Rect(sWidth - 200,200,100,100),"P Str") ){
			m_iThrowType = 1;
			/*
			m_Ball.SendMessage( "Throw", Ball.e_Stuff.STRAIGHT );
			m_Batter.SendMessage( "BackSwing" );
			*/
		}
		if( GUI.Button(new Rect(sWidth - 200,400,100,100),"Ret") ){
			m_Ball.SendMessage( "Return" );
		}

		if( GUI.Button(new Rect(sWidth - 100,0,100,100),"RotX+") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(1.0f,0.0f,0.0f);
			m_Cursor.SendMessage( "Gyro", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,100,100,100),"RotX-") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(-1.0f,0.0f,0.0f);
			m_Cursor.SendMessage( "Gyro", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,200,100,100),"RotY+") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,1.0f,0.0f);
			m_Cursor.SendMessage( "Gyro", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,300,100,100),"RotY-") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,-1.0f,0.0f);
			m_Cursor.SendMessage( "Gyro", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,400,100,100),"RotZ+") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,0.0f,1.0f);
			m_Cursor.SendMessage( "Gyro", gyParam );
		}
		if( GUI.Button(new Rect(sWidth - 100,500,100,100),"RotZ-") ){
			ParamGyro gyParam = new ParamGyro();
			gyParam.m_vRotRate = new Vector3(0.0f,0.0f,-1.0f);
			m_Cursor.SendMessage( "Gyro", gyParam );
		}
	}

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
		m_Batt.SendMessage( "Swing" );
		m_Batter.SendMessage( "Swing" );
		m_BattHit.SendMessage( "Swing" );
    }

    #endregion
}
