using System.Collections;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using UnityEngine;
using System.IO;
using UnityEditor;


public class TestMIDI : MonoBehaviour
{
    static public Playback playback;
    static public  OutputDevice output;
    static public  MidiFile file;
    string path = @"C:/Users/Alessandro/Desktop/Tirocinio/MIDI/MIDI/";
    public Scoreboard board;
    string [] filesname ;
    string[] fileContents;
   static bool isPlaying = false;
   static bool disposed = false;
   static private int count = 0;

   // Start is called before the first frame update
    void Start()
    {
        filesname = Directory.GetFiles(path, "*.MID");
        fileContents = new string[filesname.Length];
        for (int i = 0; i < filesname.Length; i++)
        {
            fileContents[i] = filesname[i];
            //Debug.Log(fileContents[i]);
        }

        foreach (var outputDevice in OutputDevice.GetAll())
        {
            Debug.Log(outputDevice.Name);
        }
        //output = OutputDevice.GetByName("MIDIOUT2 (USB2.0-MIDI)");
        output = OutputDevice.GetByName("Microsoft GS Wavetable Synth");
        Invoke("MyFunction2",1);
    }

    void MyFunction2(){

        file = MidiFile.Read(fileContents[0]);//mettere midi vuoto
        playback = file.GetPlayback(output);
                //Debug.Log("Non sto suonando!3");
           playback.Speed = 1.0;
        playback.Start();
            isPlaying = true;
            MyFunction();
    }

    void MyFunction()
    {
        Debug.Log(playback.IsRunning);
        Debug.Log("Adesso stoppo!!!");
        playback.Stop();  
        isPlaying = false;
        /* output.Dispose();
        playback.Dispose(); */
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(disposed){
            output = OutputDevice.GetByName("Microsoft GS Wavetable Synth");
            disposed = false;
        }
        if(collision.otherCollider.tag == "Ostacolo3") 
        {
            //Debug.Log("Ostacolo 3");
            int random = UnityEngine.Random.Range(0, filesname.Length-1);
            file = MidiFile.Read(fileContents[random]);
            if(!isPlaying){
                playback = file.GetPlayback(output);
                Debug.Log("Non sto suonando!3");
                playback.Speed = 1.0;
                playback.Start();
                isPlaying = true;
                Invoke("MyFunction",3);
                
            }
            board.UpdateScore("Ostacolo3");
        }
         else if (collision.otherCollider.tag == "Ostacolo1") 
        {
            //Debug.Log("Ostacolo 1");
            int random = UnityEngine.Random.Range(0, filesname.Length-1);
            file = MidiFile.Read(fileContents[random]);
            if(!isPlaying){
                //playback.Stop();
                playback = file.GetPlayback(output);
                Debug.Log("Non sto suonando!1");
                playback.Speed = 1.0;
                playback.Start();
                isPlaying = true;
                Invoke("MyFunction",3);
            }
            board.UpdateScore("Ostacolo1");
        }
        else if (collision.otherCollider.tag == "Ostacolo2")  
        {
            //Debug.Log("Ostacolo 2");
            int random = UnityEngine.Random.Range(0, filesname.Length-1);
            file = MidiFile.Read(fileContents[random]);
            if(!isPlaying){
                playback = file.GetPlayback(output);
                Debug.Log("Non sto suonando2!");
                playback.Speed = 1.0;
                playback.Start();
                isPlaying = true;
                Invoke("MyFunction",3);
            }
            board.UpdateScore("Ostacolo2");
        } 
         else if (collision.otherCollider.tag == "Ostacolo4") 
        {
            //Debug.Log("Ostacolo 4");
            int random = UnityEngine.Random.Range(0, filesname.Length-1);
            file = MidiFile.Read(fileContents[random]);
            if(!isPlaying){
                playback = file.GetPlayback(output);
                Debug.Log("Non sto suonando!4");
                playback.Speed = 1.0;
                playback.Start();
                isPlaying = true;
                Invoke("MyFunction",3);
            }
            board.UpdateScore("Ostacolo4");
        }
        else if (collision.otherCollider.tag == "Fondo") 
        {
            Debug.Log("Fondo");
            count++;
            Debug.Log(collision.collider);
            collision.collider.gameObject.SetActive(false);
            collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            collision.collider.gameObject.transform.position = new Vector3(0.97f, -0.785f, 4.84f);
            collision.collider.gameObject.SetActive(true);
            board.UpdateScore("Fondo");
            if (count == 3)
            {
                playback.Stop();
                output.Dispose();
                playback.Dispose();
                disposed = true;
                //EditorApplication.isPlaying = false;
                Debug.Log(EditorApplication.isPlaying);
                count=0;
                //ReopenProject();
                //EditorApplication.ExitPlaymode();
            }
           
        }
        else if (collision.otherCollider.tag == "PlungerAnchor") 
        {
            board.UpdateScore("PlungerAnchor");
        }
    }

    public static void ReopenProject()
{
    Debug.Log("Ciao log!");
    string projectPath = Application.dataPath.Remove(
        Application.dataPath.Length - "/Assets".Length, "/Assets".Length);
    //EditorApplication.OpenProject(projectPath);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
