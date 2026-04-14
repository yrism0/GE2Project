using UnityEngine;
using UnityEngine.Rendering;

public class limitCam : MonoBehaviour
{
    public GameObject player;

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 40 , player.transform.position.z);
    }
}
