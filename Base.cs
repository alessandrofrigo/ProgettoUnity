using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ciao");
    }
}