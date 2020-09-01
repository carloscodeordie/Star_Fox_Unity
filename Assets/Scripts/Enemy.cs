using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 120;
    [SerializeField] int healthPoints = 10;
    [SerializeField] int hits = 2;

    ScoreBoard scoreBoard;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider enemyBoxCollider = gameObject.AddComponent<BoxCollider>() as BoxCollider;
        enemyBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        KillEnemy();
    }

    private void UpdateScore()
    {
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void KillEnemy() {
        hits--;
        if (hits < 1)
        {
            UpdateScore();
            StartDeathFx();
            StartDeathSequence();
        }
    }

    private void StartDeathFx()
    {
        GameObject fx = Instantiate(deathFx, gameObject.transform.position, Quaternion.identity);
        fx.transform.SetParent(parent);
    }

    private void StartDeathSequence()
    {
        Destroy(gameObject);
    }
}