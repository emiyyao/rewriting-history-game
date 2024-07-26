using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomizePanel : MonoBehaviour
{
    public GameObject customizationPanel;
    public PaperDollRenderer paperDollRenderer;
    
    public void showCustomizationMenu(){
        customizationPanel.SetActive(true);
    }

    public void hideCustomizationMenu(){
        Debug.Log("Hiding customization menu: " + customizationPanel.name);
        customizationPanel.SetActive(false);
    }

    public void setCharacterTexture(string layerTextureName) {
        paperDollRenderer.layerTextureName = layerTextureName;
    }
}

// char_a_p1_1out_fstr_v04
// char