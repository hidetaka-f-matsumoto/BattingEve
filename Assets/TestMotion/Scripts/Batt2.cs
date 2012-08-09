using UnityEngine;
using System.Collections;

public class Batt2: MonoBehaviour {
	int						m_iSwing;

	// Use this for initialization
	void Start()
	{
		Init();
	}
	
	void Init()
	{
		m_iSwing = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		/*
		switch( m_iSwing ) {
		case 1:
			OnSwing1();
			break;
		case 2:
			OnSwing2();
			break;
		case 3:
			Init();
			break;
		}
		*/
	}

	void OnSwing1()
	{
		iTween.RotateTo( gameObject, iTween.Hash( 	"rotation",new Vector3(-70.0f,0.0f,0.0f),
													"time",0.3f,
													"delay",1.0f,
													"easetype",iTween.EaseType.easeInQuad,
													"oncomplete","OnSwing2" ) );
	}

	void OnSwing2()
	{
		iTween.RotateTo( gameObject, iTween.Hash( 	"rotation",new Vector3(-90.0f,0.0f,-60.0f),
													"time",0.1f,
													"delay",0.0f,
													"easetype",iTween.EaseType.linear,
													"oncomplete","OnSwing3" ) );
	}

	void OnSwing3()
	{
		iTween.RotateTo( gameObject, iTween.Hash( 	"rotation",new Vector3(-90.0f,0.0f,-120.0f),
													"time",0.1f,
													"delay",0.0f,
													"easetype",iTween.EaseType.linear,
													"oncomplete","OnSwing4" ) );
	}

	void OnSwing4()
	{
		iTween.RotateTo( gameObject, iTween.Hash( 	"rotation",new Vector3(-120.0f,0.0f,-180.0f),
													"time",0.2f,
													"delay",0.0f,
													"easetype",iTween.EaseType.easeOutQuad,
													"oncomplete","Init" ) );
	}

	void OnSwinged()
	{
		m_iSwing++;
	}
	
	public void Swing()
	{
		if( m_iSwing == 0 ) {
			OnSwing1();
		}
	}
}
