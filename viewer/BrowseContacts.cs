using libraries;
using Libraries;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace viewer
{
    public partial class BrowseContacts : Form
    {
        public BrowseContacts()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stylize();
            browse();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browse();
        }

        public void browse()
        {
            // send contact info to the API
            Configurations config = new Configurations();
            EncoderDecoder encoder = new EncoderDecoder();

            string bookinglists_endpoint = config.LISTAPPOINTMENTS;

            RestClient client = new RestClient(config.APIGATEWAY);
            RestRequest request = new RestRequest(bookinglists_endpoint, Method.POST);
            request.AddHeader("Accept", "application/json"); // important
            request.AddHeader("X-Protection-Token", "");

            IRestResponse response = client.Execute(request);

            if(response.Content!="null" && response.Content != "\"null\"" && response.Content!= "\"[]\"" && response.Content!=null)
            {
                Appointment[] appointments = JsonConvert.DeserializeObject<Appointment[]>(response.Content);
                foreach (Appointment a in appointments)
                {
                    a.software_name = encoder.decode(a.software_name);
                    a.appointment_on = encoder.decode(a.appointment_on);
                    a.prospect_full_name = encoder.decode(a.prospect_full_name);
                    a.prospect_email = encoder.decode(a.prospect_email);
                }

                dataGridView1.DataSource = appointments;
                dataGridView1.Columns[0].Width = 240;
                dataGridView1.Columns[1].Width = 160;
                dataGridView1.Columns[2].Width = 160;
                dataGridView1.Columns[3].Width = 160;
                dataGridView1.Columns[4].Width = 160;
                dataGridView1.Columns[5].Width = 160;
            }
        }

        private void stylize()
        {
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.AutoGenerateColumns = true; // change this
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.Honeydew;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Salmon;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersDefaultCellStyle.Padding = new Padding(dataGridView1.RowHeadersWidth);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 16;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
