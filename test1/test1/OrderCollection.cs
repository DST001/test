using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;
using Sem1Project.Annotations;

namespace Sem1Project
{
    public sealed class OrderCollection : INotifyPropertyChanged    //This needs to be a singleton
    {
        private ObservableCollection<OrderClass> _orders = new ObservableCollection<OrderClass>();
        private OrderClass _selectedOrder;

        private static OrderCollection _instance;

        public OrderCollection()  //Not sure about constructor
        {
            OrderClass order1 = new OrderClass();
            order1.Product = "ehhhs";
            order1.Price = "$$$$";
            order1.Description = "hella good";
            order1.Company = "Apple";

            _orders.Add(order1);

            OrderClass order2 = new OrderClass();
            order2.Product = "ehhhs";
            order2.Price = "$$$$";
            order2.Description = "hella good";
            order2.Company = "Banana";

            _orders.Add(order2);
        }


        public static OrderCollection GetOrderCollection
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderCollection();
                }
                return _instance;
            }
        }

        public OrderClass SelectedOrder
        {
            get { return _selectedOrder; }
            set { _selectedOrder = value; }
        }

        public ObservableCollection<OrderClass> Orders
        {
            get { return _orders; }
        }

        public OrderClass SelecteOrder
        {
            get { return _selectedOrder; }  //Not sure if we need this line
            set { _selectedOrder = value; }
        }

        public void AddOrder(OrderClass newOrder)
        {
            _orders.Add(newOrder);
            OnPropertyChanged();
        }

        public void RemoveItem(OrderClass order)
        {
            if (_orders.Contains(order))
            {
                _orders.Remove(order);
            }
        }

        //Add methods to sort this list into the correct order for different pages


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
