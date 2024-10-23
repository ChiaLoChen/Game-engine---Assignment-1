using UnityEngine;
using System.Linq;
using System.Collections.Generic;

class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;

    private SortedList<float, Command> _recordedCommands =
        new SortedList<float, Command>();

    public void RecordCommand(Command command)
    {
        if (_isRecording)
        {
            float uniqueKey = _recordingTime;
            while (_recordedCommands.ContainsKey(uniqueKey))
            {
                uniqueKey += 0.0001f;
            }//solves clogging issues in recording the commands
            _recordedCommands.Add(uniqueKey, command);
        
            Debug.Log("Recorded Time: " + uniqueKey);
            Debug.Log("Recorded Command: " + command);
        }
    }


    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }
    
    public void notRecord()
    {
        _isRecording = false;
    }

    public void resumeRecord()
    {
        _isRecording = true;
    }
    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;
        if (_recordedCommands.Count <= 0)
            Debug.LogError("No commands to replay!");
        _recordedCommands.Reverse();
    }

    void FixedUpdate()
    {
        if (_isRecording)
            _recordingTime += Time.fixedDeltaTime;
        if (_isReplaying)
        {
            _replayTime += Time.fixedDeltaTime;
            if (_recordedCommands.Any())
            {
                if (Mathf.Approximately(
                        _replayTime, _recordedCommands.Keys[0]))
                {
                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " +
                              _recordedCommands.Values[0]);
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }
    }
}