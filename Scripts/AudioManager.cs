using UnityEngine;

namespace RunnerJumper
{

public sealed class AudioManager
{

    private AudioSource _source;
    private AudioClip _endGameAudio;
    private AudioClip _collectAudio;

    public AudioManager(AudioSource source,AudioClip endGameAudio, AudioClip collect)
    {
        _endGameAudio = endGameAudio;
        _collectAudio = collect;
        _source = source;
    }

    public void PlayEndAudio()
    {
        _source.clip = _endGameAudio;
        _source.Play();
    }

    public void PlayCollectAudio()
    {
        _source.clip = _collectAudio;
        _source.Play();
    }

}

}
