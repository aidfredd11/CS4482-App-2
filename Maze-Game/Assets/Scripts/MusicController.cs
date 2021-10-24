using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController musicInstance;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        if(musicInstance == null)
        {
            musicInstance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

}
