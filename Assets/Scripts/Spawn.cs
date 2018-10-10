using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField]
    private Birds_player player;
    [SerializeField]
    private GameObject[] enemy;
    private int numberEnemy;
    private float y_pos;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawns());
	}
	
	// Update is called once per frame
	private IEnumerator Spawns()
    {
        while(!player.IsDead)
        {
           numberEnemy = Random.Range(0, 6);
            switch(numberEnemy)
            {
                case 0:
                    y_pos = Random.Range(2f, 4);
                    break;
                case 2:
                    y_pos = -4.8f;
                    break;
                case 3:
                    y_pos = Random.Range(3, 4);
                    break;
                case 6:
                    y_pos = -4.8f;
                    break;
                case 4:
                    y_pos = 4.8f;
                    break;
                case 1:
                    y_pos = 5.9f;
                    break;
                case 5:
                    y_pos = Random.Range(4,4.5f);
                    break;
            }
            Instantiate(enemy[numberEnemy], new Vector3(13, y_pos, 0) , Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

}
