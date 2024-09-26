
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
    #region Fields

    // timer duration
    float totalSeconds = 0;

    // timer execution
    float elapsedSeconds = 0;
    bool running = false;

    // support for Finished property
    bool started = false;

    //Counter Mode
    bool counter = false;

    #endregion

    #region Properties

  
    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }

        get
        {
            return totalSeconds;
        }
    }

 
    public bool Finished
    {
        get { return started && !running; }
    }


    public bool Running
    {
        get { return running; }
    }


    public bool Started
    {
        get { return started; }
    }

    public float ElaspsedSeconds
    {
        get { return elapsedSeconds; }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // update timer and check for finished
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (!counter)
            {
                if (elapsedSeconds >= totalSeconds)
                {
                    running = false;
                }
            }
        }
    }

  
    public void Run()
    {
        // only run with valid duration
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    /// <summary>
    /// Stops the timer
    /// </summary>
    public void Stop()
    {
        started = false;
        running = false;
    }

    public void Counter()
    {
        counter = true;
        started = true;
        running = true;
        elapsedSeconds = 0;


    }

    #endregion
}

