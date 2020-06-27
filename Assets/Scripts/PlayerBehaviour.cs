using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;
public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private Camera myCam;
    [SerializeField] private Rigidbody myCamBody;
    [SerializeField] private Rigidbody myBody;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject shaker;
    [SerializeField] private AudioSource winAudio;
    [SerializeField] private AudioSource boomAudio;
    [SerializeField] private MeshRenderer myMesh;

    public int myLifes { get; set; } //Contar quantas vidas o player perdeu[morreu]
    public int myPontuation { get; set; } //Contar quanto de moedas ele adquiriu 
    public static PlayerBehaviour instance;
    private float speed = 9f;
    private float ballVelocity = 6.7f;
    
   //Fazer checagem que... SE o Player já morreu naquela fase ele não precisa dar GO de novo e tambem mostrar as moedas na tela de inicialização do canvas
    private void Start()
    {
        instance = this;
        myMesh.material.color = explosion.GetComponent<Renderer>().sharedMaterial.color;
        if (winAudio.isPlaying)
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
             transform.Translate(Vector3.forward * ballVelocity * Time.fixedDeltaTime, Space.World);
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
            Levels.myLevel.deadPanel.SetActive(true);
            Levels.myLevel.currentStatusLevelAndCoinProgressPanel.SetActive(false);
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
            Levels.myLevel.nextPanel.SetActive(true);
            Levels.myLevel.currentStatusLevelAndCoinProgressPanel.SetActive(false);
            Levels.myLevel.startGame = false;
            myCamBody.velocity = Vector3.zero;
            myBody.isKinematic = true;
        }
    }
}
