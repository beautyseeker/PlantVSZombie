using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音乐管理  注 采用Resources  加载  需放在Resources文件夹
/// </summary>
public class SoundMgr : MonoBehaviour
{
    public static SoundMgr Instance;

    private AudioSource audioSource;

    private Dictionary<string, AudioClip> cache = new Dictionary<string, AudioClip>();
    private void Awake()
    {
        Instance = this;

        audioSource = transform.GetComponent<AudioSource>();
    }

    private void Start()
    {

    }


    public AudioClip LoadAudio(string path)
    {
        return Resources.Load<AudioClip>(path);
    }


    public AudioClip GetAudioClip(string path)
    {
        if (!cache.ContainsKey(path))
        {
            AudioClip clip = LoadAudio(path);
            cache.Add(path, clip);

        }

        return cache[path];
    }

    //播放BGM
    public void PlayBGM(string name, float volume = 1f)
    {
        //停止播放
        audioSource.Stop();

        //再播放

        audioSource.clip = GetAudioClip(name);

        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void PlayEffect(string path, float volume = 1f)
    {
        audioSource.PlayOneShot(LoadAudio(path));
        audioSource.volume = volume;
    }
}
