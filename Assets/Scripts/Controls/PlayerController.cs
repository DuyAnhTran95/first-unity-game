using UnityEngine;

namespace Controls
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public Vector3 initPosition;

        private Vector3 lastDestination;

        private InputManager inputManager;
        private Camera cameraMain;

        void Awake()
        {
            inputManager = InputManager.Instance;
            cameraMain = Camera.main;
            transform.position = initPosition;
            lastDestination = initPosition;
        }

        private void OnEnable()
        {
            inputManager.OnStartTouch += Move;
        }

        private void OnDisable()
        {
            inputManager.OnEndTouch -= Move;
        }

        void Move(Vector2 position, float time)
        {
            Vector3 screenCoord = new Vector3(position.x, position.y, 0);
            Vector3 worldCoord = cameraMain.ScreenToWorldPoint(screenCoord);
            worldCoord.z = 0;
            lastDestination = worldCoord;
        }

        private void Update()
        {
            Debug.Log("current position: " + transform.position);
            Debug.Log("destination: " + lastDestination);
            transform.position = Vector2.MoveTowards(transform.position, lastDestination, speed);
        }
    }
}
