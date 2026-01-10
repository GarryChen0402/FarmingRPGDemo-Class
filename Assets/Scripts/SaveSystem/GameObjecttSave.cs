using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjecttSave 
{
    public Dictionary<string, SceneSave> sceneData;

    public GameObjecttSave()
    {
        sceneData = new Dictionary<string, SceneSave>();
    }

    public GameObjecttSave(Dictionary<string,  SceneSave> sceneData)
    {
        this.sceneData = sceneData;
    }
}
