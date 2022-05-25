using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{

    [SerializeField] float levelYBoundary = -2f;
    bool alive = true;

    [SerializeField] AudioSource deathSound; 

    private void Update() {
        if(transform.position.y < levelYBoundary && alive){
            Die();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body")){
            // If player touches something with enemy body tag, death
            Die();
            // hide player, stop movement 
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
        }
    }

    void Die(){
        alive = false;
        // restart level after 1.3secs
        deathSound.Play();  
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
