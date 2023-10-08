using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Fungus.Vector3Arithmetic;

public class UIManager : MonoBehaviour {

    public CanvasGroup UI;
    private void Awake()
    {
        UI = FindObjectOfType<CanvasGroup>();

    }
     private void OnEnable(){
       SceneSwitchEventHandler.SwitchScenes += OnSwitchScenes;
  
     }

    private void OnDisable() {
        SceneSwitchEventHandler.SwitchScenes -= OnSwitchScenes;

    }

    private void OnSwitchScenes(string targetScene) {
        StartCoroutine(SwitchScenes(targetScene));
    }

    private IEnumerator SwitchScenes(string targetScene) {
        UI.GetComponentInParent <Canvas>().sortingOrder = 1;
        yield return Fade(1);
     
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        yield return LoadSceneSetActive(targetScene);
        yield return Fade(0);
        UI.GetComponentInParent<Canvas>().sortingOrder = -1;
    }

    private IEnumerator LoadSceneSetActive(string sceneName) {
        AsyncOperation SceneLoading= SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
       
        while (SceneLoading.progress<1f) {
            yield return null;
        }
      
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
    }
    private IEnumerator Fade(float targetAlpha) {

        UI.blocksRaycasts = true;
        float speed = Mathf.Abs(UI.alpha - targetAlpha) / 1.5f;
        while (!Mathf.Approximately(UI.alpha, targetAlpha)) {
            UI.alpha = Mathf.MoveTowards(UI.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
    

        UI.blocksRaycasts = false;
    }



}




