using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 25;
    [SerializeField] int hits = 3;

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () 
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }
    private void OnParticleCollision(GameObject otKher)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits = hits - 1;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
