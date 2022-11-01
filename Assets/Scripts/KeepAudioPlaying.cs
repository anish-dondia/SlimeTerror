using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudioPlaying : MonoBehaviour
{
    private static KeepAudioPlaying audioPlayer;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if(audioPlayer == null)
        {
            audioPlayer = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
