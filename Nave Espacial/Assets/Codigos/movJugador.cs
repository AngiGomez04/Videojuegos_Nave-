using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movJugador : MonoBehaviour
{
    [SerializeField]
    private string estadoPlayer = "mi estado";
    public float velHorizontalAngiGomez = 5.0f;
    public float velVerticalAngiGomez = 6.0f;

    public int vidaJugadorAngiGomez = 3;

    public float movHorizontalAngiGomez;
    public float movVerticalAngiGomez;
    [SerializeField]
    public bool disparoTriple = false;

    public GameObject disparoL;
    public GameObject disparoT;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movimientoPersonajeAngiGomez();

        disparoPersonaje();
    }


    void movimientoPersonajeAngiGomez()
    {
        movHorizontalAngiGomez = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velHorizontalAngiGomez * movHorizontalAngiGomez); //Movimiento de traslación 

        movVerticalAngiGomez = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velVerticalAngiGomez * movVerticalAngiGomez);

        //Restringir movimiento en escenario Horizontal
        if (transform.position.x >= 7.7f)
        {
            Debug.Log(transform.position.x);
            transform.position = new Vector3(7.7f, transform.position.y, -0.50f);
        }

        else if (transform.position.x <= -7.7f)
        {
            transform.position = new Vector3(-7.7f, transform.position.y, 0.50f);
        }

        //Restringir movimiento en escenario vertical
        if (transform.position.y >= 2f)
        {
            transform.position = new Vector3(transform.position.x, 2f, -0.50f);
        }

        else if (transform.position.y <= -1f)
        {
            transform.position = new Vector3(transform.position.x, -1f, -0.50f);
        }

    } 

    void disparoPersonaje()
    {
        
       

        //Disparo triple con la letra space
        if(disparoTriple == true && Input.GetKey(KeyCode.Space))
        {
            //Centro
            Instantiate(disparoL, transform.position + new Vector3(0, 0.99f, 0), Quaternion.identity);
            //Izquierda
            Instantiate(disparoL, transform.position + new Vector3(-0.5f, 0.5803747f, 28.52615f), Quaternion.identity);
            //Derecha
            Instantiate(disparoL, transform.position + new Vector3(0.5f, 0.5803747f, 28.52615f), Quaternion.identity);

        } 

        //Disparo de una bala con la tecla espacio
        else if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(disparoL, transform.position + new Vector3(0, 0.99f, 0), Quaternion.identity);

        }
            
        }

    public void disparoTOn()
    {
        disparoTriple = true;
        StartCoroutine(disparoTUP());
    }

    IEnumerator disparoTUP()
    {
        yield return new WaitForSeconds(5.0f);
        disparoTriple = false;
    }

    //Aumento de velocidad en el movimiento vertical de la nave
    public void velocidadAumentada()
    {
        velVerticalAngiGomez = 10.0f;
        StartCoroutine(velAumentoDesactivado());
    }

    IEnumerator velAumentoDesactivado()
    {
        yield return new WaitForSeconds(10.0f);
        velVerticalAngiGomez = 4.0f;
    }


}