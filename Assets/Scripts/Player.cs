using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 2;
    private float collectablesCount = 0;



    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    
    private void MovePlayer() 
    {
        var direction = Vector3.zero;

        //
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        }
        //

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.back ;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }

        _rb.linearVelocity = direction.normalized * speed;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectables"))
        {
            other.gameObject.SetActive(false);
            collectablesCount++;
            print("Toplanan Balýk:"+collectablesCount);
        }
    }

}
