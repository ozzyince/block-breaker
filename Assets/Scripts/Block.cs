using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameSession session;
    SpriteRenderer spriteRenderer;

    int timesHit = 0;

    private void Start()
    {
        if (!CompareTag("Breakable")) return;
        session = FindObjectOfType<GameSession>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CompareTag("Breakable")) return;
        if (++timesHit < MaxHits())
            ShowNextHitSprite();
        else
        {
            DestroyBlock();
            TriggerSparklesVFX();
        }
    }

    private void ShowNextHitSprite()
    {
        spriteRenderer.sprite = hitSprites[timesHit - 1];
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

    private int MaxHits()
    {
        return hitSprites.Length + 1;
    }
}
