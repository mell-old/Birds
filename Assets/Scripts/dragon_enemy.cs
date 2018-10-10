using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_enemy : MonoBehaviour {

    [SerializeField]
    private float speed;
    private Vector3 target;
	void Start()
	{
		if (PlayerPrefs.GetString("Music") == "Yes")
			GetComponent<AudioSource>().Play();
	}
    void Update()
    {
            target = new Vector3(transform.position.x - speed, Random.Range(-4,4), 0);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            target.x += speed;

            if (gameObject.transform.position.x < -10)
                Destroy(gameObject);
        if (gameObject.transform.position.x < -7 && gameObject.transform.position.x > -7.2f)
            Birds_player.CountScore();

    }
    
}
