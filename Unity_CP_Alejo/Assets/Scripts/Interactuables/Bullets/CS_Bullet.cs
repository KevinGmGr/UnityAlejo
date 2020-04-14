using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Bullet : MonoBehaviour
{
    public float Speed = 1;
    public float Damage = 10.0f;
    //TODO: Guardar una referencia quien crea la bala

    
    // Update is called once per frame
    void Update()
    {
        
        this.gameObject.transform.position += this.gameObject.transform.TransformDirection (Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HSAFA");
    }
}
