﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModemProtocol.Factories {
    using Tools;
    public class XModemToolFactory : IToolFactory {

        public IXModemTools GetToolsFor(XModemMode mode) {
            switch(mode) {
                case XModemMode.Checksum:
                    return new XModem128Tools();
                case XModemMode.CRC:
                    return new XModemCRCTools();
                case XModemMode.OneK:
                    return new XModemOneKTools();
                default:
                    return null;
            }
        }
    }
}