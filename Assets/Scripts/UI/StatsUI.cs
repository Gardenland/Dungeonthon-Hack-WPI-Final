using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsUI : MonoBehaviour {

    private Text health;
    private Text kills;

    public int Health
    {
        set
        {
            health.text = "Health: " + value;
        }
    }

    public int Kills
    {
        set
        {
            kills.text = "Kills: " + value;
        }
    }

    // Use this for initialization
    void Start () {
        health = GameObject.Find("UIHealth").GetComponent<Text>();
        kills = GameObject.Find("UIKills").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update() {

    }
    
}
