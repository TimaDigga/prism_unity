﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class WebStream : MonoBehaviour
{

    public static WebStream main;

    public string ip = "192.168.1.16:8080";
    string url;

    Texture latestFrame;
    int frameNumber;

    float freq = 0.05f;

    //public List<Texture> Frames;

    public List<Texture> Memories;



    private void Awake()
    {
        frameNumber = MirrorManager.Dimension.n;
        main = this;
        //Frames = new List<Texture>();
        //InvokeRepeating("AddFrame", 0, freq);

    }

    private void Start()
    {
        StartCoroutine(CheckFrame());
    }


    public void ResetIP(string newip)
    {
        ip = newip;
        //StopCoroutine("CheckFrame");
        //StartCoroutine(CheckFrame());
    }


    public Texture GetLatestFrame()
    {
        return latestFrame;
    }



    IEnumerator CheckFrame()
    {
        while (true)
        {
            url = "http://" + ip + "/shot.jpg";

            using (WWW www = new WWW(url))
            {
                yield return www;
                latestFrame = www.texture;
            }
        }
    }

}