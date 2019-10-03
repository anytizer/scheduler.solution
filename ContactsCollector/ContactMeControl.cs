using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using Libraries;
using EncoderDecoder = Libraries.EncoderDecoder;

namespace ContactsCollector
{
    public partial class ContactMeControl : UserControl
    {
        private Configurations config = new Configurations();

        public ContactMeControl()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(config.HELPURL);
        }

        private void ContactMeControl_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(21);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/6312970/restsharp-json-parameter-posting

            // send contact info to the API

            EncoderDecoder encoder = new EncoderDecoder();
            
            string booking_endpoint_resource = config.BOOKAPPOINTMENT;

            RestClient client = new RestClient(config.APIGATEWAY);
            RestRequest request = new RestRequest(booking_endpoint_resource, Method.POST);
            //request.RequestFormat = DataFormat.Json;
            request.AddParameter("software_name", encoder.encode(textBox1.Text));
            request.AddParameter("appointment_on", encoder.encode(dateTimePicker1.Value.ToString()));
            request.AddParameter("prospect_full_name", encoder.encode(textBox2.Text));
            request.AddParameter("prospect_email", encoder.encode(textBox3.Text));
            request.AddHeader("Accept", "application/json"); // important
            request.AddHeader("X-Protection-Token", "");

            IRestResponse response = client.Execute(request);

            // https://www.newtonsoft.com/json/help/html/DeserializeObject.htm
            SuccessResponse success = JsonConvert.DeserializeObject<SuccessResponse>(response.Content);
            if(success.success == true)
            {
                button1.Enabled = false;
                MessageBox.Show("Thanks!\r\nTo book another appointment, please restart the software.");
            }
            else
            {
                MessageBox.Show("We could not schedule.");
            }
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(config.LEGALURL);
        }
    }
}
