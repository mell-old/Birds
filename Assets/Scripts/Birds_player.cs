using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class Birds_player : MonoBehaviour {

    private Rigidbody2D myRigidbody2D { get; set; }
    private bool fly;
    [SerializeField]
    public float flyForce;
    private static int score;
    public static int Score { get; set; }
    public GameObject player;
    private bool isDead = false;
    private static int CountAds = 0;
    private bool AdsPlay;
    private Transform transforms;
    public bool IsDead
    {
        get { return isDead; }
    }
    [SerializeField]
    private Animator animator;
	// Use this for initialization

    public static void CountScore()
    {
        score++;
        Score = score;
    }
	void Start () {
        AdsPlay = false;
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("2753084", false);
        }
        else
            Debug.Log("Platform is not supported");
        Score = 0;
        score = 0;
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (!EventSystem.current.IsPointerOverGameObject() && !isDead)
        {
            if (Input.GetMouseButtonDown(0))
                fly = true;
        }
        if (transform.position.y > 4.2f && !isDead)
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        if (transform.position.y < -3.8f)
            StartCoroutine(Dead());
    }
    private void FixedUpdate()
    {
        if(fly)
        {
			if (PlayerPrefs.GetString("Music") == "Yes")
			GetComponent<AudioSource>().Play();
            myRigidbody2D.velocity = Vector2.zero;
            myRigidbody2D.AddForce(new Vector2(0, flyForce), ForceMode2D.Impulse);
            fly = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            if (PlayerPrefs.GetString("Music") == "Yes")
                GameObject.Find("HitSound").GetComponent<AudioSource>().Play();
            StartCoroutine(Dead());
        }
    }
    [SerializeField]
    private GameObject rest;

    private IEnumerator Dead()
    {
        
        isDead = true;
        myRigidbody2D.velocity = Vector2.zero;
      /*  myRigidbody2D.gravityScale = 0;
        animator.speed = 0;
        yield return new WaitForSeconds(1);
        animator.speed = 1;
        myRigidbody2D.gravityScale = 1;*/
        animator.SetBool("Dead", isDead);
        myRigidbody2D.AddForce(new Vector2(0, flyForce), ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
        // SceneManager.LoadScene(0);
        myRigidbody2D.gravityScale = 0;
        animator.speed = 0;
        if(PlayerPrefs.GetInt("Score") < score)
        {
            PlayerPrefs.SetInt("Score", score);
        }
        if (PlayerPrefs.GetString("Music") == "Yes")
            GameObject.Find("SoundLose").GetComponent<AudioSource>().Play();
        rest.SetActive(true);
        CountAds++;
        if (!AdsPlay)
        {
            AdsPlay = true;
            if (Advertisement.IsReady() && CountAds >= 15)
            {
                CountAds = 0;
                Advertisement.Show();
            }
        }
    }
}
