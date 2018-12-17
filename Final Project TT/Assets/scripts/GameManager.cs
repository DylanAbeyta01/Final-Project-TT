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
    public Text player2Score { get; set; }

    public int score1 = 0;
    public int score2 = 0;  

    // Because we only ever want one, we must make a PRIVATE constructor, not a public constructor
    private GameManager()
    {
      
        //Create a new object with a script of type Updater to update the GameManager
        Object.DontDestroyOnLoad(new GameObject("Updater", typeof(Updater)));     
    }

    private void Update()
    {
        //Game logic would go here like managing time, level resets, etc.
        player1Score = GameObject.Find("player1Score").GetComponent<Text>();    
        player2Score = GameObject.Find("player2Score").GetComponent<Text>();

        player1Score.text = ("Green Tank: " + score1);
        player2Score.text = ("Yellow Tank: " + score2);
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
