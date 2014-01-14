using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace UV_DLP_3D_Printer
{
    public class AuthenticationManager
    {
        public static int VID_Default  = 0; // no vendor - Default License
        public static int VID_Pro                    = 1; // pro license
        public static int VID_ALT3                   = 2; // Alt3 technologies
        public static int VID_Stalagtite3D_SPOTA     = 3;
        public static int VID_Elite = 4;

        private bool auth;
        private int vendorid;
        private static AuthenticationManager m_instance = null;

        public AuthenticationManager Instance() 
        {
            if (m_instance == null) 
            {
                m_instance = new AuthenticationManager();
            }
            return m_instance;
        }

        public AuthenticationManager() 
        {
            auth = false;
            vendorid = VID_Default; // no vendor
        }
        /// <summary>
        /// This returns whether or not the key has been authenticated
        /// </summary>
        public bool Authenticated 
        {
            get { return auth; }
        }

        public bool ValidateKey(string key) 
        {
            try
            {
                DESCryptoServiceProvider descrypt = new DESCryptoServiceProvider();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
            return false;
        }
        /// <summary>
        /// This returns the vendor ID in the authentication key
        /// The validateKey function must be called first
        /// </summary>
        /// <returns></returns>
        public int GetVendorID() 
        {
            return vendorid;
        }
    }
}
