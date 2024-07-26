using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public ObjectiveManager objectiveManager;
    public GameObject pressurePlate;


    private void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log("Box trigger");
        if (other.gameObject == pressurePlate)
        {
            // Debug.Log("Box activated pressure plate");
            // Trigger completion of the objective
            if (objectiveManager.currentObjective == 2){
                // Debug.Log("Objective 2 completed");
                objectiveManager.CompleteObjective();
            }
            
        }
    }
}
