using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    AudioSource source;

    void Awake() {
        instance = this;
    }

    Dictionary<SoundClip, int> playingCount;
    [SerializeField] Transform customOneShotPrefab;
    [SerializeField] SoundClip shopBuy;
    [SerializeField] SoundClip shopFail;
    
    
    public void ShopBuy() {
        PlayStatic(shopBuy);
    }

    public void ShopFail() {
        PlayStatic(shopFail);
    }
    
    void Start() {
        source = GetComponent<AudioSource>();
        playingCount = new Dictionary<SoundClip, int>();
    }

    public void PlayStatic(SoundClip clip) {
        source.clip = clip.file;
        source.volume = clip.volume;
        source.Play();
    }
    
    void PlayClipAtPointCustom(SoundClip clip, Vector3 position) {
        Transform tmp = Instantiate(customOneShotPrefab, position, Quaternion.identity);
        AudioSource source = tmp.GetComponent<AudioSource>();
        source.clip = clip.file;
        source.volume = clip.volume;
        source.Play();
        Destroy(tmp.gameObject, clip.file.length);
    }

    public void PlaySound(SoundClip clip, Vector3 position) {
        if (playingCount.ContainsKey(clip)) {
            if (playingCount[clip] < clip.maxPlaying) {
                //AudioSource.PlayClipAtPoint(clip.file, position, clip.volume);
                PlayClipAtPointCustom(clip, position);
                playingCount[clip] = playingCount[clip] + 1;
                //Debug.Log(clip.ToString() + playingCount[clip]);
                StartCoroutine(DecreaseCount(clip, clip.file.length));
            }
        }
        else {
            playingCount.Add(clip, 0);
            PlayClipAtPointCustom(clip, position);
            playingCount[clip] = playingCount[clip] + 1;
            //Debug.Log(clip.ToString() + playingCount[clip]);
            StartCoroutine(DecreaseCount(clip, clip.file.length));
        }
    }

    IEnumerator DecreaseCount(SoundClip clip, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        playingCount[clip] = playingCount[clip] - 1;
        //Debug.Log(clip.ToString() + playingCount[clip]);
    }
}