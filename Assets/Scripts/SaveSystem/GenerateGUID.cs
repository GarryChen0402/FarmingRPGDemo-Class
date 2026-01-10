using UnityEngine;

[ExecuteAlways]
public class GenerateGUID : MonoBehaviour
{
    [SerializeField]
    public string _guid = "";

    public string GUID {  get =>  _guid; set =>_guid = value;}

    private void Awake()
    {
        if (!Application.IsPlaying(gameObject))
        {
            if(_guid == "")
            {
                _guid = System.Guid.NewGuid().ToString();
            }
        }
    }


}
