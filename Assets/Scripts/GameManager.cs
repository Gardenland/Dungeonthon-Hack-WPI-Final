using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused, // TODO after hackathon
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

    public void OnPlayButtonClick()
    {
        state = GameState.Playing;
        SceneManager.LoadScene("test_Dungeon");
    }

    public void OnPlayerDeath()
    {
        state = GameState.GameOver;
        SendAllGameObjectsMessage("GameOver");
        Destroy(GameObject.Find("UIStats"));
        GameObject ui = Instantiate(Resources.Load("UI/UIGameOver"), transform.position, transform.rotation) as GameObject;
        ui.GetComponentInChildren<Button>().onClick.AddListener(GoToMainMenu);
        
        foreach(Text label in ui.GetComponentsInChildren<Text>())
        {
            if (label.name.Equals("Slain"))
            {
                label.text = "Enemies Slain " + GameObject.Find("Hero").GetComponent<PlayerStats>().Kills;
                break;
            }
        }
    }

    public void GoToMainMenu()
    {
        state = GameState.MainMenu;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnPlayerWon()
    {
        SendAllGameObjectsMessage("GameOver");
        Destroy(GameObject.Find("UIStats"));
    }

    public void SendAllGameObjectsMessage(string function)
    {
        GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objs)
            obj.BroadcastMessage(function);
    }
}
