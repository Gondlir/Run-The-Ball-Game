using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public GameObject explosion;
    float speed = 5.0f;
    float speedBol = 2.5f;
    public Rigidbody myBody;
    public float radius = 5.0F;
    public float power = 700.0F;
    public bool isAtive = false;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.Translate(Vector3.right * move);
        myBody.velocity = new Vector3(0, 0, 2 * speedBol);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isAtive = true;                      
            gameObject.SetActive(false);    
            Debug.Log("colidiu");
            
        }     
    }

    private void Explode()
    {            
        Collider[] coliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider proximo in coliders)
        {
            Rigidbody rb = proximo.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius);
                Debug.Log("EXPLODIU");         
            }
        }

    }

    private void Load()
    {
        StartCoroutine(Reload());
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync("SampleScene");
        Debug.Log("fodase");
            
    }
}
