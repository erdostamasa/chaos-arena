using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    void Awake() {
        instance = this;
    }

    Dictionary<SoundClip, int> playingCount;
    [SerializeField] Transform customOneShotPrefab;

    void Start() {
        playingCount = new Dictionary<SoundClip, int>();
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
        }
    }

    IEnumerator DecreaseCount(SoundClip clip, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        playingCount[clip] = playingCount[clip] - 1;
        //Debug.Log(clip.ToString() + playingCount[clip]);
    }
}