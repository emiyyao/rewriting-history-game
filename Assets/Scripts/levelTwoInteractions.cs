using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelTwoInteractions : MonoBehaviour
{
    public GameObject proximityDetect;
    public float rayDist;
    public bool isHoldingScroll;
    public bool scrollFilledOut;
    public bool architectTurned;
    private bool hasWon;

    [SerializeField] public PlayerControl playerControl;
    private RaycastHit2D proximityCheck;
    [SerializeField] private LayerMask interactablesLayer;
    [SerializeField] private GameObject scroll;
    [SerializeField] public SpriteRenderer artist;
    [SerializeField] public SpriteRenderer architect;

    public CatControllerScript catController;
    public GameObject winScreen;
    private Sprite[] blueprintSprites;
    [SerializeField] public SpriteRenderer blueprintRenderer;

    public TMP_Text uiBanner;

    void Start(){
        isHoldingScroll = false;
        scrollFilledOut = false;
        architectTurned = false;
        hasWon = false;
        uiBanner.text = "";
        blueprintSprites = Resources.LoadAll<Sprite>("blueprint");
    }

    // Update is called once per frame
    void Update()
    {
        if(hasWon) {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
            hasWon = false;
        }

        if(playerControl.isFacingRight) {
            proximityCheck = Physics2D.Raycast(proximityDetect.transform.position, Vector2.right, rayDist, interactablesLayer);
        } else {
            proximityCheck = Physics2D.Raycast(proximityDetect.transform.position, Vector2.left, rayDist, interactablesLayer);
        }

        // if the player is close to an object and interacts with it
        if (proximityCheck.collider != null && (Input.GetKeyUp((KeyCode.Q)))){
            // Debug.Log(proximityCheck.collider.tag);

           if(proximityCheck.collider.tag == "scroll") {
            isHoldingScroll = true;
            Debug.Log("picked up scroll");
            uiBanner.text = "Picked up blank scroll.";
            Destroy(scroll);

           } else if(proximityCheck.collider.tag == "blueprint") {
                if(!architectTurned) {
                    Debug.Log("hey, don't touch my blueprint please -- im going to use it to build the sphinx");
                    uiBanner.text = "\"Don't touch my blueprint please -- I'm going to use it to build the sphinx.\"";
                } else if(isHoldingScroll && scrollFilledOut) {
                    Debug.Log("switched out blueprint");
                    uiBanner.text = "";
                    hasWon = true;
                }
                else if(!isHoldingScroll) {
                    Debug.Log("you need to replace the original blueprint with something or she'll notice.");
                    uiBanner.text = "You need to replace the original blueprint with something or the architect will notice.";
                }
                else if(!scrollFilledOut) {
                    Debug.Log("your scroll needs to contain a newly drawn version of the sphinx's blueprint");
                    uiBanner.text = "Your scroll needs to contain a newly drawn version of the sphinx's blueprint.";
                }
           } else if(proximityCheck.collider.tag == "artist") {
                if(isHoldingScroll && scrollFilledOut){
                    Debug.Log("i hope you like the plans i drew for you! use them wisely");
                    uiBanner.text = "\"I hope you like the plans I drew for you! Use them wisely.\"";
                }
                else if(isHoldingScroll && !scrollFilledOut){
                    // artist.flipX = true;
                    Debug.Log("the artist has drawn a new blueprint for you!");
                    uiBanner.text = "The artist has drawn a new blueprint for you!";
                    scrollFilledOut = true;
                } else if(!isHoldingScroll) {
                    Debug.Log("i can draw something for you if you bring me some papyrus");
                    uiBanner.text = "\"I can draw something for you if you bring me some papyrus.\"";
                }
           } else if(proximityCheck.collider.tag == "cat") {
                catController.moving = true;
           }
        }
    }
}
