using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour
{
    public GameObject Player;

    public float walkDistance = 1;
    public float height = 1;//When it's 10 it will works well
    public RenderTexture MiniMapTexture;
    public Material MiniMapMaterial;
    public GameObject MiniMapCamera;
    //public float offset;

    void Awake()
    {
    }
    void Start()
    {
        if (Player == null)
        {
            Debug.Log("MiniMap's hero is gone!");
            return;
        }
        else
            Camerafowller();
    }
    void OnGUI()
    {
        if (Event.current.type == EventType.Repaint)
        {
            Graphics.DrawTexture(new Rect(Screen.width * 0.8f, Screen.height * 0.01f, 120, 120),
             MiniMapTexture, MiniMapMaterial);
        }
    }
    void Update()
    {
        Camerafowller();
    }

    public void Camerafowller()
    {
        MiniMapCamera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + height,
            Player.transform.position.z - walkDistance);
        MiniMapCamera.transform.LookAt(Player.transform);
    }
}