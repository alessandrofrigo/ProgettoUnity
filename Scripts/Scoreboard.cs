using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    // Start is called before the first frame update 
    static private int score;
    static private int level=0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livello; 
    static private int tot = 0;
    static public int counter = 0;
    void Start()
    {
       //StartCoroutine(SpawnTarget());
        scoreText = GameObject.Find("Scoreboard").GetComponent<TextMeshProUGUI>();  
        livello = GameObject.Find("Livello").GetComponent<TextMeshProUGUI>();  
        score = 0;
        level=0;
        scoreText.text = " Score: " + score;
        livello.text= "Livello: " + level;
    }
    /*IEnumerator SpawnTarget() 
    {
        while (true) { UpdateScore(5); }
    }*/

    public void UpdateScore(string tag)
    {
        //Debug.Log("Mi ha chiamato l'ostacolo " + tag);
        if(tag=="Ostacolo1"){
            score += 5;
            scoreText.text = " Score: " + score;
            //Debug.Log("Score: " +score);
            level += 1;
            livello.text = "Livello: " + level;
            tot = score;
        } else if(tag == "Ostacolo2"){
            score += 5;
            scoreText.text = " Score: " + score;
            //Debug.Log("Score: " +score);
            level += 1;
            livello.text = "Livello: " + level;
            tot = score;
        }    
        else if (tag=="Ostacolo3"){
            score += 10;
            scoreText.text = " Score: " + score;
            //Debug.Log("Score: " +score);
            level = level + 1;
            livello.text = "Livello: " + level;
            tot = score;
        } else if (tag == "Ostacolo4") {
            score += 5;
            scoreText.text = " Score: " + score;
            //Debug.Log("Score: " +score);
            level += 1;
            livello.text = "Livello: " + level; 
            tot = score;
        }
        else if (tag=="Fondo"){
            score = 0;
            scoreText.text = " Score: " + score;
            //Debug.Log("Score: " +score);
            level =0;
            livello.text = "Livello: " + level;
            counter++; 
            if(counter == 3){
                livello.text ="  game over";
            }
        }
        else if (tag == "PlungerAnchor") 
        {
            level =0;
            livello.text = "Livello: " + level;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(counter == 3){
                scoreText.text = "Il totale è: " + tot;
                //return;
            }
    }
}
