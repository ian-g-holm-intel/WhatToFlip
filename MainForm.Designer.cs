namespace WhatToFlip
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.statsGrid = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.exaltPriceLabel = new System.Windows.Forms.Label();
            this.exaltPrice = new System.Windows.Forms.TextBox();
            this.leagueNamesBox = new System.Windows.Forms.ComboBox();
            this.leagueLabel = new System.Windows.Forms.Label();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentLowestColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Low24hrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OneDayAgoAvgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwoDayAgoAvgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThreeDayAgoAvgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldLast24hColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketCapColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.statsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 60000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // statsGrid
            // 
            this.statsGrid.AllowUserToAddRows = false;
            this.statsGrid.AllowUserToDeleteRows = false;
            this.statsGrid.AllowUserToResizeColumns = false;
            this.statsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.statsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.statsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.CurrentLowestColumn,
            this.Low24hrColumn,
            this.OneDayAgoAvgColumn,
            this.TwoDayAgoAvgColumn,
            this.ThreeDayAgoAvgColumn,
            this.SoldLast24hColumn,
            this.MarketCapColumn,
            this.NoteColumn});
            this.statsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsGrid.Location = new System.Drawing.Point(0, 40);
            this.statsGrid.MultiSelect = false;
            this.statsGrid.Name = "statsGrid";
            this.statsGrid.RowHeadersVisible = false;
            this.statsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.statsGrid.Size = new System.Drawing.Size(1095, 840);
            this.statsGrid.TabIndex = 0;
            this.statsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.statsGrid_CellValueChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 9);
            this.progressBar.MarqueeAnimationSpeed = 20;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(204, 23);
            this.progressBar.TabIndex = 1;
            // 
            // exaltPriceLabel
            // 
            this.exaltPriceLabel.AutoSize = true;
            this.exaltPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exaltPriceLabel.Location = new System.Drawing.Point(224, 10);
            this.exaltPriceLabel.Name = "exaltPriceLabel";
            this.exaltPriceLabel.Size = new System.Drawing.Size(136, 20);
            this.exaltPriceLabel.TabIndex = 2;
            this.exaltPriceLabel.Text = "Chaos:Exalt Ratio";
            // 
            // exaltPrice
            // 
            this.exaltPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exaltPrice.Location = new System.Drawing.Point(366, 8);
            this.exaltPrice.Name = "exaltPrice";
            this.exaltPrice.Size = new System.Drawing.Size(76, 26);
            this.exaltPrice.TabIndex = 3;
            this.exaltPrice.Text = "Updating";
            this.exaltPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // leagueNamesBox
            // 
            this.leagueNamesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leagueNamesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leagueNamesBox.FormattingEnabled = true;
            this.leagueNamesBox.Items.AddRange(new object[] {
            "Prophecy"});
            this.leagueNamesBox.Location = new System.Drawing.Point(559, 6);
            this.leagueNamesBox.Name = "leagueNamesBox";
            this.leagueNamesBox.Size = new System.Drawing.Size(188, 28);
            this.leagueNamesBox.TabIndex = 4;
            this.leagueNamesBox.SelectedIndexChanged += new System.EventHandler(this.leagueNamesBox_SelectedIndexChanged);
            // 
            // leagueLabel
            // 
            this.leagueLabel.AutoSize = true;
            this.leagueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leagueLabel.Location = new System.Drawing.Point(490, 11);
            this.leagueLabel.Name = "leagueLabel";
            this.leagueLabel.Size = new System.Drawing.Size(63, 20);
            this.leagueLabel.TabIndex = 5;
            this.leagueLabel.Text = "League";
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 70;
            // 
            // CurrentLowestColumn
            // 
            this.CurrentLowestColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CurrentLowestColumn.DataPropertyName = "CurrentLow";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.CurrentLowestColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.CurrentLowestColumn.HeaderText = "Current Low";
            this.CurrentLowestColumn.Name = "CurrentLowestColumn";
            this.CurrentLowestColumn.ReadOnly = true;
            this.CurrentLowestColumn.Width = 109;
            // 
            // Low24hrColumn
            // 
            this.Low24hrColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Low24hrColumn.DataPropertyName = "Low24h";
            this.Low24hrColumn.HeaderText = "24hr Low";
            this.Low24hrColumn.Name = "Low24hrColumn";
            this.Low24hrColumn.ReadOnly = true;
            this.Low24hrColumn.Width = 91;
            // 
            // OneDayAgoAvgColumn
            // 
            this.OneDayAgoAvgColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OneDayAgoAvgColumn.DataPropertyName = "OneDayAgoAvgString";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.OneDayAgoAvgColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.OneDayAgoAvgColumn.HeaderText = "Avg 1d Ago";
            this.OneDayAgoAvgColumn.Name = "OneDayAgoAvgColumn";
            this.OneDayAgoAvgColumn.ReadOnly = true;
            this.OneDayAgoAvgColumn.Width = 106;
            // 
            // TwoDayAgoAvgColumn
            // 
            this.TwoDayAgoAvgColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TwoDayAgoAvgColumn.DataPropertyName = "TwoDayAgoAvgString";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.TwoDayAgoAvgColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.TwoDayAgoAvgColumn.HeaderText = "Avg 2d Ago";
            this.TwoDayAgoAvgColumn.Name = "TwoDayAgoAvgColumn";
            this.TwoDayAgoAvgColumn.ReadOnly = true;
            this.TwoDayAgoAvgColumn.Width = 106;
            // 
            // ThreeDayAgoAvgColumn
            // 
            this.ThreeDayAgoAvgColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ThreeDayAgoAvgColumn.DataPropertyName = "ThreeDayAgoAvgString";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.ThreeDayAgoAvgColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.ThreeDayAgoAvgColumn.HeaderText = "Avg 3d Ago";
            this.ThreeDayAgoAvgColumn.Name = "ThreeDayAgoAvgColumn";
            this.ThreeDayAgoAvgColumn.ReadOnly = true;
            this.ThreeDayAgoAvgColumn.Width = 106;
            // 
            // SoldLast24hColumn
            // 
            this.SoldLast24hColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoldLast24hColumn.DataPropertyName = "SoldLast24h";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.SoldLast24hColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.SoldLast24hColumn.HeaderText = "Sold last 24h";
            this.SoldLast24hColumn.Name = "SoldLast24hColumn";
            this.SoldLast24hColumn.ReadOnly = true;
            this.SoldLast24hColumn.Width = 115;
            // 
            // MarketCapColumn
            // 
            this.MarketCapColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MarketCapColumn.DataPropertyName = "MarketCap";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.MarketCapColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.MarketCapColumn.HeaderText = "MarketCap";
            this.MarketCapColumn.Name = "MarketCapColumn";
            this.MarketCapColumn.ReadOnly = true;
            this.MarketCapColumn.Width = 101;
            // 
            // NoteColumn
            // 
            this.NoteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NoteColumn.DataPropertyName = "Note";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.NoteColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.NoteColumn.HeaderText = "Note";
            this.NoteColumn.Name = "NoteColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 880);
            this.Controls.Add(this.leagueLabel);
            this.Controls.Add(this.leagueNamesBox);
            this.Controls.Add(this.exaltPrice);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statsGrid);
            this.Controls.Add(this.exaltPriceLabel);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhatToFlip";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.DataGridView statsGrid;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label exaltPriceLabel;
        private System.Windows.Forms.TextBox exaltPrice;
        private System.Windows.Forms.ComboBox leagueNamesBox;
        private System.Windows.Forms.Label leagueLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentLowestColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Low24hrColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OneDayAgoAvgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwoDayAgoAvgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThreeDayAgoAvgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldLast24hColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketCapColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteColumn;
    }
}

