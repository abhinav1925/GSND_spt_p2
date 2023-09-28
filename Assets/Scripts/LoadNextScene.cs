using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
   public void NextSceneFunction() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
