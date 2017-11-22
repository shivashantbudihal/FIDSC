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
    public partial class Crawling : Form
    {
        public Crawling()
        {
            InitializeComponent();
        }

        public static Collection<string> seedList = new Collection<string>();
        public static bool applicationFlag = false;

        int l;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (applicationFlag) //this will execute only if it is called by refresh form 
            {
                IndexCreation.applicationFlag = true;
                startup.Text = string.Empty;
                for (int i = 0; i < seedList.Count; i++)
                {
                    startup.Text += seedList[i] + ", ";
                    waiting.Add(seedList[i]);
                }
                startup.ReadOnly = true;
                addWait.Enabled = false;
                clearWait.Enabled = false;
                clearBase_Click(sender, e);
            }

            refr.Text = "";
            resultsTableAdapter.Fill(this.searchbotDataSet.Results);
            total.Text = "Total records: " + resultsTableAdapter.Count();
        }

        private void Form1_Hide(object sender, EventArgs e)
        {
            applicationFlag = false;
        }

        private void Form1_Close(object sender, EventArgs e)
        {
            applicationFlag = false;
        }
        private void tableRefresh_Tick(object sender, EventArgs e)
        {
            l--;
            if (l == 0)
            {
                resultsTableAdapter.Fill(this.searchbotDataSet.Results);
                total.Text = "Total records: " + resultsTableAdapter.Count();
                l = 10;
            }
            refr.Text = "Table refresh in: " + l.ToString();
        }

        private void clearBase_Click(object sender, EventArgs e)
        {
            seedList.Clear();
            resultsTableAdapter.Clear();
            resultsTableAdapter.Fill(this.searchbotDataSet.Results);
            total.Text = "Total records: " + resultsTableAdapter.Count();
            Continue.Enabled = false;
        }

        private void search_Click(object sender, EventArgs e)
        {
            resultsTableAdapter.FillBySearch(this.searchbotDataSet.Results, "%" + query.Text + "%");
        }

        private void addWait_Click(object sender, EventArgs e)
        {       
            waiting.Add(startup.Text);
            seedList.Add(startup.Text.Substring(8));
        }

        private void clearWait_Click(object sender, EventArgs e)
        {
            seedList.Clear();
            waiting.Clear();
        }

        private void query_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                search_Click(sender, e);
        }

        private void startup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                addWait_Click(sender, e);
        }

        private void scan_cancel_Click(object sender, EventArgs e)
        {
            if (scan_cancel.Text == "Scan the web")
            {
                if (waiting.Count > 0)
                {
                    l = 10;
                    refr.Text = "Table refresh in: 10";
                    doscan = true;
                    clearBase.Enabled = false;
                    query.Enabled = false;
                    search.Enabled = false;
                    startup.Enabled = false;
                    addWait.Enabled = false;
                    clearWait.Enabled = false;
                    progress.Style = ProgressBarStyle.Marquee;
                    scan_cancel.Text = "Stop scanning";
                    tableRefresh.Start();
                    Continue.Enabled = true;
                    scanWorker.RunWorkerAsync();
                }
                else
                    MessageBox.Show("Waiting is empty - scanning must have a startup url. Type startup urls in the text box at the top of form and click the button 'Add to List'.");
            }
            else if (scan_cancel.Text == "Stop scanning")
            {
                refr.Text = "";
                tableRefresh.Stop();
                scan_cancel.Text = "Stopping...";
                scan_cancel.Enabled = false;
                doscan = false;
            }
        }

        private void scanWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tableRefresh.Stop();
            scan_cancel.Text = "Scan the web";
            clearBase.Enabled = true;
            query.Enabled = true;
            search.Enabled = true;
            scan_cancel.Enabled = true;
            startup.Enabled = true;
            addWait.Enabled = true;
            clearWait.Enabled = true;
            progress.Style = ProgressBarStyle.Blocks;
            resultsTableAdapter.Fill(this.searchbotDataSet.Results);
            total.Text = "Total records: " + resultsTableAdapter.Count();
        }

        private void scanWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Scan();
        }

        bool doscan; // Do scanning. If doscan is false then Scan function will exit
        Collection<string> waiting = new Collection<string>(); // Here sites wait for indexing
        Dictionary<string, RFX> robots = new Dictionary<string, RFX>(); // Parsed robots files

        /// <summary>
        /// Regular expression for getting and parsing meta tags.
        /// </summary>
        public Regex parseMeta = new Regex(@"<meta(?:\s+([a-zA-Z_\-]+)\s*\=\s*([a-zA-Z_\-]+|\" + '"' + @"[^\" + '"' + @"]*\" + '"' + @"))*\s*\/?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Regular expression for getting and parsing base tags.
        /// </summary>
        public Regex parseBase = new Regex(@"<base(?:\s+([a-zA-Z_\-]+)\s*\=\s*([a-zA-Z_\-]+|\" + '"' + @"[^\" + '"' + @"]*\" + '"' + @"))*\s*\/?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        /// <summary>
        /// Regular expression for getting and parsing A tags.
        /// </summary>
        public Regex parseA = new Regex(@"<a(?:\s+([a-zA-Z_\-]+)\s*\=\s*([a-zA-Z_\-]+|\" + '"' + @"[^\" + '"' + @"]*\" + '"' + @"))*\s*>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Regular expression for getting title of HTML document.
        /// </summary>
        public Regex parseTitle = new Regex(@"<title(?:\s+(?:[a-zA-Z_\-]+)\s*\=\s*(?:[a-zA-Z_\-]+|\" + '"' + @"[^\" + '"' + @"]*\" + '"' + @"))*\s*>([^<]*)</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Scans the web.
        /// </summary>
        void Scan()
        {
            while (waiting.Count > 0 && doscan)
            {
                try
                {
                    string url = waiting[0];
                    waiting.RemoveAt(0);
                    Uri _url = new Uri(url);
                    if (_url.Scheme.ToLower() == "http" || _url.Scheme.ToLower() == "https")
                    {
                        string bu = (_url.Scheme + "://" + _url.Host + ":" + _url.Port).ToLower();
                        url = bu + _url.AbsolutePath;
                        if (resultsTableAdapter2.CountOfUrls(url) == 0)
                        {
                            RFX rfx;
                            if (robots.ContainsKey(bu))
                            {
                                rfx = robots[bu];
                            }
                            else
                            {
                                rfx = new RFX(bu);
                                robots.Add(bu, rfx);
                            }

                            if (rfx.Allow(url))
                            {
                                if (!doscan)
                                    return;
                                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                                req.UserAgent = "Xearchbot/1.0 (+http://www.kmpp.neostrada.pl/xearch.htm)";
                                req.Headers["Accept-Encoding"] = "gzip";
                                req.Timeout = 20000;
                                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                                string ct = res.ContentType.ToLower();
                                int io = ct.IndexOf(";");
                                if (io != -1)
                                    ct = ct.Substring(0, io);
                                if (ct == "text/html" || ct == "application/xhtml+xml")
                                {
                                    Stream s;
                                    if (res.Headers["Content-Encoding"] != null)
                                    {
                                        if (res.Headers["Content-Encoding"].ToLower() == "gzip")
                                            s = new GZipStream(res.GetResponseStream(), CompressionMode.Decompress);
                                        else
                                            s = res.GetResponseStream();
                                    }
                                    else
                                        s = res.GetResponseStream();
                                    StreamReader sr = new StreamReader(s);
                                    string d = sr.ReadToEnd();
                                    sr.Close();

                                    string title = "";
                                    string keywords = "";
                                    string description = "";
                                    bool cIndex = true;
                                    bool cFollow = true;

                                    MatchCollection mc = parseMeta.Matches(d);
                                    foreach (Match m in mc)
                                    {
                                        CaptureCollection names = m.Groups[1].Captures;
                                        CaptureCollection values = m.Groups[2].Captures;
                                        if (names.Count == values.Count)
                                        {
                                            string mName = "";
                                            string mContent = "";
                                            for (int i = 0; i < names.Count; i++)
                                            {
                                                string name = names[i].Value.ToLower();
                                                string value = values[i].Value.Replace("\"", "");
                                                if (name == "name")
                                                    mName = value.ToLower();
                                                else if (name == "content")
                                                    mContent = value;
                                            }
                                            switch (mName)
                                            {
                                                case "robots":
                                                    mContent = mContent.ToLower();
                                                    if (mContent.Trim().ToLower().IndexOf("noindex") != -1)
                                                        cIndex = false;
                                                    else if (mContent.IndexOf("index") != -1)
                                                        cIndex = true;
                                                    if (mContent.IndexOf("nofollow") != -1)
                                                        cFollow = false;
                                                    else if (mContent.IndexOf("follow") != -1)
                                                        cFollow = true;
                                                    break;
                                                case "keywords":
                                                    keywords = mContent;
                                                    break;
                                                case "description":
                                                    description = mContent;
                                                    break;
                                            }
                                        }
                                    }
                                    if (cFollow)
                                    {
                                        mc = parseBase.Matches(d);
                                        Uri lastHref = _url;
                                        string d2 = d;
                                        if (mc.Count > 0)
                                            d2.Substring(0, mc[0].Index);
                                        follow(d2, _url);
                                        for (int j = 0; j < mc.Count; j++)
                                        {
                                            Match m = mc[j];
                                            CaptureCollection names = m.Groups[1].Captures;
                                            CaptureCollection values = m.Groups[2].Captures;
                                            if (names.Count == values.Count)
                                            {
                                                string href = "";
                                                for (int i = 0; i < names.Count; i++)
                                                {
                                                    string name = names[i].Value.ToLower();
                                                    string value = values[i].Value.Replace("\"", "");
                                                    if (name == "href")
                                                        href = value.ToLower();
                                                }
                                                d2 = d.Substring(m.Index);
                                                if (j < mc.Count - 1)
                                                    d2.Substring(0, mc[j + 1].Index);
                                                if (href != "")
                                                    lastHref = new Uri(href);
                                                follow(d2, lastHref);
                                            }
                                        }
                                    }
                                    if (cIndex)
                                    {
                                        mc = parseTitle.Matches(d);
                                        if (mc.Count > 0)
                                        {
                                            Match m = mc[mc.Count - 1];
                                            title = m.Groups[1].Captures[0].Value;
                                        }
                                        resultsTableAdapter2.InsertRow(url, title.Trim(), keywords.Trim(), description.Trim());
                                    }
                                }
                                res.Close();
                            }
                        }
                    }
                }
                catch { }
            }
        }
        void follow(string d, Uri abs)
        {
            MatchCollection mc = parseA.Matches(d);
            foreach (Match m in mc)
            {
                CaptureCollection names = m.Groups[1].Captures;
                CaptureCollection values = m.Groups[2].Captures;
                if (names.Count == values.Count)
                {
                    string href = "";
                    string rel = "";
                    for (int i = 0; i < names.Count; i++)
                    {
                        string name = names[i].Value.ToLower();
                        string value = values[i].Value.Replace("\"", "");
                        if (name == "href")
                            href = value;
                        else if (name == "rel")
                            rel = value;
                    }
                    if (rel.IndexOf("nofollow") == -1 && href != "")
                    {
                        Uri lurl = new Uri(abs, href);
                        waiting.Add(lurl.ToString());
                    }
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=fidsc;Uid=root;");
                MySqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "TRUNCATE results";
                cmd.ExecuteNonQuery();
                for (int i = 0; i < view.RowCount; i++)
                {
                    string url = view[0, i].Value.ToString().Replace("\"", string.Empty).Replace("'", string.Empty);
                    string title = view[1, i].Value.ToString().Replace("\"", string.Empty).Replace("'", string.Empty);
                    string keyword = view[2, i].Value.ToString().Replace("\"", string.Empty).Replace("'", string.Empty);
                    string description = view[3, i].Value.ToString().Replace("\"", string.Empty).Replace("'", string.Empty);
                    try
                    {
                        cmd.CommandText = "INSERT INTO results (url, title, keyword, description) values ('" + url + "','" + title + "','" + keyword + "','" + description + "')";
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException MYSqlExc) { }
                }
                con.Close();

                this.Hide();
                IndexCreation ic = new IndexCreation();
                ic.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void RefreshIndex_Click(object sender, EventArgs e)
        {
            this.Hide();
            RefreshIndex refreshindex = new RefreshIndex();
            refreshindex.Show();
        }
    }

    /// <summary>
    /// Robots.txt For Xearch.
    /// </summary>
    class RFX
    {
        Collection<string> disallow = new Collection<string>();
        string u, data;

        /// <summary>
        /// Parses robots.txt of site.
        /// </summary>
        /// <param name="url">Base url of site</param>
        public RFX(string url)
        {
            try
            {
                u = url;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(u + "/robots.txt");
                req.UserAgent = "Xearchbot/1.0 (+http://www.kmpp.neostrada.pl/xearch.htm)";
                req.Headers["Accept-Encoding"] = "gzip";
                req.Timeout = 20000;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream s;
                if (res.Headers["Content-Encoding"] != null)
                {
                    if (res.Headers["Content-Encoding"].ToLower() == "gzip")
                        s = new GZipStream(res.GetResponseStream(), CompressionMode.Decompress);
                    else
                        s = res.GetResponseStream();
                }
                else
                    s = res.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                data = sr.ReadToEnd();
                sr.Close();
                res.Close();
                if (!parseAgent("Xearchbot")) // If it's section for Xearchbot then don't parse section for all bots.
                    parseAgent("*");
            }
            catch { }
        }

        /// <summary>
        /// Parses agent in robots.txt.
        /// </summary>
        /// <param name="agent">Agent name</param>
        /// <returns>True if agent exists, false if don't exists.</returns>
        bool parseAgent(string agent)
        {
            int io = data.LastIndexOf("User-agent: " + agent); // Start of agent's section
            if (io > -1)
            {
                int start = io + 12 + agent.Length;
                int count = data.IndexOf("User-agent:", start); // End of agent's section
                if (count == -1)
                    count = data.Length - start; // Section for agent is last
                else
                    count -= start + 1;
                while ((io = data.IndexOf("Disallow: /", start, count)) >= 0) // Finding disallows
                {
                    count -= io + 10 - start;
                    start = io + 10;
                    string dis = data.Substring(io + 10);
                    io = dis.IndexOf("\n");
                    if (io > -1)
                        dis = dis.Substring(0, io).Replace("\r", "");
                    if (dis[dis.Length - 1] == '/')
                        dis = dis.Substring(0, dis.Length - 1); // Deleting "/" at the end of path.
                    disallow.Add(u + dis);
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Checks we can allow the path.
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns>True if yes, false if no.</returns>
        public bool Allow(string path)
        {
            foreach (string dis in disallow)
            {
                if (path.StartsWith(dis))
                    return false;
            }
            return true;
        }
    }
}