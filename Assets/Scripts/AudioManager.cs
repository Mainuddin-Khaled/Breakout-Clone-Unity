using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Sound Effects")]
    public AudioClip paddleHitSound;
    public AudioClip wallHitSound;
    public AudioClip brickHitSound;
    public AudioClip brickBreakSound;
    public AudioClip loseLifeSound;
    public AudioClip winSound;
    public AudioClip gameOverSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayPaddleHit()
    {
        PlaySound(paddleHitSound);
    }

    public void PlayWallHit()
    {
        PlaySound(wallHitSound);
    }

    public void PlayBrickHit()
    {
        PlaySound(brickHitSound);
    }

    public void PlayBrickBreak()
    {
        PlaySound(brickBreakSound);
    }

    public void PlayLoseLife()
    {
        PlaySound(loseLifeSound);
    }

    public void PlayWin()
    {
        PlaySound(winSound);
    }

    public void PlayGameOver()
    {
        PlaySound(gameOverSound);
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}