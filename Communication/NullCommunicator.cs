﻿using System.Collections.Generic;

namespace XModemProtocol.Communication {
    internal class NullCommunicator : ICommunicator {
        public int BytesInReadBuffer => 0;
        public void Flush() { }
        public List<byte> ReadAllBytes() => new List<byte>();
        public byte ReadSingleByte() => 0;
        public void Write(IEnumerable<byte> buffer) { }
        public void Write(byte buffer) { }
    }
}