using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class NPCDialogue : MonoBehaviour
{
    public ObjectiveManager objectiveManager;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public GameObject player;
    public GameObject water;
    public GameObject poison;
    public GameObject portal;

    private int encounter = 0;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log(objectiveManager.currentObjective);
        Debug.Log(encounter); ;

        if (other.gameObject == water && encounter >= 1)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = "Oh, you're back? Thanks!";
            other.gameObject.SetActive(false);
            encounter++;
        } else if (other.gameObject == poison)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = "I feel funny... What did you give me?";
            other.gameObject.SetActive(false);
            objectiveManager.currentObjective = 7;

        }else if (other.gameObject == player && encounter == 0)
        {
            // Trigger the dialogue when the player enters the NPC's trigger area
            dialoguePanel.SetActive(true);
            dialogueText.text = "I'm so thirsty... Hey you, can you get me a drink?";
            encounter++;
        } 
    }


    void Update()
    {
        if(!dialoguePanel.activeSelf && encounter == 1 && objectiveManager.currentObjective == 3)
        {
            objectiveManager.CompleteObjective();
        } else if (!dialoguePanel.activeSelf && encounter >= 1 && objectiveManager.currentObjective == 7)
        {
            objectiveManager.CompleteObjective();
            portal.SetActive(true);
            objectiveManager.currentObjective++;
        }
    }
}
