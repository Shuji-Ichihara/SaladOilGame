using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTextManager : MonoBehaviour
{
    [SerializeField]
    private string _scoreName = "";
    private Text _score = null; 

    // Start is called before the first frame update
    void Start()
    {
        _score = GameObject.Find(_scoreName).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = PlayerControllerTest.BeanCount.ToString();
    }
}
