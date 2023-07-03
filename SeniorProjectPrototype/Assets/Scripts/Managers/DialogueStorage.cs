using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStorage : MonoBehaviour
{
    [SerializeField]
    private TextAsset id1;
    [SerializeField]
    private TextAsset mg1d1;
    [SerializeField]
    private TextAsset mg2d1;
    [SerializeField]
    private Sprite sprite1;

    [SerializeField]
    private TextAsset id2;
    [SerializeField]
    private TextAsset mg1d2;
    [SerializeField]
    private TextAsset mg2d2;
    [SerializeField]
    private Sprite sprite2;

    [SerializeField]
    private TextAsset id3;
    [SerializeField]
    private TextAsset mg1d3;
    [SerializeField]
    private TextAsset mg2d3;
    [SerializeField]
    private Sprite sprite3;

    [SerializeField]
    private TextAsset id4;
    [SerializeField]
    private TextAsset mg1d4;
    [SerializeField]
    private TextAsset mg2d4;
    [SerializeField]
    private Sprite sprite4;

    [SerializeField]
    private TextAsset id5;
    [SerializeField]
    private TextAsset mg1d5;
    [SerializeField]
    private TextAsset mg2d5;
    [SerializeField]
    private Sprite sprite5;

    [SerializeField]
    private TextAsset id6;
    [SerializeField]
    private TextAsset mg1d6;
    [SerializeField]
    private TextAsset mg2d6;
    [SerializeField]
    private Sprite sprite6;

    [SerializeField]
    private TextAsset id71;
    [SerializeField]
    private TextAsset mg1d71;
    [SerializeField]
    private TextAsset mg2d71;
    [SerializeField]
    private Sprite sprite71;

    [SerializeField]
    private TextAsset id72;
    [SerializeField]
    private TextAsset mg1d72;
    [SerializeField]
    private TextAsset mg2d72;
    [SerializeField]
    private Sprite sprite72;

    [SerializeField]
    private TextAsset id8;
    [SerializeField]
    private TextAsset mg1d8;
    [SerializeField]
    private TextAsset mg2d8;
    [SerializeField]
    private Sprite sprite8;

    [SerializeField]
    private TextAsset id9;
    [SerializeField]
    private TextAsset mg1d9;
    [SerializeField]
    private TextAsset mg2d9;
    [SerializeField]
    private Sprite sprite9;

    [SerializeField]
    private TextAsset id10;
    [SerializeField]
    private TextAsset mg1d10;
    [SerializeField]
    private TextAsset mg2d10;
    [SerializeField]
    private Sprite sprite10;

    [SerializeField]
    private TextAsset id11;
    [SerializeField]
    private TextAsset mg1d11;
    [SerializeField]
    private TextAsset mg2d11;
    [SerializeField]
    private Sprite sprite11;

    [SerializeField]
    private TextAsset id12;
    [SerializeField]
    private TextAsset mg1d12;
    [SerializeField]
    private TextAsset mg2d12;
    [SerializeField]
    private Sprite sprite12;

    public Dictionary<int, List<TextAsset>> storage = new Dictionary<int, List<TextAsset>>();
    public Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();
    [SerializeField] private DialogueManager dialogueManager;

    void Awake()
    {
        List<TextAsset> textAssets1 = new List<TextAsset>();
        textAssets1.Add(id1);
        textAssets1.Add(mg1d1);
        textAssets1.Add(mg2d1);
        storage.Add(1, textAssets1);
        sprites.Add(1, sprite1);

        List<TextAsset> textAssets2 = new List<TextAsset>();
        textAssets2.Add(id2);
        textAssets2.Add(mg1d2);
        textAssets2.Add(mg2d2);
        storage.Add(2, textAssets2);
        sprites.Add(2, sprite2);

        List<TextAsset> textAssets3 = new List<TextAsset>();
        textAssets3.Add(id3);
        textAssets3.Add(mg1d3);
        textAssets3.Add(mg2d3);
        storage.Add(3, textAssets3);
        sprites.Add(3, sprite3);

        List<TextAsset> textAssets4 = new List<TextAsset>();
        textAssets4.Add(id4);
        textAssets4.Add(mg1d4);
        textAssets4.Add(mg2d4);
        storage.Add(4, textAssets4);
        sprites.Add(4, sprite4);

        List<TextAsset> textAssets5 = new List<TextAsset>();
        textAssets5.Add(id5);
        textAssets5.Add(mg1d5);
        textAssets5.Add(mg2d5);
        storage.Add(5, textAssets5);
        sprites.Add(5, sprite5);

        List<TextAsset> textAssets6 = new List<TextAsset>();
        textAssets6.Add(id6);
        textAssets6.Add(mg1d6);
        textAssets6.Add(mg2d6);
        storage.Add(6, textAssets6);
        sprites.Add(6, sprite6);

        List<TextAsset> textAssets71 = new List<TextAsset>();
        textAssets71.Add(id71);
        textAssets71.Add(mg1d71);
        textAssets71.Add(mg2d71);
        storage.Add(71, textAssets71);
        sprites.Add(71, sprite71);

        List<TextAsset> textAssets72 = new List<TextAsset>();
        textAssets72.Add(id72);
        textAssets72.Add(mg1d72);
        textAssets72.Add(mg2d72);
        storage.Add(72, textAssets72);
        sprites.Add(72, sprite72);

        List<TextAsset> textAssets8 = new List<TextAsset>();
        textAssets8.Add(id8);
        textAssets8.Add(mg1d8);
        textAssets8.Add(mg2d8);
        storage.Add(8, textAssets8);
        sprites.Add(8, sprite8);

        List<TextAsset> textAssets9 = new List<TextAsset>();
        textAssets9.Add(id9);
        textAssets9.Add(mg1d9);
        textAssets9.Add(mg2d9);
        storage.Add(9, textAssets9);
        sprites.Add(9, sprite9);

        List<TextAsset> textAssets10 = new List<TextAsset>();
        textAssets10.Add(id10);
        textAssets10.Add(mg1d10);
        textAssets10.Add(mg2d10);
        storage.Add(10, textAssets10);
        sprites.Add(10, sprite10);

        List<TextAsset> textAssets11 = new List<TextAsset>();
        textAssets11.Add(id11);
        textAssets11.Add(mg1d11);
        textAssets11.Add(mg2d11);
        storage.Add(11, textAssets11);
        sprites.Add(11, sprite11);

        List<TextAsset> textAssets12 = new List<TextAsset>();
        textAssets12.Add(id12);
        textAssets12.Add(mg1d12);
        textAssets12.Add(mg2d12);
        storage.Add(12, textAssets12);
        sprites.Add(12, sprite12);
        GameManager.StateChanged += GameManagerOnStateChanged;
    }

    void OnDestroy()
    {
        GameManager.StateChanged -= GameManagerOnStateChanged;
    }

    private void GameManagerOnStateChanged(GameManager.GameState state)
    {
        if(state == GameManager.GameState.DayBegin){
            Debug.Log(GameManager.instance.dayNum);
            if (GameManager.instance.dayNum == 7)
            {
                Debug.Log(GameManager.instance.ypz);
                if (GameManager.instance.ypz == 0)
                {
                    List<TextAsset> textAssets = storage[71];
                    dialogueManager.changeDayScripts(textAssets[0], textAssets[1], textAssets[2], sprites[71]);
                }
                else
                {
                    List<TextAsset> textAssets = storage[72];
                    dialogueManager.changeDayScripts(textAssets[0], textAssets[1], textAssets[2], sprites[72]);
                }
            }
            else
            {
                List<TextAsset> textAssets = storage[GameManager.instance.dayNum];
                dialogueManager.changeDayScripts(textAssets[0], textAssets[1], textAssets[2], sprites[GameManager.instance.dayNum]);
            }
        }   
    }
}
