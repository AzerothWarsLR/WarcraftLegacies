using System;

namespace FastMDX {
    class ParsingException : Exception {
        public override string Message => "Parsing error.";
    }
}
