using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Variable global y estática (una para todas las monedas)
    public static int coinsCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Coin.coinsCount++;
        Debug.Log("El juego ha empezado y ahora hay " + Coin.coinsCount + " monedas.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*OnTriggerEnter se llama cuando un objeto entra en contacto
     * con la clase, en este caso con la moneda. 
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            
            Coin.coinsCount--;
            Debug.Log("Hemos recogido la moneda y ahora hay " + Coin.coinsCount + " monedas.");
            if (Coin.coinsCount == 0)
            {
                Debug.Log("El juego ha terminado!");
                GameObject gameManager = GameObject.Find("GameManager");
                Destroy(gameManager);
                GameObject[] fireworksSystem = GameObject.FindGameObjectsWithTag("Firewords");
                foreach(GameObject fireworks in fireworksSystem)
                {
                    fireworks.GetComponent<ParticleSystem>().Play();
                }
            }
            Destroy(gameObject);
        }
         

    }
}
