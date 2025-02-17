﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionManager : MonoBehaviour
{
    [SerializeField] private LayerMask Ground;
    public Texture2D cursor;

    private Vector3 mouseVec;

    private void Start()
    {
#if UNITY_STANDALONE_WIN
        var cursorOffset = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorOffset, CursorMode.Auto);
#endif
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, Ground))
        {
            mouseVec = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(mouseVec);
        }
    }

    public Vector3 GetMousePos()
    {
        return mouseVec;
    }
}