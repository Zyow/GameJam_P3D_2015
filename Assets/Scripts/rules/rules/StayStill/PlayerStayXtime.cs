﻿using UnityEngine;
using System.Collections;

public class PlayerStayXtime : PlayerBase 
{
	private int time;
	public int timeMax;
	private Rigidbody2D myRigibody;
	private bool isUsed;

	private bool canUse = false;

	 void Start()
	{
		if ( FindObjectOfType<RuleStayXTime>())
		{
			InvokeRepeating("TimerUp",1f,1f);
			isUsed = true;
		}
		myRigibody = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		if (canUse)
		{
			if (isUsed)
			{
				if (myRigibody.velocity.x >= 0.1 || myRigibody.velocity.x <= -0.1)
					CancelInvoke();
				else if (myRigibody.velocity.y > 0.1)
					CancelInvoke();
				else
				{	if (!IsInvoking("TimerUp"))
					{
						InvokeRepeating("TimerUp",1f,1f);				
					}
				}
			}
		}
	}
	private void TimerUp()
	{
		if (canUse)
		{
			if (isUsed)
			{
				time += 1;
				if (time >= timeMax)
				{
					FindObjectOfType<RuleStayXTime>().Done(playerNbr);
					PlayerStayXtime[] players = FindObjectsOfType<PlayerStayXtime>();
					foreach ( PlayerStayXtime player in players)
					{
						player.GetComponent<PlayerStayXtime>().Desactive();
					}
				}
			}
			else 
				CancelInvoke();
		}
	}

	public void Desactive()
	{
		isUsed = false;
	}

	public void AllowUseStay()
	{
		canUse = true;
	}
}
