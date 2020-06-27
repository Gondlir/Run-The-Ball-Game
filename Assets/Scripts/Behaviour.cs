using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Behaviour : MonoBehaviour {

    [SerializeField] private GameObject explosion;
    [SerializeField] private Rigidbody myBody;

    private float speed = 5.0f;
    private float speedBol = 2.5f;    
    private float radius = 5.0F;
    private float power = 700.0F;
    
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
            gameObject.SetActive(false);                        
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
    }
    
}
