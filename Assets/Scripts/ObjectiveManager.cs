using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public GameObject objectivePanel;
    public TMP_Text objectiveDescriptionText;
    public Button objectiveButton;
    public Button closeButton;
    public GameObject pressurePlate;
    public GameObject box;
    public GameObject neilArmstrong;
    public GameObject water;
    public GameObject poison;

    public int currentObjective = 0;
    private List<Objective> level1Objectives = new List<Objective>{
        new Objective("Hm... it seems like you wrote that Buzz Aldrin was the first man on the moon. Let's go see if you can find a way to get into the spaceship. Press and hold G on objects to grab and move objects."),
        new Objective("Find a way to hold the next door open."),
        new Objective("Talk to Neil Armstrong."),
        new Objective("Maybe there's something for him to drink in the boxes upstairs. What if we poisoned Neil to stop him from being the first man on the moon? Press R next to certain boxes to break them."),
        new Objective("You found some water! There might be some poison hidden in the ship. Look around!"),
        new Objective("Poison Neil Armstrong by bringing him the poison.")
    };

    void Start()
    {
        // Initialize objective panel
        objectivePanel.SetActive(false);

        // Start with the first objective
        SetObjective();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == pressurePlate && currentObjective == 1)
        {
            CompleteObjective();
        }else if (other.gameObject == water && currentObjective == 4)
        {
            CompleteObjective();
        } else if (other.gameObject == poison && currentObjective == 5)
        {
            CompleteObjective();
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
        
    // }

    public void SetObjective()
    {
        objectivePanel.SetActive(true);
        objectiveDescriptionText.text = level1Objectives[currentObjective].description;
        currentObjective++;
        Debug.Log("Current objective: " + currentObjective);
    }

    public void CloseObjectivePanel()
    {
        objectivePanel.SetActive(false);
    }

    public void CompleteObjective()
    {
        // Logic to mark the current objective as completed
        // For example: currentObjective.Complete();
        
        // Switch to the next objective
        if (currentObjective < level1Objectives.Count)
        {
            SetObjective();
        }
        else
        {
            objectivePanel.SetActive(true);
            objectiveDescriptionText.text = "You have successfully poisoned Neil Armstrong. Mission accomplished! Now let's get out of here. Find the portal at the top floor";
            // Trigger end
        }
    }
}

[System.Serializable]
public class Objective
{
    public string description;
    public bool isCompleted;

    public Objective(string description)
    {
        this.description = description;
        this.isCompleted = false;
    }
}