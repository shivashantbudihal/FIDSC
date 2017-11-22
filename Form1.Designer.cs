namespace Searchbot
{
    partial class Crawling
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startup = new System.Windows.Forms.TextBox();
            this.scan_cancel = new System.Windows.Forms.Button();
            this.view = new System.Windows.Forms.DataGridView();
            this.urlresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keywordsresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchbotDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchbotDataSet = new Searchbot.SearchbotDataSet();
            this.resultsTableAdapter = new Searchbot.SearchbotDataSetTableAdapters.ResultsTableAdapter();
            this.query = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.clearBase = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.scanWorker = new System.ComponentModel.BackgroundWorker();
            this.tableRefresh = new System.Windows.Forms.Timer(this.components);
            this.resultsTableAdapter2 = new Searchbot.SearchbotDataSetTableAdapters.ResultsTableAdapter();
            this.refr = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.addWait = new System.Windows.Forms.Button();
            this.clearWait = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.Continue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshIndex = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchbotDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchbotDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // startup
            // 
            this.startup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startup.Location = new System.Drawing.Point(86, 36);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(737, 20);
            this.startup.TabIndex = 1;
            this.startup.Text = "https://[server].[domain]/";
            this.startup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startup_KeyUp);
            // 
            // scan_cancel
            // 
            this.scan_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scan_cancel.Location = new System.Drawing.Point(882, 167);
            this.scan_cancel.Name = "scan_cancel";
            this.scan_cancel.Size = new System.Drawing.Size(98, 23);
            this.scan_cancel.TabIndex = 3;
            this.scan_cancel.Text = "Scan the web";
            this.scan_cancel.UseVisualStyleBackColor = true;
            this.scan_cancel.Click += new System.EventHandler(this.scan_cancel_Click);
            // 
            // view
            // 
            this.view.AllowUserToAddRows = false;
            this.view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.view.AutoGenerateColumns = false;
            this.view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.urlresultDataGridViewTextBoxColumn,
            this.keywordsresultDataGridViewTextBoxColumn,
            this.titleresultDataGridViewTextBoxColumn,
            this.descriptionresultDataGridViewTextBoxColumn});
            this.view.DataSource = this.resultsBindingSource;
            this.view.Location = new System.Drawing.Point(15, 100);
            this.view.Name = "view";
            this.view.ReadOnly = true;
            this.view.Size = new System.Drawing.Size(846, 421);
            this.view.TabIndex = 6;
            // 
            // urlresultDataGridViewTextBoxColumn
            // 
            this.urlresultDataGridViewTextBoxColumn.DataPropertyName = "url_result";
            this.urlresultDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlresultDataGridViewTextBoxColumn.Name = "urlresultDataGridViewTextBoxColumn";
            this.urlresultDataGridViewTextBoxColumn.ReadOnly = true;
            this.urlresultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.urlresultDataGridViewTextBoxColumn.Width = 200;
            // 
            // keywordsresultDataGridViewTextBoxColumn
            // 
            this.keywordsresultDataGridViewTextBoxColumn.DataPropertyName = "keywords_result";
            this.keywordsresultDataGridViewTextBoxColumn.HeaderText = "Keywords";
            this.keywordsresultDataGridViewTextBoxColumn.Name = "keywordsresultDataGridViewTextBoxColumn";
            this.keywordsresultDataGridViewTextBoxColumn.ReadOnly = true;
            this.keywordsresultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.keywordsresultDataGridViewTextBoxColumn.Width = 200;
            // 
            // titleresultDataGridViewTextBoxColumn
            // 
            this.titleresultDataGridViewTextBoxColumn.DataPropertyName = "title_result";
            this.titleresultDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleresultDataGridViewTextBoxColumn.Name = "titleresultDataGridViewTextBoxColumn";
            this.titleresultDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleresultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.titleresultDataGridViewTextBoxColumn.Width = 200;
            // 
            // descriptionresultDataGridViewTextBoxColumn
            // 
            this.descriptionresultDataGridViewTextBoxColumn.DataPropertyName = "description_result";
            this.descriptionresultDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionresultDataGridViewTextBoxColumn.Name = "descriptionresultDataGridViewTextBoxColumn";
            this.descriptionresultDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionresultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.descriptionresultDataGridViewTextBoxColumn.Width = 200;
            // 
            // resultsBindingSource
            // 
            this.resultsBindingSource.DataMember = "Results";
            this.resultsBindingSource.DataSource = this.searchbotDataSetBindingSource;
            // 
            // searchbotDataSetBindingSource
            // 
            this.searchbotDataSetBindingSource.DataSource = this.searchbotDataSet;
            this.searchbotDataSetBindingSource.Position = 0;
            // 
            // searchbotDataSet
            // 
            this.searchbotDataSet.DataSetName = "SearchbotDataSet";
            this.searchbotDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resultsTableAdapter
            // 
            this.resultsTableAdapter.ClearBeforeFill = true;
            // 
            // query
            // 
            this.query.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.query.Location = new System.Drawing.Point(867, 505);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(41, 20);
            this.query.TabIndex = 7;
            this.query.Visible = false;
            this.query.KeyUp += new System.Windows.Forms.KeyEventHandler(this.query_KeyUp);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Location = new System.Drawing.Point(914, 503);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 8;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Visible = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // clearBase
            // 
            this.clearBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBase.Location = new System.Drawing.Point(882, 196);
            this.clearBase.Name = "clearBase";
            this.clearBase.Size = new System.Drawing.Size(98, 23);
            this.clearBase.TabIndex = 10;
            this.clearBase.Text = "Clear database";
            this.clearBase.UseVisualStyleBackColor = true;
            this.clearBase.Click += new System.EventHandler(this.clearBase_Click);
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progress.Location = new System.Drawing.Point(0, 539);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(1001, 23);
            this.progress.TabIndex = 11;
            // 
            // scanWorker
            // 
            this.scanWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.scanWorker_DoWork);
            this.scanWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.scanWorker_RunWorkerCompleted);
            // 
            // tableRefresh
            // 
            this.tableRefresh.Interval = 1000;
            this.tableRefresh.Tick += new System.EventHandler(this.tableRefresh_Tick);
            // 
            // resultsTableAdapter2
            // 
            this.resultsTableAdapter2.ClearBeforeFill = true;
            // 
            // refr
            // 
            this.refr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refr.AutoSize = true;
            this.refr.Location = new System.Drawing.Point(747, 84);
            this.refr.Name = "refr";
            this.refr.Size = new System.Drawing.Size(98, 13);
            this.refr.TabIndex = 12;
            this.refr.Text = "Table refresh in: 10";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(22, 84);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(81, 13);
            this.total.TabIndex = 13;
            this.total.Text = "Total records: 0";
            // 
            // addWait
            // 
            this.addWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addWait.Location = new System.Drawing.Point(850, 22);
            this.addWait.Name = "addWait";
            this.addWait.Size = new System.Drawing.Size(119, 23);
            this.addWait.TabIndex = 14;
            this.addWait.Text = "Add to List";
            this.addWait.UseVisualStyleBackColor = true;
            this.addWait.Click += new System.EventHandler(this.addWait_Click);
            // 
            // clearWait
            // 
            this.clearWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearWait.Location = new System.Drawing.Point(850, 51);
            this.clearWait.Name = "clearWait";
            this.clearWait.Size = new System.Drawing.Size(119, 23);
            this.clearWait.TabIndex = 16;
            this.clearWait.Text = "Clear the List";
            this.clearWait.UseVisualStyleBackColor = true;
            this.clearWait.Click += new System.EventHandler(this.clearWait_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Result Data";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(882, 294);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(98, 23);
            this.Close.TabIndex = 18;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Continue
            // 
            this.Continue.Enabled = false;
            this.Continue.Location = new System.Drawing.Point(882, 323);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(98, 23);
            this.Continue.TabIndex = 19;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Seed URL";
            // 
            // RefreshIndex
            // 
            this.RefreshIndex.BackColor = System.Drawing.Color.DarkKhaki;
            this.RefreshIndex.Location = new System.Drawing.Point(882, 418);
            this.RefreshIndex.Name = "RefreshIndex";
            this.RefreshIndex.Size = new System.Drawing.Size(98, 23);
            this.RefreshIndex.TabIndex = 21;
            this.RefreshIndex.Text = "Refresh Index";
            this.RefreshIndex.UseVisualStyleBackColor = false;
            this.RefreshIndex.Click += new System.EventHandler(this.RefreshIndex_Click);
            // 
            // Crawling
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1001, 562);
            this.Controls.Add(this.RefreshIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearWait);
            this.Controls.Add(this.addWait);
            this.Controls.Add(this.total);
            this.Controls.Add(this.refr);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.clearBase);
            this.Controls.Add(this.search);
            this.Controls.Add(this.query);
            this.Controls.Add(this.view);
            this.Controls.Add(this.scan_cancel);
            this.Controls.Add(this.startup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1011, 594);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Crawling";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIDSC - Crawling";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchbotDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchbotDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scan_cancel;
        private System.Windows.Forms.DataGridView view;
        private System.Windows.Forms.BindingSource searchbotDataSetBindingSource;
        private SearchbotDataSet searchbotDataSet;
        private System.Windows.Forms.BindingSource resultsBindingSource;
        private SearchbotDataSetTableAdapters.ResultsTableAdapter resultsTableAdapter;
        private System.Windows.Forms.TextBox query;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button clearBase;
        private System.Windows.Forms.ProgressBar progress;
        private System.ComponentModel.BackgroundWorker scanWorker;
        private System.Windows.Forms.Timer tableRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlresultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keywordsresultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleresultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionresultDataGridViewTextBoxColumn;
        private SearchbotDataSetTableAdapters.ResultsTableAdapter resultsTableAdapter2;
        private System.Windows.Forms.Label refr;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Button addWait;
        private System.Windows.Forms.Button clearWait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefreshIndex;
        public System.Windows.Forms.TextBox startup;
    }
}

