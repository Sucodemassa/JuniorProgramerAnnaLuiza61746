using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public GameObject Player;
    public Vector3 camerinha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + camerinha;
      

    }
}
