﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PoeTradeMonitorClient;

namespace WhatToFlip
{
    public interface IMainForm
    {
        void UpdateItem(StatsGuiItem item);
        void InvokeGrid(Action action);
        void Message(string message);
        bool InProgress { set; }
        void SortByMarketValue();
    }

    public partial class MainForm : Form, IMainForm
    {
        private readonly SortableBindingList<StatsGuiItem> statsGuiItems;
        private readonly MainFormController controller;
        public MainForm()
        {
            InitializeComponent();
            statsGrid.AutoGenerateColumns = false;
            statsGuiItems = new SortableBindingList<StatsGuiItem>();
            statsGrid.DataSource = statsGuiItems;
            controller = new MainFormController(this);
        }

        public void SortByMarketValue()
        {
            statsGrid.InvokeIfRequired(() =>
            {
                statsGrid.Sort(MarketCapColumn, ListSortDirection.Descending);
            });
        }

        public void InvokeGrid(Action action)
        {
            statsGrid.InvokeIfRequired(action.Invoke);
        }

        public void UpdateItem(StatsGuiItem item)
        {
            if (statsGuiItems.Contains(item))
            {
                var existingItem = (from StatsGuiItem guiItem in statsGuiItems
                                    where guiItem.Name == item.Name
                                    select guiItem).Single();
                if(existingItem != null)
                {
                    existingItem.SoldLastDay = item.SoldLastDay;
                    existingItem.MinPrice = item.MinPrice;
                    existingItem.OnePercentPrice = item.OnePercentPrice;
                    existingItem.TwoPercentPrice = item.TwoPercentPrice;
                    existingItem.FivePercentPrice = item.FivePercentPrice;
                }
            }
            else
            {
                statsGuiItems.Add(item);
            }
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        private void ErrorHandler(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ErrorHandler(() =>
            {
                controller.Update(true);
                updateTimer.Enabled = true;
            });
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            ErrorHandler(() =>
            {
                updateTimer.Enabled = false;
                controller.Update(false);
                updateTimer.Enabled = true;
            });
        }
        
        public bool InProgress
        {
            set
            {
                progressBar.InvokeIfRequired(() =>
                {
                    if(value)
                        progressBar.Style = ProgressBarStyle.Marquee;
                    else
                        progressBar.Style = ProgressBarStyle.Blocks;
                });
            }
        }
    }
}
