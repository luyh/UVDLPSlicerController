using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;

namespace UV_DLP_3D_Printer
{
    /// <summary>
    /// This class will attempt to phone home to the server to check for updates
    /// and relay licensing information
    /// it will be run once at application startup
    /// </summary>
    public class ServerContact
    {
        private Thread m_thread; // this will be user
        public ServerContact() 
        {
            ContactServer();// this will kick off contacting the server
        }
        public void ContactServer() 
        {
            m_thread = new Thread(new ThreadStart(ContactServerThread));
            m_thread.Start();
            //try an http post            
        }
        // generate the name/value pairs to send to the server
        private void GenerateInfo() 
        {
        
        }
        private void ContactServerThread() 
        {
            // try the HTTP Post
            try
            {
                GenerateInfo();
            }
            catch (Exception) 
            {
                // may want to silently fail here
            }
        }
    }
}
