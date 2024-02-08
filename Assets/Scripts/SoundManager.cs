using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance;
    public AudioSource audioSource;
    public Dictionary<string,AudioClip> dictAudio;
    private void Awake(){
        instance=this;
        audioSource = GetComponent<AudioSource>();
        dictAudio = new Dictionary<string, AudioClip>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AudioClip LoadAudio(string path){
        return (AudioClip)Resources.Load(path);
    }
    private AudioClip GetAudio(string path){
        if(!dictAudio.ContainsKey(path)){
            dictAudio[path]=LoadAudio(path);
        }
        return dictAudio[path];
    }
    public void PlayBGM(string name,float volume = 1.0f){
        audioSource.Stop();
        audioSource.clip = GetAudio(name);
        audioSource.Play();
    }
    public void StopBGM(){
        audioSource.Stop();
    }
    public void PlaySound(string path,float volume = 1.0f){
        audioSource.PlayOneShot(LoadAudio(path),volume);
        // audioSource.volume = volume;
    }
    public void PlaySound(AudioSource audioSource, string path, float volume = 1.0f)
    {
        audioSource.PlayOneShot(LoadAudio(path),volume);
        // audioSource.volume = volume;
    }
}
