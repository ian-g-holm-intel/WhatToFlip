using System;
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
        double ExaltPrice { get; set; }
        void SetLeagueNames(string[] leagueNames);
        string SelectedLeague { get; }
        void ClearGridSelection();
    }

    public partial class MainForm : Form, IMainForm
    {
        private readonly SortableBindingList<StatsGuiItem> statsGuiItems;
        private readonly BindingList<string> leagueNamesList;
        private readonly MainFormController controller;
        public MainForm()
        {
            InitializeComponent();

            leagueNamesBox.MouseWheel += (sender, args) => ((HandledMouseEventArgs)args).Handled = true;

            updateTimer.Enabled = true;
            statsGrid.AutoGenerateColumns = false;
            statsGuiItems = new SortableBindingList<StatsGuiItem>();
            statsGrid.DataSource = statsGuiItems;
            leagueNamesList = new BindingList<string>();
            leagueNamesBox.DataSource = leagueNamesList;
            controller = new MainFormController(this);
        }

        public void ClearGridSelection()
        {
            statsGrid.ClearSelection();
        }

        public void SortByMarketValue()
        {
            statsGrid.InvokeIfRequired(() =>
            {
                statsGrid.Sort(MarketCapColumn, ListSortDirection.Descending);
            });
        }

        public void SetLeagueNames(string[] leagueNames)
        {
            leagueNamesBox.InvokeIfRequired(() =>
            {
                leagueNamesList.Clear();
                foreach (string league in leagueNames)
                    leagueNamesList.Add(league);
                if(leagueNamesList.Count > 1)
                    leagueNamesBox.SelectedIndex = 1;
            });
        }

        public string SelectedLeague
        {
            get
            {
                string selectedLeague = "";
                leagueNamesBox.InvokeIfRequired(() =>
                {
                    selectedLeague = leagueNamesBox.SelectedItem.ToString();
                });
                return selectedLeague;
            }
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
                    existingItem.SoldLast24h = item.SoldLast24h;
                    existingItem.CurrentLow = item.CurrentLow;
                    existingItem.OneDayAgoAvg = item.OneDayAgoAvg;
                    existingItem.TwoDayAgoAvg = item.TwoDayAgoAvg;
                    existingItem.ThreeDayAgoAvg = item.ThreeDayAgoAvg;
                }
            }
            else
            {
                statsGuiItems.Add(item);
            }
        }

        public double ExaltPrice
        {
            get { return double.Parse(exaltPrice.Text); }
            set
            {
                exaltPrice.InvokeIfRequired(() => exaltPrice.Text = value == 0 ? "Unknown" : value.ToString());
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
                    progressBar.Style = value ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
                });
            }
        }

        private void leagueNamesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorHandler(() =>
            {
                statsGuiItems.Clear();
                controller.Update(true);
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ErrorHandler(() =>
            {
                controller.FetchLeagueNames();
            });
        }

        private void statsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ErrorHandler(() =>
            {
                if (e.RowIndex < 0) return;
                var item = statsGuiItems[e.RowIndex];
                controller.CellValueChanged(item.Name, item.Note);
            });
        }
    }
}
