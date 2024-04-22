using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Action OnPlayerDied;
    public Action OnPlayerScore;
    public Action OnPlayerWing;
    public Action OnLoad;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _wing;
    [SerializeField] private AudioClip _score;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _load;
    public bool IsEnabled = true;
    public static AudioController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) return;

        IsEnabled = PlayerPrefs.GetInt("AudioEnabled") == 1;
        Instance = this;
        OnPlayerDied += PlayDeathSound;
        OnPlayerScore += PlayScoreSound;
        OnPlayerWing += PlayWingSound;
        OnLoad += PlayStartGameSound;
    }
    
    private void PlayStartGameSound()
    {
        PlaySound(_load);
    }

    private void PlayScoreSound()
    {
        PlaySound(_score);
    }

    private void PlayWingSound()
    {
        PlaySound(_wing);
    }

    private void PlayDeathSound()
    {
        PlaySound(_death);
    }
    
    public void SwitchAudioAccess()
    {
        IsEnabled = !IsEnabled;
        PlayerPrefs.SetInt("AudioEnabled", IsEnabled ? 1 : 0);
    }
    
    private void PlaySound(AudioClip audio)
    {
        if (!IsEnabled) return;
        
        _audioSource.PlayOneShot(audio);
    }

    private void OnDestroy()
    {
        OnPlayerDied -= PlayDeathSound;
        OnPlayerScore -= PlayScoreSound;
        OnPlayerWing -= PlayWingSound;
        OnLoad -= PlayStartGameSound;
    }
}
