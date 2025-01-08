using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OOP_Exam2025;

namespace TicketBooking
{
    public partial class MainWindow : Window
    {
        private List<Event> events;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            // Populate events
            events = new List<Event>
            {
                new Event
                {
                    Name = "Oasis Croke Park",
                    EventDate = new DateTime(2025, 6, 20),
                    TypeOfEvent = EventType.Music,
                    Tickets = new List<Ticket>
                    {
                        new Ticket { Name = "Early Bird", Price = 100m, AvailableTickets = 100 },
                        new Ticket { Name = "Platinum", Price = 150m, AvailableTickets = 100 },
                        new VIPTicket { Name = "Ticket and Hotel Package", Price = 150m, AdditionalCost = 100m, AdditionalExtras = "4* hotel", AvailableTickets = 100 }
                    }
                },
                new Event
                {
                    Name = "Electric Picnic",
                    EventDate = new DateTime(2025, 8, 20),
                    TypeOfEvent = EventType.Music,
                    Tickets = new List<Ticket>
                    {
                        new Ticket { Name = "Early Bird", Price = 100m, AvailableTickets = 100 },
                        new VIPTicket { Name = "Weekend Ticket", Price = 200m, AdditionalCost = 100m, AdditionalExtras = "with camping", AvailableTickets = 100 }
                    }
                }
            };

            // Bind events to the ListBox
            EventListBox.ItemsSource = events;
        }

        private void EventListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EventListBox.SelectedItem is Event selectedEvent)
            {
                TicketListBox.ItemsSource = selectedEvent.Tickets;
            }
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (TicketListBox.SelectedItem is Ticket selectedTicket && int.TryParse(TicketQuantityTextBox.Text, out int quantity))
            {
                if (quantity > 0 && selectedTicket.AvailableTickets >= quantity)
                {
                    selectedTicket.AvailableTickets -= quantity;
                    MessageBox.Show($"Successfully booked {quantity} tickets for {selectedTicket.Name}.");
                }
                else
                {
                    MessageBox.Show("Not enough tickets available.");
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket and enter a valid quantity.");
            }

            // Refresh ListBox to update available tickets
            TicketListBox.Items.Refresh();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchBox.Text.ToLower();
            EventListBox.ItemsSource = string.IsNullOrWhiteSpace(query)
                ? events
                : events.Where(ev => ev.Name.ToLower().Contains(query)).ToList();
        }
    }

    // Converter Class
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(value as string) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
