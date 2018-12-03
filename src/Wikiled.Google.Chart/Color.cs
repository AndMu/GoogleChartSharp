using System;

namespace Wikiled.Google.Chart
{
    public sealed class Color
    {
        internal Color(string name, string code)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        internal Color(string code)
        {
            Name = code ?? throw new ArgumentNullException(nameof(code));
            Code = code;
        }

        public string Name { get; }

        public string Code { get; }

        public override string ToString()
        {
            return Code;
        }
    }
}
