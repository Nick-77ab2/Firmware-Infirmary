using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class PaintManager : Singleton<PaintManager>{

    public static PaintManager instance;
    private NewDialogueScript script;
    private ESCListen escListen;
    private bool isSuccess = false;

    public Shader texturePaint;
    public Shader extendIslands;

    int prepareUVID = Shader.PropertyToID("_PrepareUV");
    int positionID = Shader.PropertyToID("_PainterPosition");
    int hardnessID = Shader.PropertyToID("_Hardness");
    int strengthID = Shader.PropertyToID("_Strength");
    int radiusID = Shader.PropertyToID("_Radius");
    int blendOpID = Shader.PropertyToID("_BlendOp");
    int colorID = Shader.PropertyToID("_PainterColor");
    int textureID = Shader.PropertyToID("_MainTex");
    int uvOffsetID = Shader.PropertyToID("_OffsetUV");
    int uvIslandsID = Shader.PropertyToID("_UVIslands");

    public int maxPaint = 500;
    public int hitPaint = 0;
    public int missPaint = 0;

    Material paintMaterial;
    Material extendMaterial;

    CommandBuffer command;
    public DrawLine drawline;

    public override void Awake(){
        escListen = GameObject.Find("MiscManager").GetComponent<ESCListen>();
        base.Awake();
        drawline = GameObject.Find("PaintController").GetComponent<DrawLine>();
        instance = this;
        paintMaterial = new Material(texturePaint);
        extendMaterial = new Material(extendIslands);
        command = new CommandBuffer();
        command.name = "CommmandBuffer - " + gameObject.name;
    }

    public void initTextures(Paintable paintable){
        RenderTexture mask = paintable.getMask();
        RenderTexture uvIslands = paintable.getUVIslands();
        RenderTexture extend = paintable.getExtend();
        RenderTexture support = paintable.getSupport();
        Renderer rend = paintable.getRenderer();

        command.SetRenderTarget(mask);
        command.SetRenderTarget(extend);
        command.SetRenderTarget(support);

        paintMaterial.SetFloat(prepareUVID, 1);
        command.SetRenderTarget(uvIslands);
        command.DrawRenderer(rend, paintMaterial, 0);

        Graphics.ExecuteCommandBuffer(command);
        command.Clear();
    }
    public void Update(){
        Debug.Log("Escape Active?:" + escListen.escActive);
        if(Input.GetMouseButtonDown(0) && !isSuccess && !escListen.escActive){
                AkSoundEngine.PostEvent("Play_SprayPaint", this.gameObject);
                
                // CreateLine();
            }
            if (Input.GetMouseButtonUp(0))
            {
                AkSoundEngine.StopAll(this.gameObject);
            }
    }


    public void paint(Paintable paintable, Vector3 pos, float radius = 1f, float hardness = .5f, float strength = .5f, Color? color = null){
        Debug.Log("Painting");
        if((missPaint + hitPaint) < maxPaint && isSuccess == false && !escListen.escActive){
            if(paintable.gameObject.name == "miss"){
                missPaint++;
            }else{
                hitPaint++;
            }
            RenderTexture mask = paintable.getMask();
            RenderTexture uvIslands = paintable.getUVIslands();
            RenderTexture extend = paintable.getExtend();
            RenderTexture support = paintable.getSupport();
            Renderer rend = paintable.getRenderer();

            paintMaterial.SetFloat(prepareUVID, 0);
            paintMaterial.SetVector(positionID, pos);
            paintMaterial.SetFloat(hardnessID, hardness);
            paintMaterial.SetFloat(strengthID, strength);
            paintMaterial.SetFloat(radiusID, radius);
            paintMaterial.SetTexture(textureID, support);
            paintMaterial.SetColor(colorID, color ?? Color.red);
            extendMaterial.SetFloat(uvOffsetID, paintable.extendsIslandOffset);
            extendMaterial.SetTexture(uvIslandsID, uvIslands);

            command.SetRenderTarget(mask);
            command.DrawRenderer(rend, paintMaterial, 0);

            command.SetRenderTarget(support);
            command.Blit(mask, support);

            command.SetRenderTarget(extend);
            command.Blit(mask, extend, extendMaterial);

            Graphics.ExecuteCommandBuffer(command);
            command.Clear();
        }else{
            GameOver();
            AkSoundEngine.StopAll(this.gameObject);
        }
    }

    public void GameOver(){
        Debug.Log("GAME OVER PM");
        // GameObject.Find("Scores").GetComponent<RectTransform>().SetAsLastSibling();
        // GameObject.Find("RemainingPaint").GetComponent<TMP_Text>().text = "Remaining: " + (maxPaint - (hitPaint + missPaint)).ToString();
        // GameObject.Find("CorrectPaint").GetComponent<TMP_Text>().text = "Correct: " + hitPaint.ToString();
        // GameObject.Find("IncorrectPaint").GetComponent<TMP_Text>().text = "Incorrect: " + missPaint.ToString();
        isSuccess = true;
        script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
        AkSoundEngine.StopAll(drawline.gameObject);
        script.isSuccess = true;
    }
}
