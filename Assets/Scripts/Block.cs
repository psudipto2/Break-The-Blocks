using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip BlockSounds;
    Level level;
    GameState gameState;
    [SerializeField] GameObject BlockSparkle;
    int timehits = 0;
    [SerializeField] Sprite[] HitSprites;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlock();
        }
    }
    private void DestryBlock()
    {
        Destroy(gameObject);
        level = FindObjectOfType<Level>();
        gameState = FindObjectOfType<GameState>();
        BlockSparkles();
        level.BlockDestroyed();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BreakOrNot();
    }
    public void BlockSparkles()
    {
        GameObject Sparkles = Instantiate(BlockSparkle, transform.position, transform.rotation);
        Destroy(Sparkles, 2f);
    }
    public void BreakOrNot()
    {
        timehits++;
        int maxHits = HitSprites.Length + 1;
        if ((maxHits == timehits)&&(tag=="Breakable"))
        {
            DestryBlock();
        }
        else if(tag=="Breakable")
        {
            ShowNextSprite();
        }
        AddScoring();
    }
    public void AudioControl()
    {
        AudioSource.PlayClipAtPoint(BlockSounds, Camera.main.transform.position);
    }
    public void AddScoring()
    {
        if (tag == "Breakable")
        {
            gameState = FindObjectOfType<GameState>();
            gameState.AddScore();
        }
    }
    public void ShowNextSprite()
    {
        int HitSpriteIndex = timehits-1;
        if (HitSpriteIndex != null)
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[HitSpriteIndex];
        }
       
    }
}
