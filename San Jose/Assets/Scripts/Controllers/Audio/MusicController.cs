using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {

    public Sound[] sounds;

    public static MusicController musicInstance;


    //[Header("Control Elements")]
    //public AudioSource musicSource;
    //public bool hasEndedMusic;

    public float musicLength;
    public float musicTime;

    private void Awake() {
        if (musicInstance == null) musicInstance = this;
        else if (musicInstance != this) Destroy(gameObject);
        DontDestroyOnLoad(this);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.musicLength = s.source.clip.length;
            s.musicTime = s.source.time;
        }

    }

    // Start is called before the first frame update
    void Start() {
        //PlayMusic("Intro");
    }

    // Update is called once per frame
    void Update() {
        musicLength = sounds[0].source.clip.length;
        musicTime = sounds[0].source.time;
    }

    public void StopMusic(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public void PlayMusic (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
        musicTime = s.source.time;
        musicLength = s.source.clip.length;
    }

    /*public void SetMusic(AudioClip music) {
        musicSource.clip = music;
        musicSource.Play();
    }*/

    public void MusicChange(string music) {
        if (musicTime == musicLength) {
            PlayMusic(music);
        }
    }

}