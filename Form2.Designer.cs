namespace Searchbot
{
    partial class IndexCreation
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
            this.StartSelection = new System.Windows.Forms.Button();
            this.AcceptIndex = new System.Windows.Forms.Button();
            this.RejectIndex = new System.Windows.Forms.Button();
            this.IndexGridView = new System.Windows.Forms.DataGridView();
            this.RefreshIndex = new System.Windows.Forms.Button();
            this.TotalDoc = new System.Windows.Forms.Label();
            this.RefreshCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IndexRefresh = new System.Windows.Forms.Timer(this.components);
            this.Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IndexGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartSelection
            // 
            this.StartSelection.Location = new System.Drawing.Point(872, 88);
            this.StartSelection.Name = "StartSelection";
            this.StartSelection.Size = new System.Drawing.Size(100, 23);
            this.StartSelection.TabIndex = 2;
            this.StartSelection.Text = "Start Selection";
            this.StartSelection.UseVisualStyleBackColor = true;
            this.StartSelection.Click += new System.EventHandler(this.StartSelection_Click);
            // 
            // AcceptIndex
            // 
            this.AcceptIndex.Location = new System.Drawing.Point(872, 134);
            this.AcceptIndex.Name = "AcceptIndex";
            this.AcceptIndex.Size = new System.Drawing.Size(100, 23);
            this.AcceptIndex.TabIndex = 3;
            this.AcceptIndex.Text = "Accept Index";
            this.AcceptIndex.UseVisualStyleBackColor = true;
            this.AcceptIndex.Click += new System.EventHandler(this.AcceptIndex_Click);
            // 
            // RejectIndex
            // 
            this.RejectIndex.Location = new System.Drawing.Point(872, 163);
            this.RejectIndex.Name = "RejectIndex";
            this.RejectIndex.Size = new System.Drawing.Size(100, 23);
            this.RejectIndex.TabIndex = 4;
            this.RejectIndex.Text = "Reject Index";
            this.RejectIndex.UseVisualStyleBackColor = true;
            this.RejectIndex.Click += new System.EventHandler(this.RejectIndex_Click);
            // 
            // IndexGridView
            // 
            this.IndexGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.IndexGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IndexGridView.Location = new System.Drawing.Point(15, 42);
            this.IndexGridView.Name = "IndexGridView";
            this.IndexGridView.ReadOnly = true;
            this.IndexGridView.Size = new System.Drawing.Size(838, 502);
            this.IndexGridView.TabIndex = 5;
            // 
            // RefreshIndex
            // 
            this.RefreshIndex.BackColor = System.Drawing.Color.DarkKhaki;
            this.RefreshIndex.Location = new System.Drawing.Point(872, 208);
            this.RefreshIndex.Name = "RefreshIndex";
            this.RefreshIndex.Size = new System.Drawing.Size(98, 23);
            this.RefreshIndex.TabIndex = 22;
            this.RefreshIndex.Text = "Refresh Index";
            this.RefreshIndex.UseVisualStyleBackColor = false;
            this.RefreshIndex.Click += new System.EventHandler(this.RefreshIndex_Click);
            // 
            // TotalDoc
            // 
            this.TotalDoc.AutoSize = true;
            this.TotalDoc.Location = new System.Drawing.Point(21, 12);
            this.TotalDoc.Name = "TotalDoc";
            this.TotalDoc.Size = new System.Drawing.Size(81, 13);
            this.TotalDoc.TabIndex = 24;
            this.TotalDoc.Text = "Total records: 0";
            // 
            // RefreshCounter
            // 
            this.RefreshCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshCounter.AutoSize = true;
            this.RefreshCounter.Location = new System.Drawing.Point(746, 12);
            this.RefreshCounter.Name = "RefreshCounter";
            this.RefreshCounter.Size = new System.Drawing.Size(98, 13);
            this.RefreshCounter.TabIndex = 23;
            this.RefreshCounter.Text = "Table refresh in: 10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Result Data";
            // 
            // IndexRefresh
            // 
            this.IndexRefresh.Interval = 1000;
            this.IndexRefresh.Tick += new System.EventHandler(this.IndexRefresh_Tick);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(872, 491);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(100, 23);
            this.Close.TabIndex = 27;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // IndexCreation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(995, 556);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TotalDoc);
            this.Controls.Add(this.RefreshCounter);
            this.Controls.Add(this.RefreshIndex);
            this.Controls.Add(this.IndexGridView);
            this.Controls.Add(this.RejectIndex);
            this.Controls.Add(this.AcceptIndex);
            this.Controls.Add(this.StartSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1011, 594);
            this.Name = "IndexCreation";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIDSC - Index Creation";
            this.Load += new System.EventHandler(this.IndexCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IndexGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSelection;
        private System.Windows.Forms.Button AcceptIndex;
        private System.Windows.Forms.Button RejectIndex;
        private System.Windows.Forms.DataGridView IndexGridView;
        private System.Windows.Forms.Button RefreshIndex;
        private System.Windows.Forms.Label TotalDoc;
        private System.Windows.Forms.Label RefreshCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer IndexRefresh;
        private System.Windows.Forms.Button Close;
    }
}