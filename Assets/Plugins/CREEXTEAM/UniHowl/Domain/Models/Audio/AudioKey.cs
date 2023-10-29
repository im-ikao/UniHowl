using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UniHowl.Domain
{
// TODO: TEMPORARY PATH PERMITED CHARS
    public class AudioKey : ValueObject
    {
        private static HashSet<char> _notPermitedChars = new(Path.GetInvalidFileNameChars());
        public string Value { get; private set; }

        public AudioKey(string value)
        {
            if (IsLengthValid(value) == false)
                throw new ArgumentException(nameof(IsLengthValid));

            if (IsPathValid(value) == false)
                throw new ArgumentException(nameof(IsPathValid));

            Value = value;
        }

        private bool IsLengthValid(string text)
        {
            return text.Length < 42;
        }

        private bool IsPathValid(string text)
        {
            return text.Any(ch => _notPermitedChars.Contains(ch)) == false;
        }
    }
}