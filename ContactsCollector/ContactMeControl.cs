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

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Encoder encoder = new Encoder();
            Endpoints endpoints = new Endpoints();


            // https://stackoverflow.com/questions/6312970/restsharp-json-parameter-posting

            // send contact info to the API
            RestClient client = new RestClient("http://localhost:99/project/inventory/api.php/src"); //  config.APISERVER);
            RestRequest request = new RestRequest(endpoints.bookAppointment, Method.POST);
            //request.RequestFormat = DataFormat.Json;
            request.AddParameter("software_name", encoder.encode(textBox1.Text));
            request.AddParameter("appointment_on", encoder.encode(dateTimePicker1.Value.ToString()));
            request.AddParameter("prospect_full_name", encoder.encode(textBox2.Text));
            request.AddParameter("prospect_email", encoder.encode(textBox3.Text));
            request.AddHeader("Accept", "application/json"); // important
            request.AddHeader("X-Protection-Token", "");
            IRestResponse response = client.Execute(request);
            //RestResponse<SuccessResponse> response2 = client.Execute<SuccessResponse>(request);

            MessageBox.Show("Thanks...\r\n" + response.Content);
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(config.LEGALURL);
        }
    }
}
