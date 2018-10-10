using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreWrite : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Score")
        {
            GetComponent<Text>().text = "Score:" + PlayerPrefs.GetInt("Score").ToString();
        }
        else
            GetComponent<Text>().text = Birds_player.Score.ToString();

    }
}
