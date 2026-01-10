using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class SceneTeleport : MonoBehaviour
{
    [SerializeField] private SceneName sceneNameGoTo = SceneName.Scene2_Field;
    [SerializeField] private Vector3 scenePositionGoto = new Vector3();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            // Calculate players new position
            //float xPosition = Mathf.Approximately(scenePositionGoto.x, 0f) ? player.transform.position.x : scenePositionGoto.x;
            //float yPosition = Mathf.Approximately(scenePositionGoto.y, 0f) ? player.transform.position.y : scenePositionGoto.y;
            //float zPosition = 0f;

            SceneControllerManager.Instance.FadeAndLoadScene(sceneNameGoTo.ToString(), scenePositionGoto);
        }
    }
}
