﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        MainMenu,
        Loading,
        Playing,
        Paused,
        GameOver,
        GameWon
    }

    private GameState state;

    public GameState CurrentState
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
            // TODO handle state changes
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
        state = GameState.MainMenu;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}