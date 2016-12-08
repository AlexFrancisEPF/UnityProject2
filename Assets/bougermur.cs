using UnityEngine;
using System.Collections;

public class bougermur : MonoBehaviour {

    public GameObject objet;
    [SerializeField] private AudioClip Bruit;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           objet.transform.Rotate(0, 90, 0);
            GetComponent<AudioSource>().PlayOneShot(Bruit);
        }
    }

}
