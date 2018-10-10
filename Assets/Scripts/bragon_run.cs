using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bragon_run : MonoBehaviour {

    [SerializeField]
    private float speedRun;
    [SerializeField]
    private float speed;
    private Vector3 target;
    private float y_down;
    private float y_up;

    void Start()
    {
      if (PlayerPrefs.GetString("Music") == "Yes")
			GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        y_down = Random.Range(-2.5f,2);
        y_up = Random.Range(2, 3.8f);
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            if (transform.position == target && target.y != y_down)
            {
                target.y = y_down;
                target.x -= speedRun;
            }
            else if (transform.position == target && target.y != y_up)
            {
                target.y = y_up;
                target.x -= speedRun;
            }
        }
        if (gameObject.transform.position.x < -10)
            Destroy(gameObject);
        if (gameObject.transform.position.x < -7 && gameObject.transform.position.x > -7.15f)
            Birds_player.CountScore();

    }
    

}
