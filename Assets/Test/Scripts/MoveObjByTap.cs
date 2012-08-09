using UnityEngine;
using System.Collections;

public class MoveObjByTap : MoveObj {

	// Use this for initialization
	protected virtual void Start()
	{
		Init();
		base.Start();
	}
	
	// Init Params
	protected virtual void Init()
	{
		base.Init();
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		base.Update();
	}
	
	public virtual void Tap()
	{
	}
}
