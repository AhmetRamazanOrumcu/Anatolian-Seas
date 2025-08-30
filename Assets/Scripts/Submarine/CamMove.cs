using UnityEngine;
using UnityEngine.Rendering;

public class CamMove : MonoBehaviour
{
    public float speed = 20f;   // dönüþ hýzý (derece/saniye)
    private float targetX = 0;// ilk hedef açý
    private float step = 0;

    //Player
    public Transform player;   // Inspector'dan Player atanacak
    public Vector3 offset;     // Kameranýn oyuncuya göre mesafesi



    void Start()
    {
        // Baþlangýçta X = -48, Y ve Z ayný kalsýn
        Vector3 startEuler = transform.eulerAngles;
        transform.eulerAngles = new Vector3(-48f, startEuler.y, startEuler.z);
    }

    void Update()
    {
        // Y ve Z sabit kalsýn
        float y = transform.eulerAngles.y;
        float z = transform.eulerAngles.z;

        // X eksenini hedefe doðru yumuþak hareket ettir
        float newX = Mathf.MoveTowardsAngle(transform.eulerAngles.x, targetX, speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(newX, y, z);

        // Eðer hedef açýya ulaþtýysa step'i 1 yap
        if (Mathf.Abs(Mathf.DeltaAngle(newX, targetX)) < 0.01f)
        {
            step = 1;
        }
    }
    void LateUpdate()
    {
        if (step == 1) // senin animasyon adýmlarýn bittiðinde
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
        }
    }
}
