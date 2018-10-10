using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Background[] backgroundElements;

    [SerializeField]
    private Birds_player birds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!birds.IsDead)
        {
            foreach (Background element in backgroundElements)
            {
                element.Move();
            }
        }
	}
}
