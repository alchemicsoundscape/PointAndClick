using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ResourceLoader : MonoBehaviour
{
    public string Name;
    public string ResourceLocation;
    public Sprite activeSprite; 
    public SpriteRenderer spriteRenderer;
    public Dictionary<string,Sprite> Sprites;

    void Awake()
    {
        spriteRenderer = GameObject.Find("Map").GetComponent<SpriteRenderer>();
        Sprites = new Dictionary<string,Sprite>();
        LoadSprites();
    }
    
    protected void LoadSprites()
    {
        var sprites = Resources.LoadAll($"{ResourceLocation}/{Name}", typeof(Sprite)).Cast<Sprite>().ToList();

        foreach(var sprite in sprites)
        {
            Sprites.Add(sprite.name, sprite);
        }
    }
    
    public virtual Sprite GetSprite(string spriteName)
    {
        return Sprites[spriteName];
    }

    public void ChangeSprite(string spriteName)
    {
        activeSprite = GetSprite(spriteName);
        spriteRenderer.sprite = activeSprite;
    }
}