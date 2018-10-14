using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class firebaseRouter : MonoBehaviour {

    private void Awake()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp, i.e.
                //   app = Firebase.FirebaseApp.DefaultInstance;
                // where app is a Firebase.FirebaseApp property of your application class.

                // Set a flag here indicating that Firebase is ready to use by your
                // application.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }
    private static DatabaseReference baseRef = FirebaseDatabase.DefaultInstance.RootReference;


    public static DatabaseReference Players()
    {
        return baseRef.Child("Players");
    }

    public static DatabaseReference PlayerWithUserID(string prUID)
    {
        return baseRef.Child("Players").Child(prUID);
    }

    public static DatabaseReference PlayerRef(string prUID)
    {
        return baseRef.Child("Players").Child(prUID);
    }

    public static DatabaseReference BaseRef()
    {
        return baseRef;
    }
}
