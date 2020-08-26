using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 120;

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
        StartDeathFx();
        StartDeathSequence();
        UpdateScore();
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

    private void UpdateScore()
    {
        scoreBoard.ScoreHit(scorePerHit);
    }
}