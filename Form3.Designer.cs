namespace Searchbot
{
    partial class RefreshIndex
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
            this.SeedUrlGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Home = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ToSeedList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FromSeedList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StartRefresh = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeedUrlGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SeedUrlGrid
            // 
            this.SeedUrlGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SeedUrlGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SeedUrlGrid.Location = new System.Drawing.Point(12, 24);
            this.SeedUrlGrid.Name = "SeedUrlGrid";
            this.SeedUrlGrid.Size = new System.Drawing.Size(977, 456);
            this.SeedUrlGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL Available to refresh";
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(881, 509);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(75, 23);
            this.Home.TabIndex = 9;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ToSeedList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FromSeedList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.StartRefresh);
            this.groupBox1.Location = new System.Drawing.Point(21, 496);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 47);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Url Range to ReIndex";
            // 
            // ToSeedList
            // 
            this.ToSeedList.FormattingEnabled = true;
            this.ToSeedList.Location = new System.Drawing.Point(251, 16);
            this.ToSeedList.Name = "ToSeedList";
            this.ToSeedList.Size = new System.Drawing.Size(121, 21);
            this.ToSeedList.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "To";
            // 
            // FromSeedList
            // 
            this.FromSeedList.FormattingEnabled = true;
            this.FromSeedList.Location = new System.Drawing.Point(80, 16);
            this.FromSeedList.Name = "FromSeedList";
            this.FromSeedList.Size = new System.Drawing.Size(121, 21);
            this.FromSeedList.TabIndex = 16;
            this.FromSeedList.SelectedIndexChanged += new System.EventHandler(this.FromSeedList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "From";
            // 
            // StartRefresh
            // 
            this.StartRefresh.Location = new System.Drawing.Point(464, 16);
            this.StartRefresh.Name = "StartRefresh";
            this.StartRefresh.Size = new System.Drawing.Size(79, 23);
            this.StartRefresh.TabIndex = 14;
            this.StartRefresh.Text = "Start Refresh";
            this.StartRefresh.UseVisualStyleBackColor = true;
            this.StartRefresh.Click += new System.EventHandler(this.StartRefresh_Click_1);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(786, 510);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 15;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // RefreshIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1001, 562);
            this.Controls.Add(this.close);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SeedUrlGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1011, 594);
            this.Name = "RefreshIndex";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIDSC - Refresh Index";
            this.Load += new System.EventHandler(this.RefreshIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeedUrlGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SeedUrlGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ToSeedList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FromSeedList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartRefresh;
        private System.Windows.Forms.Button close;
    }
}