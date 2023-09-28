using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{

    AudioSource deathAudioSource;
    public GameObject deathFx;
    Renderer rend;

    bool alreadyTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        deathAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) { // OnCollisionEnter
        if (other.tag == "Player" && !alreadyTouched) {
            alreadyTouched = true;

            deathAudioSource.Play();

            Material newMaterial = new Material(Shader.Find("Standard"));
            newMaterial.color = Color.blue;
            
            changeColorOfAllElement(transform, newMaterial);

            Invoke(nameof(DestroyObject), deathAudioSource.clip.length);
        }
    }

    void DestroyObject()
    {
        Instantiate(deathFx, transform.position, Quaternion.identity);
        
        GameObject canva = GameObject.Find("Canvas");
        print(canva);
        canva.SendMessage("addHit");

        Destroy(gameObject);
    }

    void changeColorOfAllElement(Transform t, Material m){
        
        Renderer r = t.GetComponent<Renderer>();
        if(r){
            r.material.color = Color.red;
        }

        foreach(Transform child in t){
            Renderer r2 = t.GetComponent<Renderer>();
            if(r2){
                r2.material.color = Color.red;
            }
            changeColorOfAllElement(child, m);
        }
    }
}
