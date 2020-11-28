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
            this.stylize();
            this.browse();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.browse();
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

            if(response.Content!="null" && response.Content != "\"null\"" && response.Content!= "\"[]\"" && response.Content!="{}" && response.Content!=null)
            {
                Appointment[] appointments = JsonConvert.DeserializeObject<Appointment[]>(response.Content);
                foreach (Appointment a in appointments)
                {
                    a.software_name = encoder.decode(a.software_name);
                    a.appointment_on = encoder.decode(a.appointment_on);
                    a.prospect_full_name = encoder.decode(a.prospect_full_name);
                    a.prospect_email = encoder.decode(a.prospect_email);
                }

                this.dataGridView1.DataSource = appointments;
                this.dataGridView1.Columns[0].Width = 240;
                this.dataGridView1.Columns[1].Width = 160;
                this.dataGridView1.Columns[2].Width = 160;
                this.dataGridView1.Columns[3].Width = 160;
                this.dataGridView1.Columns[4].Width = 160;
                this.dataGridView1.Columns[5].Width = 160;
            }
        }

        private void stylize()
        {
            this.dataGridView1.AllowDrop = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView1.AutoGenerateColumns = true; // change this
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = Color.Honeydew;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Salmon;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersDefaultCellStyle.Padding = new Padding(dataGridView1.RowHeadersWidth);
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 16;
            this.dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
