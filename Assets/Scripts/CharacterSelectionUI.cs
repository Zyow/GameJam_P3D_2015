﻿using UnityEngine;
using System.Collections;

public class CharacterSelectionUI : MonoBehaviour 
{
	//public GameObject loadingPlayerPrefab;
	public GameObject canLaunchGameUI;
	public GameObject cantLaunchGameUI;

	public int numberActivePlayers;
	private bool canLaunchGame;
	private LoadingPlayer loadingPlayer;

	public GameObject textPlayer1Join;
	public GameObject textPlayer2Join;
	public GameObject textPlayer3Join;
	public GameObject textPlayer4Join;

	public GameObject textPlayer1Joined;
	public GameObject textPlayer2Joined;
	public GameObject textPlayer3Joined;
	public GameObject textPlayer4Joined;

	public GameObject renderP1;
	public GameObject renderP2;
	public GameObject renderP3;
	public GameObject renderP4;

	public int minPlayersNeed;

	public bool canCheat;

	void Awake()
	{
		renderP1.SetActive(false);
		renderP2.SetActive(false);
		renderP3.SetActive(false);
		renderP4.SetActive(false);
	}

	void Start ()
	{
		//Instantiate (loadingPlayerPrefab);
		//loadingPlayer = loadingPlayerPrefab.GetComponent<LoadingPlayer>();
		loadingPlayer = FindObjectOfType<LoadingPlayer>();
		cantLaunchGameUI.SetActive (true);
		canLaunchGameUI.SetActive (false);

		PlayerPrefs.SetInt ("Player 1", 0);
		PlayerPrefs.SetInt ("Player 2", 0);
		PlayerPrefs.SetInt ("Player 3", 0);
		PlayerPrefs.SetInt ("Player 4", 0);
	}

	void Update ()
	{
		if (canCheat)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
				ActivePlayer1 ();

			if (Input.GetKeyDown(KeyCode.Alpha2))
				ActivePlayer2 ();

			if (Input.GetKeyDown(KeyCode.Alpha3))
				ActivePlayer3 ();

			if (Input.GetKeyDown(KeyCode.Alpha4))
				ActivePlayer4 ();

			if (Input.GetKeyDown (KeyCode.Return) && canLaunchGame)
			{
				Application.LoadLevel("SceneDef");
				//loadingPlayer.ActivePlayer ();
			}
		}

		if (Input.GetButtonDown ("Jump Player 1"))
			ActivePlayer1 ();

		if (Input.GetButtonDown ("Jump Player 2"))
			ActivePlayer2 ();

		if (Input.GetButtonDown ("Jump Player 3"))
			ActivePlayer3 ();

		if (Input.GetButtonDown ("Jump Player 4"))
			ActivePlayer4 ();

		if (Input.GetButtonDown ("Hit Player 1"))
			DesactivePlayer1 ();
		
		if (Input.GetButtonDown ("Hit Player 2"))
			DesactivePlayer2 ();
		
		if (Input.GetButtonDown ("Hit Player 3"))
			DesactivePlayer3 ();
		
		if (Input.GetButtonDown ("Hit Player 4"))
			DesactivePlayer4 ();

		if (Input.GetButtonDown ("Pause") && canLaunchGame)
		{
			Application.LoadLevel("SceneDef");
			//loadingPlayer.ActivePlayer ();
		}
	}

	private void CheckNumberPlayers ()
	{
		if (numberActivePlayers >= minPlayersNeed)
		{
			canLaunchGame = true;
			cantLaunchGameUI.SetActive (false);
			canLaunchGameUI.SetActive (true);
		}
		else
		{
			canLaunchGame = false;
			cantLaunchGameUI.SetActive (true);
			canLaunchGameUI.SetActive (false);
		}
	}

	public void ActivePlayer1 ()
	{
		//if (!loadingPlayer.playerOneActive)
		if (PlayerPrefs.GetInt ("Player 1", 0) != 1)
		{
			textPlayer1Join.SetActive (false);
			textPlayer1Joined.SetActive (true);
			renderP1.SetActive(true);
			numberActivePlayers ++;

			//loadingPlayer.playerOneActive = true;
			PlayerPrefs.SetInt ("Player 1", 1);

			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer2 ()
	{
		//if (!loadingPlayer.playerTwoActive)
		if (PlayerPrefs.GetInt ("Player 2", 0) != 1)
		{
			textPlayer2Join.SetActive (false);
			textPlayer2Joined.SetActive (true);
			renderP2.SetActive(true);
			numberActivePlayers ++;

			//loadingPlayer.playerTwoActive = true;
			PlayerPrefs.SetInt ("Player 2", 1);

			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer3 ()
	{
		//if (!loadingPlayer.playerTreeActive)
		if (PlayerPrefs.GetInt ("Player 3", 0) != 1)
		{
			textPlayer3Join.SetActive (false);
			textPlayer3Joined.SetActive (true);
			renderP3.SetActive(true);
			numberActivePlayers ++;

			//loadingPlayer.playerTreeActive = true;
			PlayerPrefs.SetInt ("Player 3", 1);

			CheckNumberPlayers ();
		}
	}

	public void ActivePlayer4 ()
	{
		//if (!loadingPlayer.playerFourActive)
		if (PlayerPrefs.GetInt ("Player 4", 0) != 1)
		{
			textPlayer4Join.SetActive (false);
			textPlayer4Joined.SetActive (true);
			renderP4.SetActive(true);
			numberActivePlayers ++;

			//loadingPlayer.playerFourActive = true;
			PlayerPrefs.SetInt ("Player 4", 1);

			CheckNumberPlayers ();
		}
	}





	public void DesactivePlayer1 ()
	{
		//if (loadingPlayer.playerOneActive)
		if (PlayerPrefs.GetInt ("Player 1", 0) == 1)
		{
			textPlayer1Join.SetActive (true);
			textPlayer1Joined.SetActive (false);
			renderP1.SetActive(false);
			numberActivePlayers --;

			//loadingPlayer.playerOneActive = false;
			PlayerPrefs.SetInt ("Player 1", 0);

			CheckNumberPlayers ();
		}
	}
	
	public void DesactivePlayer2 ()
	{
		//if (loadingPlayer.playerTwoActive)
		if (PlayerPrefs.GetInt ("Player 2", 0) == 1)
		{
			textPlayer2Join.SetActive (true);
			textPlayer2Joined.SetActive (false);
			renderP2.SetActive(false);
			numberActivePlayers --;

			//loadingPlayer.playerTwoActive = false;
			PlayerPrefs.SetInt ("Player 2", 0);

			CheckNumberPlayers ();
		}
	}
	
	public void DesactivePlayer3 ()
	{
		//if (loadingPlayer.playerTreeActive)
		if (PlayerPrefs.GetInt ("Player 3", 0) == 1)
		{
			textPlayer3Join.SetActive (true);
			textPlayer3Joined.SetActive (false);
			renderP3.SetActive(false);
			numberActivePlayers --;

			//loadingPlayer.playerTreeActive = false;
			PlayerPrefs.SetInt ("Player 3", 0);

			CheckNumberPlayers ();
		}
	}
	
	public void DesactivePlayer4 ()
	{
		//if (loadingPlayer.playerFourActive)
		if (PlayerPrefs.GetInt ("Player 4", 0) == 1)
		{
			textPlayer4Join.SetActive (true);
			textPlayer4Joined.SetActive (false);
			renderP4.SetActive(false);
			numberActivePlayers --;

			//loadingPlayer.playerFourActive = false;
			PlayerPrefs.SetInt ("Player 4", 0);

			CheckNumberPlayers ();
		}
	}
}
