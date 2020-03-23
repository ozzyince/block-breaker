using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;

    Level level;
    GameSession session;

    private void Start()
    {
        if (!CompareTag("Breakable")) return;
        session = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CompareTag("Breakable")) return;
        DestroyBlock();
        TriggerSparklesVFX();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        session.AddScore();
    }

    private void TriggerSparklesVFX()
    {
        var sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
