﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmodemProtocol {
    public class StateUpdatedEventArgs {
        public States State { get; private set; }

        public StateUpdatedEventArgs(States state) {
            State = state;
        }
    }
}