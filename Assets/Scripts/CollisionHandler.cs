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
    [SerializeField] float rocketRotationForwardLerpSpeed = 0.1f;

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
        gameObject.GetComponent<Movement>().enabled = false;
        RotateRocketUpwards();
        isTransitioning = true;
        objectAudioSource.Stop();
        objectAudioSource.PlayOneShot(vfx_Success);
        ps_Success.Play();
        Invoke("LoadNextLevel", loadLevelDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        objectAudioSource.Stop();
        objectAudioSource.PlayOneShot(vfx_Explosion);
        ps_Explosion.Play();
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

    void RotateRocketUpwards()
    {
        Transform currentTransform = gameObject.GetComponent<Transform>();
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward);
        currentTransform.rotation = Quaternion.Lerp(currentTransform.rotation, targetRotation,
            Time.time * rocketRotationForwardLerpSpeed);
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }
}
