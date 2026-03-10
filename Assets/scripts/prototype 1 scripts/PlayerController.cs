using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject objeto;

    public int Velocidade;

    private MeshRenderer corzinha;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        corzinha = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (VerticalInput > 0)
            {
            transform.Rotate(Vector3.up * HorizontalInput);
        }
        else if (VerticalInput < 0)
        {
            transform.Rotate(Vector3.down * HorizontalInput);
        }

            transform.Translate(Vector3.forward * Time.deltaTime * Velocidade * VerticalInput);

        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
         if (transform.position.x >= 10)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
      if(transform.position.z>= 183 || transform.position.z <= -11)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,0);
        }

        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) && transform.localScale.x <= 3)
        {
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus) && transform.localScale.x > 0.5)
        {
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            corzinha.material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }
    
    
    }
}
