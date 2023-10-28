using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class AudioName : ValueObject
{
    private static HashSet<char> _notPermitedChars = new(Path.GetInvalidFileNameChars());
    public string Name { get; private set; }

    public AudioName(string name)
    {
        if (IsLengthValid(name) == false)
            throw new ArgumentException(nameof(IsLengthValid));

        if (IsPathValid(name) == false)
            throw new ArgumentException(nameof(IsPathValid));
        
        Name = name;
    }
    
    private bool IsLengthValid(string text)
    {
        return text.Length < 72;
    }

    private bool IsPathValid(string text)
    {
        return text.Any(ch => _notPermitedChars.Contains(ch)) == false;
    }
}
