using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string[] m_requiredSceneNames;

    public void LoadRequiredScenes()
    {
        for (int iScene = 0; iScene < m_requiredSceneNames.Length; ++iScene)
        {
            SceneManager.LoadScene(m_requiredSceneNames[iScene], LoadSceneMode.Additive);
        }
    }

}
