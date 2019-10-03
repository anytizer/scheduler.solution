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

        // // SELECT TO_BASE64("http://localhost:99/project/inventory/api.php/src");
        private string _apiGateway = "aHR0cDovL2xvY2FsaG9zdDo5OS9wcm9qZWN0L2ludmVudG9yeS9hcGkucGhwL3NyYw==";
        public string APIGATEWAY
        {
            get
            {
                return encoder.decode(_apiGateway);
            }
            set
            {
            }
        }

        // @todo base64 encode values
        // SELECT TO_BASE64("/appointments/appointments/add");
        private string _bookAppointment = "L2FwcG9pbnRtZW50cy9hcHBvaW50bWVudHMvYWRk";
        public string BOOKAPPOINTMENT {
            get
            {
                return encoder.decode(_bookAppointment);
            }

            set { }
        }

    }
}
