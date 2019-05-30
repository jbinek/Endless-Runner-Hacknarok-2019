using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{


    public Text scoreText;
    public State stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMenu()
    {
        scoreText.text = stateInfo.score.ToString();
        gameObject.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("TESTOWA-TRUE");
    }
}
