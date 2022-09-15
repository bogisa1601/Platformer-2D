using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{

    public void OnClickContinueButton()
    {
        SaveDataController.Singleton.LoadData();

        SceneManager.LoadScene(SceneController.Singleton.lastSceneName);
    }
}
