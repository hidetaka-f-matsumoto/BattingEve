using UnityEngine;
using System.Collections;

public class FPSWatcher : MonoBehaviour {
	public bool gui = true;
	public bool log = false;
	float fps = 0.0f;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.frameCount % Application.targetFrameRate == 0 ) {
			fps = 1 / Time.deltaTime;
			if( log ) {
				print ( "FPS=" + fps );
			}
		}
	}
	
	void OnGUI () {
		if( gui ) {
			GUILayout.Label( "FPS =" + fps );
		}
	}
}
