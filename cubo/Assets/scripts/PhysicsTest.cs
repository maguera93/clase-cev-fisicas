using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    // el raycast es un rayo que al para generar las fisicas es lanzado y choca con los colliders de los obejtos.

    Ray ray; // el rayo que lanzamos
    RaycastHit hit; // nos devuelve el objeto con que el rayo ha chocado
    public LayerMask layer; // copia de lo que choca con el rayo
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position; // es para modificar la posicion de los rayos que estaran en los bordes del cubo
        int sign = 1;
        
        for(int i = 0; i < 3; i++) // es para generar 3 veces lo de abajo
        {
            pos.x += 0.5f * i * sign;
            sign *= -1; // es para trandformar la poscion de los rayos por cada loop
            
            ray = new Ray(transform.position, Vector3.down); // direccion del rayo
            hit = new RaycastHit(); //  

            if (Physics.Raycast(ray, out hit, 1.1f, layer)) // el out es cuando tenemos una funcion y queremos que la funcoin cambie uno de los paramtros de entrada que le hemos pasado, cuando llame a la funcio cambiara el parametro
            {
                Debug.Log(hit.transform.name); // devolvera el objeto q con el que se ha chocado
            }
        }
        
    }

    private void OnDrawGizmos() // dibuja gizmos estos gismos son para que detecten las colisiones, era esa linea / rayo que aparece vertical en magenta.
    {
        Gizmos.color = Color.magenta; // new Color32(254, 10 , 251, 255) -- esto otra forma de escribirlo, para para tener mas precision en el color

        Vector3 pos = transform.position;
        int sign = 1;

        for (int i = 0; i < 3; i++)
        {
            pos.x += 0.5f * i * sign;
            sign *= -1; // es para trandformar la poscion de los rayos por cada loop
            

            Gizmos.DrawRay(pos, Vector3.down); // es para que dibuje lo anterior
            
            
            
        }

        for (int i = 0; i < 3; i++)
        {
            pos.y += 0.5f * i * sign;
            sign *= -1; // es para trandformar la poscion de los rayos por cada loop


            
            Gizmos.DrawRay(pos, Vector3.right); // es para que dibuje lo anterior


        }
    }

}
