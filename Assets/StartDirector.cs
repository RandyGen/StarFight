using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    public GameObject decision;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("GameScene");
            GameObject play = Instantiate(decision, transform.position, Quaternion.identity);
        }
    }
}
