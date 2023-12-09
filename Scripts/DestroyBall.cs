using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class DestroyBall : MonoBehaviour
{
    
     public GameObject newBall;
    public GameObject golight;
    private Launcher launcherScript;
    private SpriteRenderer golightRenderer;
    //private AnimateController golightAniController;
    //private SoundController sound;
    // Start is called before the first frame update
    void Start()
    {
        //sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        golightRenderer = golight.GetComponent<Renderer>() as SpriteRenderer;
        //golightAniController = golight.GetComponent<AnimateController>();
        // check launcher object exists
        GameObject launcherObj = GameObject.Find("PlungerSpringJoint");
        if (launcherObj != null)
        {
            launcherScript = launcherObj.GetComponent<Launcher>();
        }
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "Ball2D")
        {
            // on light
           // golightRenderer.sprite = golightAniController.spriteSet[0];
            //sound.die.Play();
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.name == "Ball2D" && launcherScript != null)
        {
            // off light & Destroy ball
            //golightRenderer.sprite = golightAniController.spriteSet[1];
            Destroy(obj.gameObject);
            // new 
            GameObject newObj = Instantiate(newBall) as GameObject;
            newObj.name = "Ball2D";
            newObj.transform.position = new Vector3(2.85f, -1f, 0f);
            // reset launcher
            //launcherScript.isActive = true;
        }
    }
}
