using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public float speed;
    void Start()
    {

    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float dz = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector3(
            transform.position.x + dx, 0.5f, transform.position.z + dz
            );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            SceneManager.LoadScene("GAME CLEAR");
        }
    }
}
