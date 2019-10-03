using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCollector
{
    class Configurations
    {
        private Encoder encoder = new Encoder();

        // SELECT TO_BASE64("http://help.example.com/");
        private string _helpURL = "aHR0cDovL2hlbHAuZXhhbXBsZS5jb20v";
        public string HELPURL
        {
            get
            {
                return encoder.decode(_helpURL);
            }
            set
            {
            }
        }

        // SELECT TO_BASE64("http://legal.example.com/");
        private string _legalURL = "aHR0cDovL2xlZ2FsLmV4YW1wbGUuY29tLw==";
        public string LEGALURL
        {
            get
            {
                return encoder.decode(_legalURL);
            }
            set
            {
            }
        }

        // SELECT TO_BASE64("http://api.example.com/");
        private string _apiServer = "aHR0cDovL2FwaS5leGFtcGxlLmNvbS8=";
        public string APISERVER
        {
            get
            {
                return encoder.decode(_apiServer);
            }
            set
            {
            }
        }

       
    }
}
