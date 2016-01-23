using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsUI : MonoBehaviour {

    public Text health { get; set; }
    public Text mana { get; set; }
    public Text kills { get; set; }

    // Use this for initialization
    void Start () {
        health = GameObject.Find("UIHealth").GetComponent<Text>();
        mana = GameObject.Find("UIMana").GetComponent<Text>();
        kills = GameObject.Find("UIKills").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update() {

    }
    
}
