using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetEdit : MonoBehaviour
{
    public void ResetStage()
    {
        ButtonManager.instance.ResetCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
