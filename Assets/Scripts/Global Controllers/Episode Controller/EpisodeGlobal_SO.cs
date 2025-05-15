using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "EpisodeGlobal_SO", menuName = "Scriptable Objects/EpisodeGlobal_SO")]
public class EpisodeGlobal_SO : ScriptableObject
{
    public List<DialogueData_SO> episodeDialogSequence;
    
}
