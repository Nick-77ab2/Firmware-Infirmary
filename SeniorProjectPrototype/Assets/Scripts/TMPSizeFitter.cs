using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [AddComponentMenu("Layout/TMPSizeFitter")]
public class TMPSizeFitter : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI m_TextMeshPro;
    public TMPro.TextMeshProUGUI TextMeshPro
    {
        get { 
            if(m_TextMeshPro == null && transform.GetComponentInChildren<TMPro.TextMeshProUGUI>() != null)
            {
                m_TextMeshPro = transform.GetComponent<TMPro.TextMeshProUGUI>();
                m_TMPRectTransform = m_TextMeshPro.rectTransform;
            }
            return m_TextMeshPro;
        }
    }

    private RectTransform m_RectTransform;

    public RectTransform rectTransform { 
        get { 
            if(m_RectTransform == null)
            {
                m_RectTransform = GetComponent<RectTransform>();
            }
            return m_RectTransform;
        }
    }

    private RectTransform m_TMPRectTransform;

    public RectTransform TMPRectTransform { get {return m_TMPRectTransform;}}

    private float m_PreferredHeight;
    public float PreferredHeight { get {return m_PreferredHeight;}}

    private void SetHeight()
    {
        if(TextMeshPro == null)
            return;
        m_PreferredHeight = TextMeshPro.preferredHeight;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, m_PreferredHeight);
    }

    private void OnEnable()
    {
        SetHeight();
    }

    private void Start()
    {
        SetHeight();
    }

    private void Update()
    {
        if(PreferredHeight != TextMeshPro.preferredHeight)
        {
            SetHeight();
        }
    }

}
