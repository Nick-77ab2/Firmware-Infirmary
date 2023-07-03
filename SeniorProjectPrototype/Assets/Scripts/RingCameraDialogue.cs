using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using System;

public class RingCameraDialogue : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkAsset;

    [SerializeField]
    private Canvas m_canvas;
	[SerializeField]
    private GameObject m_Text;
    [SerializeField]
    private GameObject m_textButton;
    [SerializeField]
    private GameObject m_exitButton;

    public int mood;
    public int nextMood;
    public bool skipText=false;
    static Story _inkStory;
    static Choice choiceSelected;
    private Transform NPCPanel;
    public static bool coroutinesFinished = true;
    private Transform PlayerPanel1;
    private Transform PlayerPanel2;
    private Transform PlayerPanel3;
    private List<Transform> PlayerPanels = new List<Transform>();
    private int x = 0;
    public bool canStart = false;

    public void CustomAwake()
    {
        m_exitButton.SetActive(false);
        _inkStory = new Story(inkAsset.text);
        if(GameManager.instance.isTutorial == false){
            _inkStory.variablesState["Mood"] = mood;
            _inkStory.variablesState["NextMood"] = nextMood;
        }
        choiceSelected = null;
        NPCPanel = m_canvas.transform.Find("DialogueArea/DialogueHolder/NPCParent");
        PlayerPanel1 = m_canvas.transform.Find("DialogueArea/DialogueHolder/PlayerParent1");
        Debug.Log(PlayerPanel1);
        PlayerPanels.Add(PlayerPanel1);
        PlayerPanel2 = m_canvas.transform.Find("DialogueArea/DialogueHolder/PlayerParent2");
        PlayerPanels.Add(PlayerPanel2);
        PlayerPanel3 = m_canvas.transform.Find("DialogueArea/DialogueHolder/PlayerParent3");
        PlayerPanels.Add(PlayerPanel3);
        if (NPCPanel.childCount > 0)
        {
            Debug.Log("deleting them kids");
            RemoveChildren();
        }
        coroutinesFinished = true;
    }

    public void SetMoodIntercom(int value){
        if (value != -1)
        {
            mood = value;
        }
    }
    public void SetNextMoodIntercom(int value){
        if(value != -1)
        {
            nextMood = value;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            skipText = true;
        }
        if (coroutinesFinished)
        {
            coroutinesFinished = false;
            //Is there more to the _inkStory?
            if (_inkStory.canContinue)
            {
                AdvanceDialogue();
                //Are there any choices?
                x += 1;
                UnityEngine.Debug.Log("Removed " + x + " Times.");

            }
            else
            {
                FinishDialogue();
            }
        }
    }
     IEnumerator WaitRoutine(string currentSentence)
    {
        Debug.Log("Wait routine");
        yield return new WaitForSeconds(3f);
        RemoveChildrenNPC();
        StartCoroutine(CreateContentView(currentSentence));
    }

    private void FinishDialogue()
    {
        canStart = false;
    }

    // Advance through the _inkStory 
     void AdvanceDialogue()
    {
        if(choiceSelected!=null){
            RemoveChildren();
            choiceSelected = null;
        }
        string currentSentence = _inkStory.Continue();
        UnityEngine.Debug.Log(currentSentence);
        StopAllCoroutines();
        if (_inkStory.currentTags.Contains("delay"))
        {
            Debug.Log("got here");
            StartCoroutine(WaitRoutine(currentSentence));
        }
        else
        {
            StartCoroutine(CreateContentView(currentSentence));
        }
    }
    //Note to make sure to change to per word instead of per text.
    IEnumerator CreateContentView (string text) {
        if(skipText){
            skipText = false;
        }
        GameObject storyText = Instantiate (m_Text, NPCPanel);
		TMP_Text theText = storyText.GetComponentInChildren<TMP_Text>();
        theText.text="";
        string restText="";
        int x=0;
		string[] words = text.Split(' ');
        foreach (string word in words)
        {
            if (Input.GetKeyDown("space"))
            {
                skipText = true;
            }
            if (!skipText)
            {
                if (Input.GetKeyDown("space"))
                {
                    skipText = true;
                }
                else{
                    theText.text += word + " ";
                    if(x%5==0){
                        AkSoundEngine.PostEvent("Play_MessageBeep", gameObject);
                    }
                    x+=1;
                    yield return new WaitForSeconds(0.020f);
                }
            }
            else
            {
                restText += word + " ";
            }
        }
        if (skipText)
        {
            theText.text += restText;
            skipText = false;
        }
        try
        {
            var tags = _inkStory.currentTags;

            if (tags[0] == "last")
            {
                m_exitButton.SetActive(true);
                Debug.Log("Exit button set to active");
                if(_inkStory.variablesState["Mood"]!=null){
                    mood =(int) _inkStory.variablesState["Mood"];
                }
                if(_inkStory.variablesState["NextMood"]!=null){
                    nextMood= (int)_inkStory.variablesState["NextMood"];
                }
            }
        }
        catch { }

        if (_inkStory.currentChoices.Count != 0)
        {
            StartCoroutine(ShowChoices());
        }
        else
        {
            coroutinesFinished = true;
        }
        yield return null;
	}

    IEnumerator ShowChoices()
    {
        UnityEngine.Debug.Log("There are choices that need to be made here!");
        List<Choice> _choices = _inkStory.currentChoices;

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = Instantiate (m_textButton, PlayerPanels[i]);
		
		    // Gets the text from the button prefab
		    TMP_Text theText = temp.GetComponentInChildren<TMP_Text>();
            theText.text="";
		    /*foreach(char letter in _choices[i].text.ToCharArray())
            {
                theText.text+=letter;
                yield return new WaitForSeconds(0.01f);
            }
            */
             theText.text=_choices[i].text;
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = _choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
        }
        try
        {
            var tags = _inkStory.currentTags;
            Debug.Log(tags[0]);

            if (tags[0] == "last")
            {
                m_exitButton.SetActive(true);
                Debug.Log("Exit button set to active");
                if(_inkStory.variablesState["Mood"]!=null){
                    mood =(int) _inkStory.variablesState["Mood"];
                }
                if(_inkStory.variablesState["NextMood"]!=null){
                    nextMood= (int)_inkStory.variablesState["NextMood"];
                }
            }
        }
        catch { }

        yield return new WaitUntil(() => { return choiceSelected != null; });
    }

    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        _inkStory.ChooseChoiceIndex(choiceSelected.index);
        coroutinesFinished = true;
    }

    void AdvanceFromDecision()
    {
        RemoveChildren();
        choiceSelected = null; // Forgot to reset the choiceSelected. Otherwise, it would select an option without player intervention.
        AdvanceDialogue();
    }
    void RemoveChildren() {
		int childCount = NPCPanel.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (NPCPanel.GetChild(i).gameObject);
		}
		int childCount2 = PlayerPanels.Count;
		for (int i = 0; i <= childCount2 - 1; ++i) {
            try
            {
                Debug.Log(PlayerPanels[i].GetChild(0));
                GameObject.Destroy(PlayerPanels[i].GetChild(0).gameObject);
            }
            catch
            {
                continue;
            }
		}
	}
    
    void RemoveChildrenNPC()
    {
        int childCount = NPCPanel.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(NPCPanel.GetChild(i).gameObject);
        }
    }

    public void changeInkAsset(TextAsset newInk)
    {
        inkAsset = newInk;
    }

    public void changeCanvas(Canvas newCanvas)
    {
        m_canvas = newCanvas;
    }

    public void changeExitButton(GameObject newExit)
    {
        m_exitButton = newExit;
    }
}
