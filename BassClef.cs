using UnityEngine;
using System.Collections;

public class BassClef : MonoBehaviour {

    public UnityEngine.UI.Image bassClef;
    public Sprite[] notes;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SwitchPicture()
    {
        bassClef.sprite = notes[Random.Range(0, 16)];
        GetComponent<AudioSource>().Play();
    }
}
