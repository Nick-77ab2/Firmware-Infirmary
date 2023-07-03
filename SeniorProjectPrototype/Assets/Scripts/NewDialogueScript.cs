using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using Unity.VisualScripting;

public class NewDialogueScript : MonoBehaviour
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
    private static GameObject m_exitButton;

    static Story _inkStory;
    static Choice choiceSelected;
    private Transform NPCPanel;
    private Transform PlayerPanel;
    private int x = 0;
    private int y = 0;
    private int previousChoicesCount;

    public int mood;
    public int nextMood;
    public bool isSuccess = false;
    public int prevSuccess = -1;
    public string goToNext = "";
    public bool isFail = false;
    public bool isFinish = false;
    public bool skipText = false;
    public bool thereIsColor=false;
    public string YPZ=null;
    public string color=null;
    public bool next = false;
    public static bool coroutinesFinished = true;
    public List<string> m_Tags = new List<string>();

    void Awake()
    {
        m_exitButton.SetActive(false);
        _inkStory = new Story(inkAsset.text);
        if(GameManager.instance.isTutorial == false){
            _inkStory.variablesState["Mood"] = mood;
            _inkStory.variablesState["NextMood"] = nextMood;
        }

        if (prevSuccess != -1)
        {
            if (prevSuccess == 1)
            {
                _inkStory.variablesState["RepairOneSuccess"] = 1;
                _inkStory.variablesState["RepairOneFail"] = 0;
                Debug.Log( _inkStory.variablesState["RepairOneSuccess"]);
            }
            else
            {
                Debug.Log( _inkStory.variablesState["RepairOneFail"]);
                _inkStory.variablesState["RepairOneSuccess"] = 0;
                _inkStory.variablesState["RepairOneFail"] = 1;
            }
        }
        choiceSelected = null;
        Debug.Log(m_canvas);
        NPCPanel = m_canvas.transform.Find("TextParent/NPCParent/NPCTextBox");
        PlayerPanel = m_canvas.transform.Find("TextParent/PlayerParent/PlayerTextBox");
        coroutinesFinished = true;
    }

    public void SetPreviousSuccess(bool success)
    {
        if (success)
        {
            prevSuccess = 1;
        }
        else
        {
            prevSuccess = 0;
        }
    }

    public void SetGoToNext(string value)
    {
            goToNext = value;
    }

    public void SetMood(int value)
    {
        if (value != -1)
        {
            mood = value;
        }
    }
    public void SetNextMood(int value)
    {
        if (value != -1)
        {
            nextMood = value;
        }
    }



    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            skipText = true;
        }
        if (coroutinesFinished)
        {
            if (_inkStory.variablesState["RepairSuccess"] != null)
            {
                if (isSuccess != false)
                {
                    _inkStory.variablesState["RepairSuccess"] = 1;
                    _inkStory.variablesState["RepairFail"] = 0;
                }
                else if (isFail != false)
                {
                    _inkStory.variablesState["RepairSuccess"] = 0;
                    _inkStory.variablesState["RepairFail"] = 1;
                }
            }
            coroutinesFinished = false;
            //Is there more to the _inkStory?
            if (_inkStory.canContinue)
            {
                Debug.Log("Continuing Story.");
                m_Tags = _inkStory.currentTags;
                foreach (string tag in m_Tags)
                {
                    Debug.Log(tag);
                }
                Debug.Log(m_Tags);

                if (m_Tags.Count != 0)
                {
                    if (m_Tags.Contains("Lives")){
                        YPZ="Alive";
                    }
                    if(m_Tags.Contains("Dies")){
                        YPZ="Dead";
                    }
                    if(m_Tags.Contains("color")){
                        thereIsColor=true;
                        Debug.LogWarning("There is color");
                    }
                    if(m_Tags.Contains("next")){
                        next=true;
                        Debug.LogWarning("next");
                    }
                    Debug.Log("There are Tags.");
                    if (m_Tags.Contains("wait"))
                    {
                        Debug.LogWarning("STILL DEALING WITH TAGS");
                        if(prevSuccess!=-1){
                            if(prevSuccess==1 && isSuccess){
                                Debug.Log("Currently Success");
                                _inkStory.ChoosePathString("Repair_Success");
                                AdvanceDialogue();
                            }
                            else if(prevSuccess==1 && isFail){
                                Debug.Log("Currently Fail");
                                _inkStory.ChoosePathString("MessUpRepair");
                                AdvanceDialogue();
                            }
                            else if(prevSuccess==0 && isSuccess){
                                 Debug.Log("Currently Success");
                                _inkStory.ChoosePathString("Repair_Success1");
                                AdvanceDialogue();
                            }
                            else if(prevSuccess==0 && isFail){
                                Debug.Log("Currently Fail");
                                _inkStory.ChoosePathString("MessUpRepair1");
                                AdvanceDialogue();
                            }
                            else{
                                Debug.LogWarning("You shouldn't be here");
                                coroutinesFinished = true;
                            }

                        }
                        else if(prevSuccess==-1){
                            Debug.Log("Success: " + isSuccess + " Fail: " + isFail + " goToNext: " + goToNext);
                            if (!isSuccess && !isFail)
                            {
                                Debug.Log("no success or fail");
                                //RemoveChildrenNPC();
                                RemoveChildrenPlayer();
                                coroutinesFinished = true;
                            }
                            else if (isFail && m_Tags.Contains("diverts"))
                            {
                                Debug.Log("Calling MessUpRepair");
                                _inkStory.ChoosePathString("MessUpRepair");
                                AdvanceDialogue();
                            }
                            else if(isSuccess && m_Tags.Contains("diverts"))
                            {
                                Debug.Log("Calling Success");
                                _inkStory.ChoosePathString("Repair_Success");
                                AdvanceDialogue();
                            }
                            else
                            {
                                Debug.Log("success reached" + y);
                                AdvanceDialogue();
                                y += 1;
                            }
                        }
                        else
                        {
                            Debug.Log("success reached" + y);
                            AdvanceDialogue();
                            y += 1;
                        }
                    }
                    else if (goToNext != "" && m_Tags.Contains("Go"))
                    {
                        Debug.Log("fuck.");
                        _inkStory.ChoosePathString(goToNext);
                        AdvanceDialogue();
                    }
                    else
                    {
                        Debug.Log("Advancing Dialogue. Because tag wasn't wait");
                        AdvanceDialogue();
                        y += 1;
                    }
                }


                else
                {
                    Debug.Log("Advancing Dialogue. because no tags.");
                    AdvanceDialogue();
                    y += 1;
                }
            }
            else
            {
                Debug.Log("Finishing Dialogue.");
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
        if(GameManager.instance.isTutorial == false){
            mood = (int)_inkStory.variablesState["Mood"];
            nextMood = (int)_inkStory.variablesState["NextMood"];
        }
        Debug.Log("Mood:" + mood);
        Debug.Log("Next Mood:" + nextMood);
        if(thereIsColor){
            color=(string)_inkStory.variablesState["NewColor"];
            Debug.Log(color);
        }
        try
        {
            goToNext = (string)_inkStory.variablesState["ToGoNext"];
        }
        catch
        {
            Debug.Log("Doesn't exist");
        }

    }

    // Advance through the _inkStory 
    void AdvanceDialogue()
    {
        Debug.LogWarning("Currently In advance Dialogue.");
        if (choiceSelected != null)
        {
            RemoveChildrenPlayer();
            RemoveChildrenNPC();
            choiceSelected = null;
        }
        string currentSentence = _inkStory.Continue();
        Debug.Log(currentSentence);
        StopAllCoroutines();
        if (_inkStory.currentTags.Contains("delay"))
        {
            Debug.Log("got here" + y);
            StartCoroutine(WaitRoutine(currentSentence));
        }
        else
        {
            StartCoroutine(CreateContentView(currentSentence));
        }
    }
    //Reminder to Set this so that it runs per word instead of per letter.
    IEnumerator CreateContentView(string text)
    {
        if(skipText){
            skipText = false;
        }
        if (!string.IsNullOrEmpty(text))
        {
            if(NPCPanel.childCount>0){
                RemoveChildrenNPC();
            }
            GameObject _inkStoryText = Instantiate(m_Text, NPCPanel);
            Debug.Log("Instantiated NPCPanel for: " + text);
            TMP_Text theText = _inkStoryText.GetComponentInChildren<TMP_Text>();
            theText.text = "";
            string restText = "";
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
                            AkSoundEngine.PostEvent("Play_MessageBeep", this.gameObject);
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
        }
        try
        {
            var tags1 = _inkStory.currentTags;
            if (tags1.Contains("color"))
            {
                thereIsColor = true;
                Debug.LogWarning("There is color");
            }
            Debug.Log("Currently at CreateView Tags.");
            if (tags1.Contains("last") && _inkStory.currentChoices.Count == 0 && (isSuccess || isFail))
            {
                m_exitButton.SetActive(true);
                Debug.Log("Exit button set to active From Dialogue");
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
        /*
        Choice choice = _inkStory.currentChoices[0];
        string currentpathname = choice.sourcePath.Substring(0, choice.sourcePath.IndexOf("."));
        Debug.Log(currentpathname);
        if(currentpathname.Contains("Repair_Success") && (!isFail || !isSuccess)){
            yield return new WaitUntil(() => (isSuccess || isFail));
            yield return null;
        }
        */
        Debug.Log("We got here");
        //UnityEngine.Debug.Log("There are choices that need to be made here!");
        List<Choice> _choices = _inkStory.currentChoices;

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = Instantiate(m_textButton, PlayerPanel);

            // Gets the text from the button prefab
            TMP_Text theText = temp.GetComponentInChildren<TMP_Text>();
            theText.text = "";
            /*
		    foreach(char letter in _choices[i].text.ToCharArray())
            {
                theText.text+=letter;
                yield return new WaitForSeconds(0.01f);
            }
            */
            theText.text = _choices[i].text;
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = _choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
        }
        yield return new WaitUntil(() => { return choiceSelected != null; });

        //AdvanceFromDecision();
    }

    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        _inkStory.ChooseChoiceIndex(choiceSelected.index);
        coroutinesFinished = true;
        try
        {
            var tags = _inkStory.currentTags;
            NewDialogueScript dialogue = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
            if (tags.Contains("color"))
            {
                dialogue.thereIsColor = true;
                Debug.LogWarning("There is color");
            }
            //Debug.Log(tags[0]);
            Debug.Log("Currently at SetDecision Tags.");
            if (tags.Contains("last") && (dialogue.isSuccess || dialogue.isFail))
            {
                m_exitButton.SetActive(true);
                Debug.Log("Exit button set to active From Decision");
            }
            if(tags.Contains("wait")){
                dialogue.RemoveChildrenPlayer();
            }
        }
        catch { }
    }
    void RemoveChildrenNPC()
    {
        int childCount = NPCPanel.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(NPCPanel.GetChild(i).gameObject);
        }
    }
    void RemoveChildrenPlayer()
    {
        int childCount2 = PlayerPanel.childCount;
        for (int i = childCount2 - 1; i >= 0; --i)
        {
            GameObject.Destroy(PlayerPanel.GetChild(i).gameObject);
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