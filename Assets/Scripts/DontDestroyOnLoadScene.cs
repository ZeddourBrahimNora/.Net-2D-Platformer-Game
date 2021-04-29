
using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects; // on va creer un tableau d'objets

    void Awake()
    {
        foreach (var element in objects) // pour chaque élement dans objet on va faire desroy 
        {
            DontDestroyOnLoad(element); 
        }   
    }

    
}
