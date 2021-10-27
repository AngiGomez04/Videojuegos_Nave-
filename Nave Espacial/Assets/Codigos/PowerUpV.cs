using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpV : MonoBehaviour
{
    private float velocidadUp = 3.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidadUp * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Nave")
        {
            movJugador naveV = collision.gameObject.GetComponent<movJugador>();
            naveV.velocidadAumentada();
            Destroy(this.gameObject);
        }
    }


}
