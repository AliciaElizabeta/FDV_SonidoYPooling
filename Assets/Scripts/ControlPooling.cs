using UnityEngine;

public class ControlPooling : MonoBehaviour
{
    public GameObject prefabBase = null;
    public int cantidadInicial = 5;
    public int cantidadMaximaEnEscena = 6;
    public int contadorActual = 0;
    public int MaxCollect = 3;
    private Transform poolTransform;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    private void Start()
    {
        poolTransform = new GameObject("Pool").transform;

        // Crear objetos iniciales en el pool
        for (int i = 0; i < cantidadInicial; i++)
        {
            CrearObjeto();
        }
    }

    private void Update()
    {
        // Verificar si es necesario agregar más objetos a la escena
        if (GameObject.FindGameObjectsWithTag("ObjetoRecolectable").Length < cantidadMaximaEnEscena)
        {
            if(contadorActual != MaxCollect)
                CrearObjeto();
        }
    }

    private void CrearObjeto()
    {
        // Instanciar objeto del pool
        GameObject nuevoObjeto = Instantiate(prefabBase, poolTransform);
        nuevoObjeto.tag = "ObjetoRecolectable";

        // Posicionar el objeto aleatoriamente en la escena
        nuevoObjeto.transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));

        // Activar el objeto
        nuevoObjeto.SetActive(true);

        // Reproducir sonido al agregar un nuevo objeto
        audioSource1.Play();
    }

    public void collectedItem() 
    {
        contadorActual ++;
        Debug.Log(contadorActual);
        if (contadorActual == MaxCollect)
        {
            destroyPool();
        }
    }

    public void destroyPool()
    {
        audioSource2.Play();
        GameObject[] objetosConTag = GameObject.FindGameObjectsWithTag("ObjetoRecolectable");

        // Destruye cada objeto encontrado
        foreach (GameObject objeto in objetosConTag)
        {
            Destroy(objeto);
        }
    }
}