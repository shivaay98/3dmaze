using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class accelerator : MonoBehaviour
{
    private Rigidbody rigid;
    public bool isflat = true;
    public float speed = 5f;
    public bool winloose = false;
    float movespeed = 5f;
    
    
    


    private hudmanager hudm;

   
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        hudm = GameObject.Find("HUD").GetComponent<hudmanager>();
    }
    
    
    private void FixedUpdate()
    {
        if (transform.position.y <= 0.4)
        {
            SceneManager.LoadScene(2);
            Debug.Log("lolll");
        }

        if (hudm.levelscore <= 1)
        {
            SceneManager.LoadScene(2);
        }



        float horizontalinput = Input.GetAxis("Horizontal");
         float verticalinput = Input.GetAxis("Vertical");

         transform.position = new Vector3(transform.position.x + horizontalinput * Time.deltaTime * speed,
            0.5f,
            transform.position.z + verticalinput * Time.deltaTime * speed); 

        

        Vector3 tilt = Input.acceleration * movespeed;

        if (isflat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;

        rigid.AddForce(tilt);

        

    }

    private IEnumerator winning()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
    }

    public void adjustspeed(float newspeed)
    {
        movespeed = newspeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("spike"))
        {
            hudm.levelscore -= 3;
            Destroy(collision.gameObject);

        }else
            if(collision.gameObject.CompareTag("win")&&winloose==false)
        {
            
            hudm.final();
            winloose = true;
            
            
            StartCoroutine(winning());

        }
        
        
        


    }
    


}
