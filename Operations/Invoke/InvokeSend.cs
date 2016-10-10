﻿using System.Linq;

namespace XModemProtocol.Operations.Invoke {
    public class InvokeSend : Invoker {

        int _indexToBeSent;

        protected override void Invoke() {
            _requirements.Context.State = XModemStates.SenderPacketsBeingSent;
            _indexToBeSent = 0;
            SendPackets();
        }

        private void SendPackets() {
            SendNext();
            while(NotCancelled) {
                if (_requirements.Communicator.ReadBufferContainsData) {
                    _buffer.Add(_requirements.Communicator.ReadSingleByte());
                }
                else if (_buffer.Count != 0) { }
                else continue;


                if (LastResponseWasACK) {
                    _indexToBeSent++;
                    if (EOTSent) {
                        return;
                    }
                    SendNext();
                    Reset();
                }
                else if (LastResponseWasNAK) {
                    SendNext();
                    Reset();
                }
                else {
                    _buffer.AddRange(_requirements.Communicator.ReadAllBytes());
                    CheckForCancellation();
                }

            }
        }

        private bool EOTSent => _requirements.Context.Packets.Count < _indexToBeSent;
        private bool AllPacketsSent => _requirements.Context.Packets.Count == _indexToBeSent;
        private bool LastResponseWasACK => _buffer.Last() == _requirements.Options.ACK; 
        private bool LastResponseWasNAK => _buffer.Last() == _requirements.Options.NAK; 

        private void SendNext() {
            if (AllPacketsSent) {
                SendEOT();
                return;
            }
            FirePacketToSendEvent(); 
            _requirements.Communicator.Write(_requirements.Context.Packets[_indexToBeSent]);
        }

        private void SendEOT() {
            _requirements.Communicator.Write(_requirements.Options.EOT);
        }

        protected void FirePacketToSendEvent() {
            base.FirePacketToSendEvent(_indexToBeSent + 1, _requirements.Context.Packets[_indexToBeSent]);
        }
    }
}