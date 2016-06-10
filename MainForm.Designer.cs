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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.statsGrid = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnePercentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwoPercentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FivePercentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldLastDayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketCapColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpacerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.exaltPriceLabel = new System.Windows.Forms.Label();
            this.exaltPrice = new System.Windows.Forms.TextBox();
            this.leagueNamesBox = new System.Windows.Forms.ComboBox();
            this.leagueLabel = new System.Windows.Forms.Label();
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.statsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.statsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.MinPriceColumn,
            this.OnePercentPriceColumn,
            this.TwoPercentPriceColumn,
            this.FivePercentPriceColumn,
            this.SoldLastDayColumn,
            this.MarketCapColumn,
            this.SpacerColumn});
            this.statsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsGrid.Location = new System.Drawing.Point(0, 40);
            this.statsGrid.Name = "statsGrid";
            this.statsGrid.ReadOnly = true;
            this.statsGrid.RowHeadersVisible = false;
            this.statsGrid.Size = new System.Drawing.Size(1095, 840);
            this.statsGrid.TabIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameColumn.DataPropertyName = "Name";
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 70;
            // 
            // MinPriceColumn
            // 
            this.MinPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MinPriceColumn.DataPropertyName = "MinPrice";
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.MinPriceColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.MinPriceColumn.HeaderText = "MinPrice (chaos)";
            this.MinPriceColumn.Name = "MinPriceColumn";
            this.MinPriceColumn.ReadOnly = true;
            this.MinPriceColumn.Width = 139;
            // 
            // OnePercentPriceColumn
            // 
            this.OnePercentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OnePercentPriceColumn.DataPropertyName = "OnePercentPrice";
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.OnePercentPriceColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.OnePercentPriceColumn.HeaderText = "1% Price";
            this.OnePercentPriceColumn.Name = "OnePercentPriceColumn";
            this.OnePercentPriceColumn.ReadOnly = true;
            this.OnePercentPriceColumn.Width = 89;
            // 
            // TwoPercentPriceColumn
            // 
            this.TwoPercentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TwoPercentPriceColumn.DataPropertyName = "TwoPercentPrice";
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.TwoPercentPriceColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.TwoPercentPriceColumn.HeaderText = "2% Price";
            this.TwoPercentPriceColumn.Name = "TwoPercentPriceColumn";
            this.TwoPercentPriceColumn.ReadOnly = true;
            this.TwoPercentPriceColumn.Width = 89;
            // 
            // FivePercentPriceColumn
            // 
            this.FivePercentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FivePercentPriceColumn.DataPropertyName = "FivePercentPrice";
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.FivePercentPriceColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.FivePercentPriceColumn.HeaderText = "5% Price";
            this.FivePercentPriceColumn.Name = "FivePercentPriceColumn";
            this.FivePercentPriceColumn.ReadOnly = true;
            this.FivePercentPriceColumn.Width = 89;
            // 
            // SoldLastDayColumn
            // 
            this.SoldLastDayColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoldLastDayColumn.DataPropertyName = "SoldLastDay";
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.SoldLastDayColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.SoldLastDayColumn.HeaderText = "Sold in Last Day";
            this.SoldLastDayColumn.Name = "SoldLastDayColumn";
            this.SoldLastDayColumn.ReadOnly = true;
            this.SoldLastDayColumn.Width = 136;
            // 
            // MarketCapColumn
            // 
            this.MarketCapColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MarketCapColumn.DataPropertyName = "MarketCap";
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            this.MarketCapColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.MarketCapColumn.HeaderText = "MarketCap (5% Price * SoldLastDay)";
            this.MarketCapColumn.Name = "MarketCapColumn";
            this.MarketCapColumn.ReadOnly = true;
            this.MarketCapColumn.Width = 264;
            // 
            // SpacerColumn
            // 
            this.SpacerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.SpacerColumn.DefaultCellStyle = dataGridViewCellStyle18;
            this.SpacerColumn.HeaderText = "";
            this.SpacerColumn.Name = "SpacerColumn";
            this.SpacerColumn.ReadOnly = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnePercentPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwoPercentPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FivePercentPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldLastDayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketCapColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpacerColumn;
        private System.Windows.Forms.Label exaltPriceLabel;
        private System.Windows.Forms.TextBox exaltPrice;
        private System.Windows.Forms.ComboBox leagueNamesBox;
        private System.Windows.Forms.Label leagueLabel;
    }
}

