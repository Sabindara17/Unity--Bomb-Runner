using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    bool pass = true;
    public AudioSource blastSound;
    public Button playAgain;
    public GameObject manager;
    public GameObject p1;
    public GameObject p2;


    public TMP_Text winText;



    int bombIsWith;
    // Start is called before the first frame update
    void Start()
    {

        winText.transform.parent.gameObject.SetActive(false);

        playAgain.gameObject.SetActive(false);
        // blastSound.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
      

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
            if (other.gameObject.tag == "Player" && pass)
        {
            transform.position = other.transform.GetChild(0).position;
            transform.parent = other.transform.GetChild(0);
            pass = false;
            Invoke("MakePassTrue",1);
            bombIsWith = other.transform.parent.GetComponent<PlayerController>().playerNum;
        }
        
        }

    void MakePassTrue()
    {
        pass = true;
    }
     public IEnumerator BombExplode()
    {
        yield return new WaitForSeconds(7);
        blastSound.Play();
        yield return new WaitForSeconds(7);
        manager.GetComponent<Manager>().GameOver();
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;

        if (bombIsWith == 1)
        {
            p1.GetComponent<PlayerController>().bombBlast = true;


        }
        else if (bombIsWith == 2)
        {
            p2.GetComponent<PlayerController>().bombBlast = true;

        }


        yield return new WaitForSeconds(2);
        if (bombIsWith == 1)
        {
            winText.text = $"Player {2} Win";
            
            
        }
        else if (bombIsWith == 2)
        {
            winText.text = $"Player {1} Win";

        }
        winText.transform.parent.gameObject.SetActive(true);

        playAgain.gameObject.SetActive(true);
        
    }

 

    

  

   
}
