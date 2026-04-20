using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Sound Effects")]
    public AudioClip paddleHitSound;
    public AudioClip wallHitSound;
    public AudioClip brickHitSound;
    public AudioClip brickBreakSound;
    public AudioClip loseLifeSound;
    public AudioClip winSound;
    public AudioClip gameOverSound;

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    private bool musicMuted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    public void PlayPaddleHit()
    {
        PlaySFX(paddleHitSound);
    }

    public void PlayWallHit()
    {
        PlaySFX(wallHitSound);
    }

    public void PlayBrickHit()
    {
        PlaySFX(brickHitSound);
    }

    public void PlayBrickBreak()
    {
        PlaySFX(brickBreakSound);
    }

    public void PlayLoseLife()
    {
        PlaySFX(loseLifeSound);
    }

    public void PlayWin()
    {
        PlaySFX(winSound);
    }

    public void PlayGameOver()
    {
        PlaySFX(gameOverSound);
    }

    void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void ToggleMusic()
    {
        musicMuted = !musicMuted;

        if (musicSource != null)
        {
            musicSource.mute = musicMuted;
        }
    }
}