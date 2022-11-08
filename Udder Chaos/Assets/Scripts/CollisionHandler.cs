using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                Debug.Log("You Win");
                break;
            case "Fuel":
                Debug.Log("You got Fuel");
                break;
            default:
                Debug.Log("Sorry, you blew up!");
                break;
        }
    }
}