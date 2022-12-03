using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test2 : MonoBehaviour
{
    public float seconds;
    public Texture kusaTexture;
    public Texture karekusaTexture;
    public Texture tutiTexture;
    public Material TargetMaterial;
    public GameObject _map1;
    public GameObject _map2;

    //ŽžŠÔ‚ð‹L‰¯
    private float time = 0f;
    //•Ï‰»ŽžŠÔ_1
    private float change1 = 15f;
    //•Ï‰»ŽžŠÔ_2
    private float change2 = 20f;

    private void Start()
    {
        time = 0f;
        TargetMaterial.SetTexture("_MainTex", kusaTexture);
        TargetMaterial.color = new Color(0f, 0.6f, 0f, 1f);
    }

    void Update()
    {
        /*seconds += Time.deltaTime;
        if (seconds >= 15)
        {
            Debug.Log("“¤‚ª‚©‚ê‚»‚¤‚Å‚·");
            TargetMaterial.SetTexture("_MainTex", karekusaTexture);
            TargetMaterial.color = new Color(0.5f, 0.2f, 0f, 1f);
        }
        if(seconds >= 20)
        {
            seconds = 0;
            TargetMaterial.SetTexture("_MainTex", tutiTexture);
            TargetMaterial.color = new Color(1f, 0.6f, 0f, 1f);
            _map1.AddComponent<BoxCollider2D>();
            _map2.AddComponent<BoxCollider2D>();
        }*/

        time += Time.deltaTime;
        if (time >= change1)
        {
            TargetMaterial.SetTexture("_MainTex", karekusaTexture);
            TargetMaterial.color = new Color(0.5f, 0.2f, 0f, 1f);
        }
        if (time >= change2)
        {
            TargetMaterial.SetTexture("_MainTex", tutiTexture);
            TargetMaterial.color = new Color(1f, 0.6f, 0f, 1f);
        }

        if (NewPlayerMove.Revival)
        {
            time = 0f;
            TargetMaterial.SetTexture("_MainTex", kusaTexture);
            TargetMaterial.color = new Color(0f, 0.6f, 0f, 1f);
            NewPlayerMove.Revival = false;
        }
    }
}