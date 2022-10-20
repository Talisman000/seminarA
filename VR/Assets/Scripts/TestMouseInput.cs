using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// クリックした位置にオブジェクトを出現させるサンプルです。
/// </summary>
public class TestMouseInput : MonoBehaviour
{
    public Camera displayCamera;
    public GameObject prefab;
    public Transform cursor;

    public float screenOffsetZ = 10;
    public float worldOffsetY = 5;

    // Update is called once per frame
    void Update()
    {
        // マウスの座標（画面）
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = screenOffsetZ;
        // マウスの座標（３D空間）
        Vector3 mouseWorldPosition = displayCamera.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.y = worldOffsetY;

        cursor.position = new Vector3(mouseWorldPosition.x, 1f, mouseWorldPosition.z); 
        
        // マウスが左クリックされたかどうか
        bool isLeftClicked = Mouse.current.leftButton.wasPressedThisFrame;
        // マウスが左クリックされたとき
        if (isLeftClicked)
        {
            Debug.Log(mousePosition);
            Debug.Log(mouseWorldPosition);
            // Instantiate(gameObject, position, rotation): GameObjectを生成する
            // gameObject: 生成したいgameObject
            // position: 生成する座標
            // rotation: 難しい概念なのでとりあえずquaternion.identityでOK
            Instantiate(prefab, mouseWorldPosition, quaternion.identity);
        }
    }
}
