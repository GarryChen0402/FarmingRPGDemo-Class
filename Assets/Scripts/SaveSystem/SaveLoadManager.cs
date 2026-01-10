using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveLoadManager : SingletonMonoBehaviour<SaveLoadManager>
{
    public List<ISaveable> iSaveableObjectList;

    protected override void Awake()
    {
        base.Awake();
        iSaveableObjectList = new List<ISaveable>();
    }

    public void StoreCurrentSceneData()
    {
        foreach(ISaveable o in iSaveableObjectList) o.IsaveableStoreScene(SceneManager.GetActiveScene().name);
    }

    public void RestoreCurrentSceneData()
    {
        foreach (ISaveable o in iSaveableObjectList) o.ISavableRestoreScene(SceneManager.GetActiveScene().name);
    }
}
