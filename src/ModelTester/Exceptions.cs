using System;

namespace ModelTester {
    class ParsingException : Exception {
        public override string Message => "Parsing error.";
    }
}
