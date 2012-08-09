using UnityEngine;
using System.Collections;

public class Batter2 : MonoBehaviour {
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
		if( m_iSwing == 1 ) {
			// Move to the start point.
			iTween.MoveTo( gameObject,iTween.Hash(	"Path",iTweenPath.GetPath("Swing Path"),
													"time",2,
													"easetype",iTween.EaseType.linear,
													"oncomplete","OnSwinged" ));
			m_iSwing++;
		}
	}
	
	void OnSwinged()
	{
		Init();
	}
	
	public void Swing()
	{
		if( m_iSwing == 0 ) {
			m_iSwing++;
		}
	}
}
