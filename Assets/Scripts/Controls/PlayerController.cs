using UnityEngine;


public class PlayerController : Singleton<PlayerController>
{
    public float Speed;
    
    public Color MovingColor;
    public Color IdleColor;
    public Vector3 initPosition;

    private MovingPhase phase;
    private MovingPhase nextPhase;

    private Vector3 lastDestination;
    private Camera cameraMain;
    enum MovingPhase { Idle, Moving, Collide };

    void Awake()
    {
        cameraMain = Camera.main;
        transform.position = initPosition;
        lastDestination = initPosition;
        phase = MovingPhase.Idle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"collision with {collision.attachedRigidbody.tag}");
        if (collision.attachedRigidbody.CompareTag("Boundary"))
            Stop();
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //}

    private void ChangeColor(Color newColor)
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = newColor;
    }

    public void MoveTo(Vector2 position)
    {
        Vector3 screenCoord = new Vector3(position.x, position.y, 0);
        Vector3 worldCoord = cameraMain.ScreenToWorldPoint(screenCoord);
        worldCoord.z = 0;
        lastDestination = worldCoord;

        if (lastDestination != transform.position)
            nextPhase = MovingPhase.Moving;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, lastDestination, Time.deltaTime * Speed);
        if (transform.position == lastDestination)
            Stop();
    }

    private void Stop()
    {
        lastDestination = transform.position;
        nextPhase = MovingPhase.Idle;
    }
    private void Update()
    {
        switch (phase) {
            case MovingPhase.Idle:
                if (nextPhase == MovingPhase.Moving)
                    ChangeColor(MovingColor);
                break;
            case MovingPhase.Moving:
                Move();
                if (nextPhase == MovingPhase.Idle)
                    ChangeColor(IdleColor);
                break;
        }
        phase = nextPhase;
    }
}

