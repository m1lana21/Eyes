using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AkhmerovaEyes
{
    /// <summary>
    /// Логика взаимодействия для AgentsPage.xaml
    /// </summary>
    public partial class AgentsPage : Page
    {
        public AgentsPage()
        {
            InitializeComponent();
            var currentAgents = AkhmerovaEyesEntities.GetContext().Agent.ToList();
            AgentListView.ItemsSource = currentAgents;
            FilterBox.SelectedIndex = 0;
            SortBox.SelectedIndex = 0;
        }
        private void UpdateAgents()
        {
            var currentAgents = AkhmerovaEyesEntities.GetContext().Agent.ToList();
            if (FilterBox.SelectedIndex == 0) currentAgents = currentAgents.Where(p => (p.AgentTypeID >= 0 && p.AgentTypeID <= 6)).ToList();
            if (FilterBox.SelectedIndex == 1) currentAgents = currentAgents.Where(p => (p.AgentTypeID == 1)).ToList();
            if (FilterBox.SelectedIndex == 2) currentAgents = currentAgents.Where(p => (p.AgentTypeID == 2)).ToList();
            if (FilterBox.SelectedIndex == 3) currentAgents = currentAgents.Where(p => (p.AgentTypeID == 3)).ToList();
            if (FilterBox.SelectedIndex == 4) currentAgents = currentAgents.Where(p => (p.AgentTypeID == 4)).ToList();
            if (FilterBox.SelectedIndex == 5) currentAgents = currentAgents.Where(p => (p.AgentTypeID == 5)).ToList();
            if (FilterBox.SelectedIndex == 6) currentAgents = currentAgents.Where(p => (p.AgentTypeID == 6)).ToList();

            if(SortBox.SelectedIndex == 0) currentAgents = currentAgents.ToList();
            if (SortBox.SelectedIndex == 1) currentAgents = currentAgents.OrderBy(p => p.Title).ToList();
            if (SortBox.SelectedIndex == 2) currentAgents = currentAgents.OrderByDescending(p => p.Title).ToList();
            /*if (SortBox.SelectedIndex == 3) currentAgents = currentAgents.ToList();
            if (SortBox.SelectedIndex == 4) currentAgents = currentAgents.ToList();*/
            if (SortBox.SelectedIndex == 5) currentAgents = currentAgents.OrderBy(p => p.Priority).ToList();
            if (SortBox.SelectedIndex == 6) currentAgents = currentAgents.OrderByDescending(p => p.Priority).ToList();

            currentAgents = currentAgents.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            AgentListView.ItemsSource = currentAgents;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }
    }
}
