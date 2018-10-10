using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemy : MonoBehaviour {

    [SerializeField]
    private float speed;
    private float speedRun;
    private Vector3 target;
    private float y_down;
    private float y_up;

    public Birds_player player;
    void Start()
    {
		if (PlayerPrefs.GetString("Music") == "Yes")
			GetComponent<AudioSource>().Play();
        //target = new Vector3(transform.position.x - speed, -1, 0);
    }
    // Update is called once per frame
    void Update()
    {

        {
 
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            target.x -= speed;

            if (gameObject.transform.position.x < -7 && gameObject.transform.position.x > -7.1f)
                Birds_player.CountScore();
            if (gameObject.transform.position.x < -10)
            {
                Destroy(gameObject);
            }

        }
    }

}
