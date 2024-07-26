using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaperDollRenderer : MonoBehaviour
{
    
    public SpriteRenderer dollRenderer;
    private SpriteRenderer layerRenderer;
    private Sprite[] sprites;
    // public Texture2D layerSprites;
    public string layerTextureName;

    // Start is called before the first frame update
    void Start()
    {
        layerRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(layerTextureName);
        // Debug.Log(layerSprites.name);
        // foreach(Sprite elem in sprites) {
        //     Debug.Log(elem);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // sr.sprite = sprites[0];
        // GetComponent<SpriteRenderer>().sprite.name
        /// Debug.Log(dollRenderer.sprite.name);
        sprites = Resources.LoadAll<Sprite>(layerTextureName);
        string dollSprite = dollRenderer.sprite.name; 
        int spriteNum = int.Parse(dollSprite.Substring(dollSprite.LastIndexOf("_")+1));
        // string spriteName = "char_a_p1_1out_pfpn_v" + spriteNum;
        /// Debug.Log(spriteName);
        layerRenderer.sprite = sprites[spriteNum];
        // spriteR.sprite = sprites[spriteVersion];
    }
}
