using System;
using UnityEngine;

public interface ICreateWindow : IClickable
{

    public Camera Cam { get; set; }

    public GameObject Window { get; set; }



    // May be redundant when I complete VFX_Controller
    public ScreenFader Fader { get; set; }
    public ScreenFocus Focus { get; set; }
    // CHECK AGAIN and DELETE if neccesary


    /// <summary>
    /// Control what effects appear when window is created
    /// </summary>
    public void VFXSequence();

    /// <summary>
    /// Disable background objects through event so interaction is not ruined
    /// </summary>
    public void DisableBackground();

    /// <summary>
    /// Creates a window prefab with functionality (may be better to turn on/off existing one)
    /// </summary>
    /// <returns> Reference to created window </returns>
    public GameObject CreateWindow();
}
