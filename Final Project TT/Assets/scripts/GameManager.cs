using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager
{
    //Singleton itself
    static GameManager instance;

    //Accessor for the singleton
    public static GameManager Instance
    { get { return instance ?? (instance = new GameManager()); } }

    public player1 MyCharacter1
    { get; set; }

    public player2 MyCharacter2
    { get; set; }

    public Text player1Score { get; set; }
    public Text player2Score { get; set;  }
   
    int score1;
    int score2;

    // Because we only ever want one, we must make a PRIVATE constructor, not a public constructor
    private GameManager()
    {
        //Create a new object with a script of type Updater to update the GameManager
        Object.DontDestroyOnLoad(new GameObject("Updater", typeof(Updater)));
        player1Score = GameObject.Find("player1Score").GetComponent<Text>();
        player1Score.text = ("Player 1: " + score1);

        player2Score = GameObject.Find("player2Score").GetComponent<Text>();
        player2Score.text = ("Player 2: 1" + score2);
    }

    private void Update()
    {
        //Game logic would go here like managing time, level resets, etc.
    }

    //Internal class used to update the GameManager since GameManager doesn't inherit from MonoBehaviour
    class Updater : MonoBehaviour
    {
        private void Update()
        {
            instance.Update();
        }
    }
}
