using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 1.0f;
    [SerializeField] float restartLevelDelay = 1.0f;
    [SerializeField] AudioClip vfx_Explosion;
    [SerializeField] AudioClip vfx_Success;
    [SerializeField] ParticleSystem ps_Success;
    [SerializeField] ParticleSystem ps_Explosion;
    [SerializeField] LevelManager levelManager;

    AudioSource objectAudioSource;
    bool isTransitioning = false;
    bool collisionsActive = true;

    private void Start()
    {
        objectAudioSource = gameObject.GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            collisionsActive = !collisionsActive;
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Invoke("LoadNextLevel", loadLevelDelay);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning) { return; }
        if(collisionsActive)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Hit Launching Pad");
                    break;
                case "Finish":
                    Debug.Log("Hit Landing Pad");
                    StartSuccessSequence();
                    break;
                default:
                    Debug.Log("Hit an Obstacle");
                    StartCrashSequence();
                    break;
            }
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        objectAudioSource.Stop();
        objectAudioSource.PlayOneShot(vfx_Success);
        ps_Success.Play();
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadLevelDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        objectAudioSource.Stop();
        objectAudioSource.PlayOneShot(vfx_Explosion);
        ps_Explosion.Play();
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", restartLevelDelay);
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
    void ReloadLevel()
    {
        levelManager.ReloadLevel();
    }
}
