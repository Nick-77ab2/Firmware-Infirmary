using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTutorialScript : MonoBehaviour
{

    public GameObject canvas;
    public GameObject player;
    public Collider body;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveUI()
    {
        canvas.SetActive(true);
    }

    public void SetUnactiveUI()
    {
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SetActiveUI();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SetUnactiveUI();
        }
    }
}
