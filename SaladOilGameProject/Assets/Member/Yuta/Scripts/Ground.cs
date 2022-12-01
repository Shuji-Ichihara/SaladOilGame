using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //ŽžŠÔ‚ð‹L‰¯
    private float time = 0f;
    //•Ï‰»ŽžŠÔ_1
    private float change1 = 3f;
    //•Ï‰»ŽžŠÔ_2
    private float change2 = 5f;

    public Material colorA;
    public Material colorB;
    public Material colorC;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        GetComponent<Renderer>().material.color = colorA.color;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= change1)
        {
            GetComponent<Renderer>().material.color = colorB.color;
        }
        if (time >= change2)
        {
            GetComponent<Renderer>().material.color = colorC.color;
        }

        if (PlayerMove.Revival)
        {
            time = 0f;
            GetComponent<Renderer>().material.color = colorA.color;
            PlayerMove.Revival = false;
        }
    }
}
