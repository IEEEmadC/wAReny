using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppManager : MonoBehaviour {

    public Slider loadingBar;
    
    // public GameObject loadingImage;
    public SaveLoadUtility slu;
   
    private AsyncOperation async;


    public void ClickAsync(string level)
    {
        // loadingBar.gameObject.SetActive(true);
        //StartCoroutine(LoadLevelWithBar(level));
        SceneManager.LoadScene(level);
    }


    IEnumerator LoadLevelWithBar(string level)
    {
        async = SceneManager.LoadSceneAsync(level);
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
    }

    public void SaveGameButton(GameObject saveNameInput)
    {
        saveNameInput.SetActive(!saveNameInput.activeSelf);
    }

    public void ExeucuteSaveGame(InputField field)
    {
        List<SaveGame> saves = SaveLoad.GetSaveGames(slu.saveGamePath, slu.usePersistentDataPath);
        if (field.text != "")
        {
            foreach (var s in saves)
            {
                if (s.savegameName == field.text)
                {
                    field.text = "";
                    field.GetComponentInChildren<Text>().text = "Save name already exists!";
                    return;
                }
            }

            if (GameObject.FindObjectsOfType<ObjectIdentifier>().Length == 0)
            {
                field.GetComponentInChildren<Text>().text = "There is nothing to save!";
                return;
            }


            for (int i = 1; i < GameObject.FindObjectsOfType<ObjectIdentifier>().Length; i++)
            {
                GameObject.FindObjectsOfType<ObjectIdentifier>()[i].transform.parent =
                    GameObject.FindObjectsOfType<ObjectIdentifier>()[0].transform;
            }
            
            slu.SaveGame(field.text);
            field.text = "";
            field.GetComponentInChildren<Text>().text = "Please enter name for your save!";
            field.transform.parent.parent.gameObject.SetActive(false);
        }          
        else
        {
            field.GetComponentInChildren<Text>().text = "Please enter name for your save!";
        }
    }
   

}
