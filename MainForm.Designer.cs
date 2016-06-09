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
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnePercentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwoPercentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FivePercentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldLastDayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketCapColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpacerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 7);
            this.progressBar.MarqueeAnimationSpeed = 20;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1089, 23);
            this.progressBar.TabIndex = 1;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 68;
            // 
            // MinPriceColumn
            // 
            this.MinPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MinPriceColumn.DataPropertyName = "MinPrice";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.MinPriceColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.MinPriceColumn.HeaderText = "MinPrice (chaos)";
            this.MinPriceColumn.Name = "MinPriceColumn";
            this.MinPriceColumn.ReadOnly = true;
            this.MinPriceColumn.Width = 137;
            // 
            // OnePercentPriceColumn
            // 
            this.OnePercentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OnePercentPriceColumn.DataPropertyName = "OnePercentPrice";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.OnePercentPriceColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.OnePercentPriceColumn.HeaderText = "1% Price";
            this.OnePercentPriceColumn.Name = "OnePercentPriceColumn";
            this.OnePercentPriceColumn.ReadOnly = true;
            this.OnePercentPriceColumn.Width = 87;
            // 
            // TwoPercentPriceColumn
            // 
            this.TwoPercentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TwoPercentPriceColumn.DataPropertyName = "TwoPercentPrice";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.TwoPercentPriceColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.TwoPercentPriceColumn.HeaderText = "2% Price";
            this.TwoPercentPriceColumn.Name = "TwoPercentPriceColumn";
            this.TwoPercentPriceColumn.ReadOnly = true;
            this.TwoPercentPriceColumn.Width = 87;
            // 
            // FivePercentPriceColumn
            // 
            this.FivePercentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FivePercentPriceColumn.DataPropertyName = "FivePercentPrice";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.FivePercentPriceColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.FivePercentPriceColumn.HeaderText = "5% Price";
            this.FivePercentPriceColumn.Name = "FivePercentPriceColumn";
            this.FivePercentPriceColumn.ReadOnly = true;
            this.FivePercentPriceColumn.Width = 87;
            // 
            // SoldLastDayColumn
            // 
            this.SoldLastDayColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoldLastDayColumn.DataPropertyName = "SoldLastDay";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.SoldLastDayColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.SoldLastDayColumn.HeaderText = "Sold in Last Day";
            this.SoldLastDayColumn.Name = "SoldLastDayColumn";
            this.SoldLastDayColumn.ReadOnly = true;
            this.SoldLastDayColumn.Width = 134;
            // 
            // MarketCapColumn
            // 
            this.MarketCapColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MarketCapColumn.DataPropertyName = "MarketCap";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.MarketCapColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.MarketCapColumn.HeaderText = "MarketCap (5% Price * SoldLastDay)";
            this.MarketCapColumn.Name = "MarketCapColumn";
            this.MarketCapColumn.ReadOnly = true;
            this.MarketCapColumn.Width = 262;
            // 
            // SpacerColumn
            // 
            this.SpacerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.SpacerColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.SpacerColumn.HeaderText = "";
            this.SpacerColumn.Name = "SpacerColumn";
            this.SpacerColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 880);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statsGrid);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhatToFlip";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statsGrid)).EndInit();
            this.ResumeLayout(false);

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
    }
}

