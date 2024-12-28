using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneChangeMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene0()
    {
        SceneManager.LoadScene(0);//preload scene, should not typically be used
    }
    public void Scene1()
    {
        SceneManager.LoadScene(1);//Main Menu Scene
    }
    public void Scene2()
    {
        SceneManager.LoadScene(2);//Leader Selection Scene
    }
    public void Scene3()
    {
        SceneManager.LoadScene(3);//Normal Combat Scene
    }
    public void Scene4()
    {
        SceneManager.LoadScene(4);//Intro Cutscene
    }
    public void Scene5()
    {
        SceneManager.LoadScene(5);//Starting Deck Scene
    }
    public void Scene6()
    {
        SceneManager.LoadScene(6);//Map Scene
    }
}
