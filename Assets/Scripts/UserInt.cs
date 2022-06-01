using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UserInt : MonoBehaviour
{
    private static int health = 3;
    private static int points = 0;
    public static float speed = 3.5f;
    public static float jumpforce = 5.5f;
    [SerializeField] private GameObject panel;
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] Scene _scene;
    [SerializeField] private AudioClip[] sounds = new AudioClip[4];
    [SerializeField] private Transform _transform;
    void Start()
    {
        text1.text = health.ToString();
        text2.text = points.ToString();
        _scene = SceneManager.GetActiveScene();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("s_powerup"))
        {
            Destroy(other.gameObject);
            speed = 6f;
            Invoke("Speednormal", 4f);
            AudioSource.PlayClipAtPoint(sounds[0], gameObject.transform.position);
        }
        if (other.gameObject.CompareTag("j_powerup"))
        {
            Destroy(other.gameObject);
            jumpforce = 7.5f;
            Invoke("Jumpforcenormal", 4f);
            AudioSource.PlayClipAtPoint(sounds[1], gameObject.transform.position);
        }
        if (other.gameObject.CompareTag("engel"))
        {
            health--;
            text1.text = health.ToString();
            if (health==0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
                speed = 3.5f;
                jumpforce = 5.5f;
                AudioSource.PlayClipAtPoint(sounds[2], gameObject.transform.position);
            } 
        }
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            points++;
            text2.text = points.ToString();
            AudioSource.PlayClipAtPoint(sounds[3], gameObject.transform.position);
        }
        if (other.gameObject.CompareTag("endlevel"))
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
    }
    void Speednormal()
    {
        speed = 3.5f;
    }
    void Jumpforcenormal()
    {
        jumpforce = 5.5f;
    }
}