﻿using System;
namespace XModemProtocol {
    /// <summary>
    /// Provides data for the XModemProtocol.XModemCommunicator.RoleChanged event.
    /// </summary>
    public class RoleChangedEventArgs : EventArgs {
        /// <summary>
        /// The new role of the XModemCommunicator instance.
        /// </summary>
        public XModemRole Role { get; private set; }
        /// <summary>
        /// The old role of the XModemCommunicator instance.
        /// </summary>
        public XModemRole OldRole { get; private set; }
        /// <summary>
        /// Initializes a new instance of the XModemProtocol.RoleChangedEventArgs class.
        /// </summary>
        /// <param name="role">The current role of the instance.</param>
        /// <param name="oldRole">The old role of the instance.</param>
        internal RoleChangedEventArgs(XModemRole role, XModemRole oldRole) {
            Role = role;
            OldRole = oldRole;
        }
    }
}