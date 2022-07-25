using UnityEngine;


public class DotController : Singleton<DotController>
{
    public Vector3 initPosition;
    private Camera cameraMain;

    void Awake()
    {
        cameraMain = Camera.main;
        transform.position = initPosition;
    }

    public void MoveTo(Vector2 position)
    {
        Vector3 screenCoord = new Vector3(position.x, position.y, 0);
        Vector3 worldCoord = cameraMain.ScreenToWorldPoint(screenCoord);
        worldCoord.z = 0;
        transform.position = worldCoord;
    }
}

