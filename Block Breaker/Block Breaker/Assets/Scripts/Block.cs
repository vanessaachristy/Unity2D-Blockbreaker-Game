using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakingSound;
    [SerializeField] GameObject blockSparklesVFX;

    //cached reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
        
    }

    private void DestroyBlock()
    {
        PlayingBreakSound();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerParticleVFX();
    }

    private void PlayingBreakSound()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
    }
    private void TriggerParticleVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    
    }
}
