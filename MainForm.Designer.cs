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
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.statsGrid = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPercentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddedLastDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketCapColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpacerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.TenPercentPriceColumn,
            this.AddedLastDay,
            this.MarketCapColumn,
            this.SpacerColumn});
            this.statsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsGrid.Location = new System.Drawing.Point(0, 40);
            this.statsGrid.Name = "statsGrid";
            this.statsGrid.ReadOnly = true;
            this.statsGrid.RowHeadersVisible = false;
            this.statsGrid.Size = new System.Drawing.Size(1019, 840);
            this.statsGrid.TabIndex = 0;
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
            this.NameColumn.Width = 70;
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
            this.MinPriceColumn.Width = 139;
            // 
            // TenPercentPriceColumn
            // 
            this.TenPercentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TenPercentPriceColumn.DataPropertyName = "TenPercentPrice";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.TenPercentPriceColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.TenPercentPriceColumn.HeaderText = "10% Price (chaos)";
            this.TenPercentPriceColumn.Name = "TenPercentPriceColumn";
            this.TenPercentPriceColumn.ReadOnly = true;
            this.TenPercentPriceColumn.Width = 149;
            // 
            // AddedLastDay
            // 
            this.AddedLastDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AddedLastDay.DataPropertyName = "AddedLastDay";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.AddedLastDay.DefaultCellStyle = dataGridViewCellStyle5;
            this.AddedLastDay.HeaderText = "Added in Last Day";
            this.AddedLastDay.Name = "AddedLastDay";
            this.AddedLastDay.ReadOnly = true;
            this.AddedLastDay.Width = 149;
            // 
            // MarketCapColumn
            // 
            this.MarketCapColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MarketCapColumn.DataPropertyName = "MarketCap";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.MarketCapColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.MarketCapColumn.HeaderText = "MarketCap (10% Price * AddedLastDay)";
            this.MarketCapColumn.Name = "MarketCapColumn";
            this.MarketCapColumn.ReadOnly = true;
            this.MarketCapColumn.Width = 285;
            // 
            // SpacerColumn
            // 
            this.SpacerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.SpacerColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.SpacerColumn.HeaderText = "";
            this.SpacerColumn.Name = "SpacerColumn";
            this.SpacerColumn.ReadOnly = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 7);
            this.progressBar.MarqueeAnimationSpeed = 20;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1013, 23);
            this.progressBar.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 880);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPercentPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddedLastDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketCapColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpacerColumn;
    }
}

