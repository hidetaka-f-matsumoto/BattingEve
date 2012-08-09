using UnityEngine;
using System.Collections;

public class AttractObj : MonoBehaviour {
	public GameObject		m_AttractObj;
	Vector3					m_vAttractF;

	// Use this for initialization
	void Start()
	{
		m_vAttractF = new Vector3(0.0f,0.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 vAttract = m_AttractObj.transform.position - gameObject.transform.position;
		Vector3 vAttractXZ = vAttract;	vAttractXZ.y = 0.0f;
		m_vAttractF = 0.5f / vAttractXZ.magnitude * vAttractXZ.normalized;
		gameObject.rigidbody.AddForce( m_vAttractF, ForceMode.Force );
	}
	
	public void SetAttraction( GameObject _obj )
	{
		m_AttractObj = _obj;
	}
}
