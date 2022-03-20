using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI charName;
    public TextAsset inkJSON;
    private Story story;
    private string sentence;
    public string[] character;
    private int index;
    public float typingSpeed;
    private AudioSource source;
    public PlayerController playerController;
    public GameObject npc;
    public GameObject npc2;
    private bool spacePressed = false;
    public Coroutine typer;


    void Start()
    {
        source = GetComponent<AudioSource>();
        story = new Story(inkJSON.text);
        sentence = story.Continue();
        typer = null;
    }

    public void TriggerDialog()
    {
        playerController.playerCanMove = false;
        playerController.speed = 0;
        typer = StartCoroutine(Type());
    }

    void Update(){
        if(textDisplay.text == sentence
           && Input.GetKeyDown(KeyCode.Space)){
            NextSentence();
        } else if (Input.GetKeyDown(KeyCode.Space)){
            StopCoroutine(typer);
            textDisplay.text = sentence;
        }
    }

    IEnumerator Type(){
        if (!spacePressed){
           foreach(char letter in sentence){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            }
        } 
        
    }
    
    public void NextSentence(){
        source.Play();

        if(story.canContinue){
            sentence = story.Continue();
            index++;
            textDisplay.text = "";
            typer = StartCoroutine(Type());
        } else{
            textDisplay.text = "";
            playerController.playerCanMove = true;
            playerController.speed = 100;
            Color tmp = npc.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            npc.GetComponent<SpriteRenderer>().color = tmp;
            Color tmp2 = npc2.GetComponent<SpriteRenderer>().color;
            tmp2.a = 0f;
            npc2.GetComponent<SpriteRenderer>().color = tmp2;
        }
    }
}
