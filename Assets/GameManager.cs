using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject loginScreen;
    [SerializeField] GameObject registerScreen;

    private void Start()
    {
        loginScreen.SetActive(true);
        registerScreen.SetActive(false);
    }
    public void onclickSignUpLoginScreen()
    {
        loginScreen.SetActive(false);
        registerScreen.SetActive(true);
    }
    public void onclickBack()
    {
        loginScreen.SetActive(true);
        registerScreen.SetActive(false);
    }
}
