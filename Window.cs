using UnityEditor;
using UnityEngine;
using System.Collections;


public class Window : EditorWindow
{
    private Object source;
    private GameObject go;
    private GameObject Body;
    private GameObject child;
    private GameObject LeftLeg;
    private GameObject RightLegt;

    int i = 0;

    [MenuItem("Window/Urby G-Maker")]
    static void Init()
    {
        var window = GetWindowWithRect<Window>(new Rect(0, 0, 165, 100));
        window.Show();
        
    }
    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        source = EditorGUILayout.ObjectField(source, typeof(Object), true);
        EditorGUILayout.EndHorizontal();
        go = source as GameObject;
        if (source != null && i == 0)
        {
            Debug.Log("Objeto cargado");
            i = i + 1;
            Debug.Log(source.GetType() == typeof(GameObject));
        }
        else if (source == null)
        {
            i = 0;
        }
        if (GUILayout.Button("Add collider"))
        {
            AddMesh();
        }
        if(GUILayout.Button("Add rigidbody"))
        {
            AddRigidbody();
        }
        if (GUILayout.Button("Add Animator"))
        {
            AddAnimator();
        }
        if (GUILayout.Button("Model Detector"))
        {
            //ModelDetector();
            ModelDetectorJ();
        }
        if(GUILayout.Button("Add Manager"))
        {
            //GameObject manager=new GameObject("GameManager");
            GameObject manager = null;
            if (manager == null)
            {
                manager = new GameObject("GameManager"); 
                if (manager.GetComponent<GameManager_Master>() == null)
                {
                    manager.AddComponent<GameManager_Master>();
                }
            }
            else
            {
                Debug.Log("Ya existe un Game Manager");
            }
        }
        void AddMesh()
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                if (obj.GetComponent<BoxCollider>() != null)
                {
                    Debug.Log("El objeto ya cuenta con un collider");
                }
                else if (obj.GetComponent<BoxCollider>() == null)
                {
                    obj.AddComponent<BoxCollider>();
                }
            }
        }

    }
    void AddRigidbody()
    {
        foreach(GameObject obj in Selection.gameObjects)
        {
            if(obj.GetComponent<Rigidbody>()!= null)
            {
                Debug.Log("El objeto ya cuenta con un rigidbody");
            }
            else if(obj.GetComponent<Rigidbody>()==null)
            {
                obj.AddComponent<Rigidbody>();
            }
        }
    }
    void ModelDetectorJ()
    {
        Animator Body = go.GetComponent<Animator>();
        float x = Body.GetBoneTransform(HumanBodyBones.LeftLowerLeg).localPosition.x;
        float xII = Body.GetBoneTransform(HumanBodyBones.RightLowerLeg).localPosition.x;
        //float xIII = Body.GetBoneTransform(HumanBodyBones.).localPosition.x;
        if (x!=xII)
        {
            Debug.Log("Es bipedo");   
        }
    }
    void AddAnimator()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<Animator>() == true)
            {
                Debug.Log("El objeto ya cuenta con un animator");
            }
            else
            {
                obj.AddComponent<Animator>();
            }
        }
    }

    public class GameManager
    {
        public static GameManager instance = new GameManager();

        // make sure the constructor is private, so it can only be instantiated here
        public GameManager()
        {
        }
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

    
    }
}