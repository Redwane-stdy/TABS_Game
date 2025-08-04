using UnityEngine;

public class AudioManager_Principal : MonoBehaviour
{

    private static AudioManager_Principal instance;
    public float general_volume = -1;

    public AudioSource musique_audioSource;
    public AudioSource effets_audioSource;

    [SerializeField] private AudioClip buttonSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Récupérer les AudioSources
        AudioSource[] audioSources = GetComponents<AudioSource>();
        musique_audioSource = audioSources[0];
        effets_audioSource = audioSources[1];

        if (general_volume == -1)
        {
            general_volume = 0.5f;
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        if (musique_audioSource.clip != musicClip)
        {
            musique_audioSource.clip = musicClip;
            musique_audioSource.loop = true;
            musique_audioSource.Play();
        }
    }

    public void PlaySoundEffect(AudioClip soundEffect)
    {
        GetComponent<AudioSource>().PlayOneShot(soundEffect);
    }

    public void PlayButtonSound()
    {
        PlaySoundEffect(buttonSound);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
