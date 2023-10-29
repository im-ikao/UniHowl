using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UniHowl.Domain
{
    public class AudioName : ValueObject
    {
        private static HashSet<char> _notPermitedChars = new(Path.GetInvalidFileNameChars());
        public string Value { get; private set; }

        public AudioName(string value)
        {
            if (IsLengthValid(value) == false)
                throw new ArgumentException(nameof(IsLengthValid));

            if (IsPathValid(value) == false)
                throw new ArgumentException(nameof(IsPathValid));

            Value = value;
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
}