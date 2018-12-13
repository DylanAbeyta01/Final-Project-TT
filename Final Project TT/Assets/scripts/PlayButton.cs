using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class PlayButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void OnButtonClick()
    {
        Random rand = new Random();
        int rand1to5 = rand.Next(1, 3);
        
        SceneManager.LoadScene("Map " + rand1to5);
    }
}
