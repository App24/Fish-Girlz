using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnsureLoad : MonoBehaviour
{
    private void Awake() {
        SceneManager.LoadScene((int)Scenes.GameManager, LoadSceneMode.Additive);
    }
}
