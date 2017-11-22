using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Searchbot
{
    public partial class RefreshIndex : Form
    {
        public RefreshIndex()
        {
            InitializeComponent();
        }

        String ConnectionString = "Server=localhost;Database=fidsc;Uid=root;";
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable datatable;

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Crawling crawling = new Crawling();
            crawling.Show();
        }

        private void StartRefresh_Click(object sender, EventArgs e)
        {

        }

        private void RefreshIndex_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection(ConnectionString);
                con.Open();
                DateTime refreshPeriod = DateTime.Today.AddDays(0);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM seed where LastRefreshDate >= '" + DateTime.Today.ToString() + "'", con);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "seed");
                SeedUrlGrid.DataSource = dataset.Tables["seed"];
                con.Close();

                int i = 1;
                for (i = 1; i < SeedUrlGrid.Rows.Count; i++)
                {
                    FromSeedList.Items.Add(i);
                    ToSeedList.Items.Add(i);
                }
                FromSeedList.Text = "1";
                ToSeedList.Text = (i-1).ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void StartRefresh_Click_1(object sender, EventArgs e)
        {
            for (int i = int.Parse(FromSeedList.Text)-1; i < int.Parse(ToSeedList.Text); i++)
            {
                //MessageBox.Show("https://"+SeedUrlGrid.Rows[i].Cells[0].Value.ToString());
                Crawling.seedList.Add("https://"+SeedUrlGrid.Rows[i].Cells[0].Value.ToString());
            }            
            
            Crawling.applicationFlag = true;
            Crawling crawlingObj = new Crawling();
            this.Hide();
            crawlingObj.Show();
        }

        private void FromSeedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToSeedList.Items.Clear();
            for (int i = int.Parse(FromSeedList.Text); i < SeedUrlGrid.Rows.Count; i++)
            {
                ToSeedList.Items.Add(i);
            }
        }
    }
}
