using UnityEngine;
using System.Collections;

public enum e_GameSeq
{
	NONE = 0,
	BEGIN,
	PLAYBALL = BEGIN,
	PITCHER_SET,
	PITCHER_THROW,
	CATCHER_CATCH,
	BATTER_HIT,
	BATTER_HIT_FAIR,
	BATTER_HIT_FOUL,
	FIELDER_CATCH,

	END
};

public class CommonInfo : BaseObj
{
	public e_GameSeq		m_eGameSeq;

	// Use this for initialization
	void Start()
	{
		Init();
	}

	// Init params
	void Init()
	{
		m_eGameSeq = e_GameSeq.NONE;
	}	
}
