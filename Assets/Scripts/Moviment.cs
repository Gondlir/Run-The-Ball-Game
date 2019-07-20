using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;
public class Moviment : MonoBehaviour {

    [SerializeField] private Camera myCam;
    [SerializeField] private Rigidbody myCamBody;
    [SerializeField] private Rigidbody myBody;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject shaker;

    private Vector2 direction;
    private Vector3 mousePosition;

    private float speed = 9f;
    private float speedBol = 3.5f;
    private float velocidadeBola = 6.7f;
    private float velCam;
    private float forçaBola;

    public AudioSource winAudio;
    public AudioSource boomAudio;

    
    private void Start()
    {
        if(winAudio.isPlaying)
            winAudio.Stop();
        if (boomAudio.isPlaying)
            boomAudio.Stop();      
    }
    void Update ()
    {
       if (!Levels.myLevel.startGame)
            return;       
    }
    private void FixedUpdate()
    {
        if (!Levels.myLevel.startGame)
            return;
        Forward();       
         if (Input.GetMouseButton(0))
         {
             transform.Translate(Vector3.forward * velocidadeBola * Time.fixedDeltaTime, Space.World);
             MovimentPlayer();
             float move = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
             transform.Translate(Vector3.right * move, Space.World);
         }                 
    }

    public void MovimentPlayer()
    {
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), speed * Time.deltaTime); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {           
            CameraShaker.Instance.ShakeOnce(16f, 16f, .4f, 4f);      
            Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>().Emit(20000);
            boomAudio.Play();
            gameObject.SetActive(false);
            Levels.myLevel.finish.SetActive(true);
            myCamBody.velocity = Vector3.zero;
            Debug.Log("colidiu");          
        }     
    }
 
    public void Forward()
    {
        myBody.velocity = Vector3.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Line")
        {
            winAudio.Play();
            Levels.myLevel.panel.SetActive(true);
            Levels.myLevel.startGame = false;
            myCamBody.velocity = Vector3.zero;           
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadSceneAsync("SampleScene");
        Debug.Log("Reload");
    }
}
