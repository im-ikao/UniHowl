using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class AudioFolderPath : ValueObject
{ 
    //private static HashSet<char> _notPermitedChars = new(Path.GetInvalidFileNameChars());
    public string FolderPath { get; private set; }

    public AudioFolderPath(string path)
    {
        if (IsLengthValid(path) == false)
            throw new ArgumentException(nameof(IsLengthValid));

        /*
        if (IsPathValid(path) == false)
            throw new ArgumentException(nameof(IsPathValid));
        */
        
        FolderPath = path;
    }
    
    private bool IsLengthValid(string text)
    {
        return text.Length < 255;
    }

    private bool IsPathValid(string text)
    {
        throw new NotImplementedException();
        //return text.Any(ch => _notPermitedChars.Contains(ch)) == false;
    }
}
