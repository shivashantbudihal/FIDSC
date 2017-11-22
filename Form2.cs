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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.SqlServerCe;
using System.Collections;

namespace Searchbot
{
    public partial class IndexCreation : Form
    {
        Crawling crawlingObj = new Crawling();        

        public IndexCreation()
        {
            InitializeComponent();
        }

        public static bool applicationFlag = false;

        private void RefreshIndex_Click(object sender, EventArgs e)
        {
            this.Hide();
            RefreshIndex refreshindex = new RefreshIndex();
            refreshindex.Show();
        }

        String ConnectionString = "Server=localhost;Database=fidsc;Uid=root;";
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable datatable;
    
        private void IndexCreation_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection(ConnectionString);
                getSearchWord();
                ListURLsDetails();
                datatable = new DataTable();
                DataColumn dcurl = new DataColumn("URL");
                DataColumn dckey = new DataColumn("KEYWORD");
                DataColumn dctit = new DataColumn("TITLE");
                DataColumn dcdesc = new DataColumn("DESCRIPTION");
                DataColumn dcrank = new DataColumn("WORDRANK");
                datatable.Columns.Add(dcurl);
                datatable.Columns.Add(dckey);
                datatable.Columns.Add(dctit);
                datatable.Columns.Add(dcdesc);
                datatable.Columns.Add(dcrank);
                DataRow dr1 = datatable.NewRow();
                IndexGridView.DataSource = datatable;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Form1_Hide(object sender, EventArgs e)
        {
            applicationFlag = false;
        }

        private void Form1_Close(object sender, EventArgs e)
        {
            applicationFlag = false;
        }

        private void IndexCreation_Hide(object sender, EventArgs e)
        {
        }

        int l = 10;
        private void IndexRefresh_Tick(object sender, EventArgs e)
        {
            l--;
            if (l == 0)
            {
                IndexGridView.DataSource = datatable;
                l = 10;
            }
            RefreshCounter.Text = "Table refresh in: " + l.ToString();
        }
        
        List<string> searchword = new List<string>();

