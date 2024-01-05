using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject bomb;

    public Button startBtn;
   



    // Start is called before the first frame update
    void Start()
    {
        startBtn.gameObject.SetActive(true);
        bomb.GetComponent<Bomb>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        bomb.GetComponent<Bomb>().StartCoroutine(bomb.GetComponent<Bomb>().BombExplode());
        player1.GetComponent<PlayerController>().canplay = true;
        player2.GetComponent<PlayerController>().canplay = true;


        startBtn.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        player1.GetComponent<PlayerController>().canplay = false;

        player2.GetComponent<PlayerController>().canplay = false;
        //player2.GetComponent<PlayerController>().anim.SetBool("dead", true);

    }
}
