using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace UV_DLP_3D_Printer
{
    public enum eVendorIDs 
    {
        eDefault                = 0, // no vendor - Default License
        ePro                    = 1, // pro license
        eALT3                   = 2, // Alt3 technologies
        eStalagtite3D_SPOTA     = 3  
    }
    public class AuthenticationManager
    {
        private bool auth;
        private eVendorIDs vendorid;
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
            vendorid = eVendorIDs.eDefault; // no vendor
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
        public eVendorIDs GetVendorID() 
        {
            return vendorid;
        }
    }
}
