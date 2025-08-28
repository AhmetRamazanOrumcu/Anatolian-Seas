using UnityEngine;
using UnityEngine.Rendering;

public class CamMove : MonoBehaviour
{
    public float speed = 20f;   // d�n�� h�z� (derece/saniye)
    private float targetX = 0;// ilk hedef a��
    private float step = 0;

    //Player
    public Transform player;   // Inspector'dan Player atanacak
    public Vector3 offset;     // Kameran�n oyuncuya g�re mesafesi



    void Start()
    {
        // Ba�lang��ta X = -48, Y ve Z ayn� kals�n
        Vector3 startEuler = transform.eulerAngles;
        transform.eulerAngles = new Vector3(-48f, startEuler.y, startEuler.z);
    }

    void Update()
    {
        // Y ve Z sabit kals�n
        float y = transform.eulerAngles.y;
        float z = transform.eulerAngles.z;

        // X eksenini hedefe do�ru yumu�ak hareket ettir
        float newX = Mathf.MoveTowardsAngle(transform.eulerAngles.x, targetX, speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(newX, y, z);

        // E�er hedef a��ya ula�t�ysa step'i 1 yap
        if (Mathf.Abs(Mathf.DeltaAngle(newX, targetX)) < 0.01f)
        {
            step = 1;
        }
    }
    void LateUpdate()
    {
        if (step == 1) // senin animasyon ad�mlar�n bitti�inde
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
        }
    }
}
