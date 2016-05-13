/*****************************************************\
*
*  Copyright (C) 2016, Douglas Knowman 
*  douglasknowman@gmail.com
*
*  Distributed under the terms of GNU GPL v3 license.
*  Always KISS.
*
\*****************************************************/

using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    // Public variables.
    public AudioClip jump;
    public AudioClip jumpEnd;

    public AudioClip spearLaunch;
    public AudioClip spearColl;
    public AudioClip spearTaked;

    public AudioClip paperGround;
    public AudioClip paperTaked;

    // Private variables.
    AudioSource[] sources = new AudioSource[7];
    int audioClips = 7;
    // Unity functions.
    void Awake()
    {
        EventManager.sfxEvent += SfxEventHandler;

        for (int i = 0; i < audioClips; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>()as AudioSource;
            sources[i].playOnAwake = false;
        }
    }
      
    // SoundManager functions.
    void SfxEventHandler(SfxEventType type)
    {
        switch (type)
        {
            case SfxEventType.Jump:
                sources[0].clip = jump;
                sources[0].Play();
                break;
            case SfxEventType.JumpEnd:
                sources[1].clip = jumpEnd;
                sources[1].Play();
                break;
            case SfxEventType.PaperGround:
                sources[2].clip = paperGround;
                sources[2].Play();
                break;
            case SfxEventType.PaperTake:
                sources[3].clip = paperTaked;
                sources[3].Play();
                break;
            case SfxEventType.SpearColl:
                sources[4].clip = spearColl;
                sources[4].Play();
                break;
            case SfxEventType.Shoot:
                sources[5].clip = spearLaunch;
                sources[5].Play();
                break;
            case SfxEventType.SpearTake:
                sources[6].clip = spearTaked;
                sources[6].Play();
                break;
                break;
        }
    }
}
