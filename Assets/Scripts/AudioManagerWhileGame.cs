using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerWhileGame : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void PlayMode()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
