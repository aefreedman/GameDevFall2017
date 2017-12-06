using UnityEngine;
using UnityEngine.Audio;

public class SnapshotTransition : MonoBehaviour
{

    public AudioMixerSnapshot[] Snapshots;
    
    public void SwitchSnapshot(int which)
    {
        Snapshots[which].TransitionTo(2f);
    }
}