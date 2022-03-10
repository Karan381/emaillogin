using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro;

public class AuthManager : MonoBehaviour
{
    [SerializeField] InputField email;
    [SerializeField] InputField password;
    [SerializeField] InputField confirmPass;
    public Text infotext;
    FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;

        
        
        /*
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            Firebase.DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
          
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });*/

    }

    public void SignUp()
    {
        Debug.Log("Clicked SignUp");
        if (password.text == confirmPass.text)
        {
            auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
             {
                 if (task.IsCanceled)
                 {
                     Debug.LogError("Canceled");
                     return;
                 }
                 if (task.IsFaulted)
                 {             
                     Debug.LogError("Create Account Error" + task.Exception);
                     infotext.text = "Email/Pass Wrong Format";
                     return;
                 }
                 FirebaseUser newuser = task.Result;
                 Debug.LogFormat("Account Created", newuser.DisplayName, newuser.UserId);
                 infotext.text = "Account Created";
             });
        }
        else
        {
            Debug.Log("Passwords DOnt Match");
            infotext.text = "Passwords DOnt Match";
        }

    }
    public void SignIn()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
         {
             if (task.IsCanceled)
             {
                 Debug.LogError("Canceled");
                 return;
             }
             if (task.IsFaulted)
             {
                
                 Debug.LogError("signin Account Error" + task.Exception);
                 infotext.text = "No User with this mail or worng password";
                 return;
             }
             FirebaseUser returnuser = task.Result;
             Debug.LogFormat("SignIn Success", returnuser.DisplayName, returnuser.UserId);
             infotext.text = "Signed In";

         });
    }

  /*IEnumerator settext(string text)
    {
            infotext.text = text;
       
        yield return new WaitForSeconds(1f);
    }
  */


}
