using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Finish", 1);
            SceneManager.LoadScene(0);
        }
    }
}
