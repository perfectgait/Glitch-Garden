using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4.0f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        // @TODO numberOfAttackers could be 0 but a spawner could be in the
        // middle of spawning
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);

        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(waitToLoad);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;

        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            attackerSpawner.StopSpawning();
        }
    }
}
