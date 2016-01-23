using UnityEngine;
using System.Collections;

public class PlayerStats : Stats {

    private int mp;
    private int kills;
    private StatsUI ui;

    public int Health
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            ui.Health = value;
            if (hp <= 0)
                gameObject.SendMessage("OnDeath");
        }
    }

    public int Mana
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
            ui.Mana = value;
        }
    }

    public int Kills
    {
        get
        {
            return kills;
        }
        set
        {
            kills = value;
            ui.Kills = value;
        }
    }


    // Use this for initialization
    void Start () {
        ui = GameObject.Find("UIStats").GetComponent<StatsUI>();
        Health = Mana = Kills = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
