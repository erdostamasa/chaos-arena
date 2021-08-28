using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    [SerializeField] AudioSource source;
    [SerializeField] List<AudioClip> musicClips;
    
    float timer = 0;
    float trackLength;
    int currentTrack = 0;
    
    void Start() {
        source = GetComponent<AudioSource>();

        if (musicClips.Count == 0) return;
        musicClips.Shuffle();
        source.clip = musicClips[0];
        currentTrack = 0;
        trackLength = musicClips[0].length;
        
        source.Play();
    }

    
    void Update() {
        if (musicClips.Count == 0) return;
        timer += Time.deltaTime;
        if (timer >= trackLength) {
            timer = 0;
            currentTrack++;
            if (currentTrack == musicClips.Count) {
                musicClips.Shuffle();
                currentTrack = 0;
            }

            source.clip = musicClips[currentTrack];
            trackLength = musicClips[currentTrack].length;
            source.Play();
        }
        
    }
    
    
}
