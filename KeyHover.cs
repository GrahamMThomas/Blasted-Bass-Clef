using UnityEngine;
using System.Collections;

public class KeyHover : MonoBehaviour {

    private Color startcolor;
    Renderer renderer;
    private bool hovering;
    private bool pushing;
    private float movespeed = .1f;
    public static bool mouseCooldown;
    public BassClef bassClef;

    // Use this for initialization
    void Start ()
    {
        renderer = GetComponent<MeshRenderer>();
        bassClef = GameObject.Find("BassClefImage").GetComponent<BassClef>();
        startcolor = renderer.material.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0) && hovering && !mouseCooldown)
        {
            PressKey();
        }
    }

    void FixedUpdate()
    {
        if (pushing)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movespeed);
        }
        else if (transform.position.z > .4f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - movespeed);
        }
    }

    void OnMouseEnter()
    {
        hovering = true;
        if (!pushing)
        { 
            renderer.material.color = Color.grey;
        }
    }
    void OnMouseExit()
    {
        if (!pushing)
        {   
            renderer.material.color = startcolor;
        }
        hovering = false;
    }

    void PressKey()
    {
        GetComponent<AudioSource>().Play();
        Debug.Log("Pressed " + gameObject.name);
        if (bassClef.bassClef.sprite.name.Substring(0, 1) == gameObject.name)
        {
            Debug.Log("Correct");
            renderer.material.color = Color.green;
            bassClef.SwitchPicture();
        }
        else
        {
            Debug.Log("Incorrect. Correct: " + bassClef.bassClef.name.Substring(0, 1) + " You Pressed: " + gameObject.name);
            renderer.material.color = Color.red;
        }
        StartCoroutine("PushKey");
    }

    IEnumerator PushKey()
    {
        mouseCooldown = true;
        pushing = true;
        yield return new WaitForSeconds(.1f);
        pushing = false;
        yield return new WaitForSeconds(.1f);
        mouseCooldown = false;
        renderer.material.color = startcolor;
    }
}
