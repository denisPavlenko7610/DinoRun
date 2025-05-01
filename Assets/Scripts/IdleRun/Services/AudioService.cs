using UnityEngine;

namespace IdleRun.Core
{
    public interface IAudioService : IGameService
    {
        void PlayMusic(string trackName);
        void PlaySfx(string clipName);
    }

    public class AudioService : IAudioService
    {
        private AudioSource _musicSource, _sfxSource;

        public void Initialize()
        {
            var go = new GameObject("AudioService");
            Object.DontDestroyOnLoad(go);
            _musicSource = go.AddComponent<AudioSource>();
            _sfxSource = go.AddComponent<AudioSource>();
        }

        public void PlayMusic(string trackName)
        {
            var clip = Resources.Load<AudioClip>($"Music/{trackName}");
            _musicSource.clip = clip;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        public void PlaySfx(string clipName)
        {
            var clip = Resources.Load<AudioClip>($"SFX/{clipName}");
            _sfxSource.PlayOneShot(clip);
        }
    }
}