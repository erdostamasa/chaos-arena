using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoundClip")]
public class SoundClip : ScriptableObject {
    public AudioClip file;
    [Range(0f,1f)]
    public float volume;
    public int maxPlaying;
}