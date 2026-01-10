public interface ISaveable
{
    string ISaveableUniqueID {  get; set; }
    GameObjecttSave GameObjectSave {  get; set; }
    void ISaveableRegister();
    void ISaveableDeregister();
    void IsaveableStoreScene(string sceneName);
    void ISavableRestoreScene(string sceneName);
}