        private void getSearchWord()
        {
            try
            {
                con.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM keyword", con);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "keyword");
                foreach (DataRow word in dataset.Tables[0].Rows)
                {
                    searchword.Add(word[0].ToString());
                }
                con.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public List<string> url = new List<string>();
        public List<string> keyword = new List<string>();
        public List<string> title = new List<string>();
        public List<string> description = new List<string>();

        private void ListURLsDetails()
        {
            try
            {
                con.Open();
                MySqlDataAdapter crawladapter = new MySqlDataAdapter("SELECT * FROM results", con);
                DataSet crawlset = new DataSet();
                crawladapter.Fill(crawlset, "results");
                foreach (DataRow data in crawlset.Tables[0].Rows)
                {
                    url.Add(data[0].ToString());
                    keyword.Add(data[2].ToString());
                    title.Add(data[1].ToString());
                    description.Add(data[3].ToString());
                }
                con.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        Dictionary<int, int> pagerank = new Dictionary<int,int>();
        private void SelectUrls()
        {
            try
            {
                var urlkey = new List<KeyValuePair<int, String>>();
                foreach (string key in keyword)
                {
                    int urlindex = keyword.IndexOf(key);
                    var keyarray = key.Split(',');
                    foreach (string text in keyarray)
                    {
                        var subtext = text.Split(' ');
                        foreach (string word in subtext)
                        {
                            int result = searchword.IndexOf(word.ToLower());
                            if (result > 0)
                            {
                                urlkey.Add(new KeyValuePair<int, String>(urlindex, word.ToLower()));
                            }
                        }
                    }
                }
                foreach (string tit in title)
                {
                    datatable.Clear();
                    int urlindex = title.IndexOf(tit);
                    var titarray = tit.Split(' ');
                    foreach (string text in titarray)
                    {

                        int result = searchword.IndexOf(text.ToLower());
                        if (result > 0)
                        {
                            urlkey.Add(new KeyValuePair<int, String>(urlindex, text.ToLower()));
                        }
                    }
                }
                foreach (string desc in description)
                {
                    int urlindex = description.IndexOf(desc);
                    var descarray = desc.Split(' ');
                    foreach (string text in descarray)
                    {
                        int result = searchword.IndexOf(text.ToLower());
                        if (result > 0)
                        {
                            urlkey.Add(new KeyValuePair<int, String>(urlindex, text.ToLower()));
                        }
                    }
                }
                var lookup = urlkey.ToLookup(kvp => kvp.Key, kvp => kvp.Value);
                for (int i = 0; i < url.Count; i++)
                {
                    Dictionary<string, int> wordcnt = new Dictionary<string, int>();
                    foreach (var word in lookup[i])
                    {
                        if (wordcnt.ContainsKey(word))
                        {
                            int cnt = (int)wordcnt[word];
                            wordcnt[word] = cnt + 1;
                        }
                        else
                        {
                            wordcnt.Add(word, 1);
                        }

                    }
                    int doc = 0;
                    foreach (string key in wordcnt.Keys)
                    {
                        DataRow row = datatable.NewRow();
                        row[0] = url[i];
                        row[1] = key;
                        row[2] = title[i];
                        row[3] = description[i];
                        row[4] = (double)wordcnt[key] / wordcnt.Count;
                        datatable.Rows.Add(row);
                        doc++;
                    }
                    pagerank.Add(i, wordcnt.Count);
                }
                StartSelection.Text = "Start Selection";
                IndexRefresh.Stop();            
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void StartSelection_Click(object sender, EventArgs e)
        {
            if (StartSelection.Text == "Start Selection")
            {                
                StartSelection.Text = "Stop Selection";
                IndexRefresh.Start();
                SelectUrls();
            }
            else if (StartSelection.Text == "Stop Selection")
            {
                StartSelection.Text = "Stopping...";
                IndexRefresh.Stop();
                StartSelection.Text = "Start Selection";                
            }
            TotalDoc.Text = IndexGridView.Rows.Count.ToString();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void RejectIndex_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                for (int i = 0; i < Crawling.seedList.Count - 1; i++)
                {
                    cmd.CommandText = "UPDATE seed set LastRefreshDate = '" + DateTime.Today.ToString() + "', Consider = " + false + " where SeedUrl = '" + Crawling.seedList[i] + "'";
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                datatable.Clear();
            }
            catch (Exception exc)
            {
                con.Close();
                MessageBox.Show(exc.Message);
            }
        }

        private void AcceptIndex_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                for(int i = 0; i< Crawling.seedList.Count-1; i++)
                {
                    cmd.CommandText = "UPDATE seed set LastRefreshDate = '" + DateTime.Today.ToString() + "', Consider = " + true + " where SeedUrl = '" + Crawling.seedList[i] + "'";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                int cnt = 0;
                if (applicationFlag)
                {
                    foreach (DataRow r in datatable.Rows)
                    {
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE webpage set WordRank= " + r[4] + " where UrlId = '" + r[0] + "' and Keyword = '" + r[1] + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Index Table is updated for the selected servers.");
                }
                else
                {
                    foreach (DataRow r in datatable.Rows)
                    {
                        bool flag = true;
                        con.Open();
                        MySqlCommand testcmd = new MySqlCommand("select * from webpage where UrlId = '" + r[0] + "'and Keyword = '" + r[1] + "'and Title = '" + r[2] + "'and Description = '" + r[3] + "'and WordRank = " + r[4] + "", con);
                        MySqlDataReader data = testcmd.ExecuteReader();
                        if (data.Read())
                        {
                            flag = false;
                            con.Close();
                        }
                        else
                        {
                            if (flag)
                            {
                                con.Close();
                                con.Open();
                            }
                            cmd = con.CreateCommand();
                            cmd.CommandText = "INSERT INTO webpage VALUES('" + r[0] + "','" + r[1] + "','" + r[2] + "','" + r[3] + "'," + r[4] + ")";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cnt++;
                        }
                    }
                    if (cnt > 0)
                        MessageBox.Show("Documents successfully indexed");
                    else
                        MessageBox.Show("Document already Indexed.\nYou can only refresh it but cannot be indexed again.");
                }
                foreach (int key in pagerank.Keys)
                {
                    bool flag = true;
                    con.Open();                    
                    MySqlCommand testcmd = new MySqlCommand("select * from refresh where DocUrl = '"+url[key]+"'", con);
                    MySqlDataReader data = testcmd.ExecuteReader();                    
                    if (data.Read())
                    {
                        flag = false;
                        con.Close();
                    }
                    else
                    {
                        if (flag)
                        {
                            con.Close();
                            con.Open();
                        }
                        cmd = con.CreateCommand();
                        double rank = (double)pagerank[key]/url.Count;                        
                        cmd.CommandText = "INSERT INTO refresh VALUES('" + url[key] + "','" + DateTime.Today.Date +"'," + rank + ")";
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
            }
            catch (Exception exc)
            {
                con.Close();
                MessageBox.Show(exc.Message);
            }
        }
    }
}
