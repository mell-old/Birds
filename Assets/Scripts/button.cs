
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {

    public GameObject pause, rest;

    private void Start()
    {
        if (gameObject.name == "click")
        {
            Time.timeScale = 0;
        }
        if (gameObject.name == "m_off" || gameObject.name == "m_on")
        {
            if (PlayerPrefs.GetString("Music") == "No")
            {
                m_on.SetActive(false);
                m_off.SetActive(true);
            }
           else
            {
                m_off.SetActive(false);
                m_on.SetActive(true);
            }
        }
    }
    public GameObject m_on, m_off;
    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") == "Yes")
            GameObject.Find("SoundClick").GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "play":
                SceneManager.LoadScene(1);
                break;
            case "restart":
                SceneManager.LoadScene(1);
                break;
            case "menu":
                SceneManager.LoadScene(0);
                break;
            case "m_on":
                PlayerPrefs.SetString("Music", "No");
                m_on.SetActive(false);
                m_off.SetActive(true);
                break;
            case "m_off":
                PlayerPrefs.SetString("Music", "Yes");
                m_off.SetActive(false);
                m_on.SetActive(true);
                break;
            case "click":
                Time.timeScale = 1;
                Destroy(gameObject);
                break;
            case "pause":
                if (rest.activeSelf == false)
                {
                    pause.SetActive(true);
                    Time.timeScale = 0;
                }
                break;
            case "playOn":
                pause.SetActive(false);
                Time.timeScale = 1;
                break;
                
        }
    }

}
