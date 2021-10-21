using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    private bool isGameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
       /* if (isGameEnded)
        {
            GameEnd();
        } */
    }
    // Finish line has been crossed
    public void GameEnd()
    {
        Debug.Log("GameEnd called");
        gameObject.SetActive(true);
    }
    public bool IsGameEnded
    {
        get { return isGameEnded; }
        set { isGameEnded = value; }
    }
}
