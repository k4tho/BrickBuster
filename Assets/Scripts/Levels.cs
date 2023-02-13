using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public ReadOuts ReadOuts;
    public List<GameObject> levels;

    private int currentLevel;
    private GameObject levelGameObject;
    private void Start()
    {
        levelGameObject = CreateLevel();

        UpdateLevelReadout();
    }

    public void GoToNextLevel()
    {
        currentLevel++;
        if (IsGameOver())
            return;
        LoadNextLevel();
    }

    public bool IsGameOver()
    {
        if (currentLevel == levels.Count)
            return true;
        return false;
    }

    private void LoadNextLevel()
    {
        if (levelGameObject != null)
            Destroy(levelGameObject);

        levelGameObject = CreateLevel();

        UpdateLevelReadout();
    }

    private void UpdateLevelReadout()
    {
        ReadOuts.ShowLevel(currentLevel + 1);
    }

    private GameObject CreateLevel()
    {
        return Instantiate(levels[currentLevel], levels[currentLevel].transform.position, Quaternion.identity);
    }
}
