using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sem1Project.Annotations;
using System.Windows.Input;

namespace Sem1Project
{
    class OrderCollectionViewModel : INotifyPropertyChanged
    {
        private OrderCollection _orders = OrderCollection.GetOrderCollection;
        private OrderClass _domainObject;
        private RelayCommand _AddCommand; // Added
        private OrderClass _selectedOrder;

        public OrderCollectionViewModel()
        {
            _AddCommand = new RelayCommand(DoAddRelay, OrderDomainObject); // Added
            _domainObject = new OrderClass();
        }

        public string Company
        {
            get { return _domainObject.Company; }
            set
            {
                _domainObject.Company = value;
                OnPropertyChanged();
            }
        }

        public string Product
        {
            get { return _domainObject.Product; }
            set
            {
                _domainObject.Product = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _domainObject.Description; }
            set
            {
                _domainObject.Description = value;
                OnPropertyChanged();
            }
        }

        public string Price
        {
            get { return _domainObject.Price; }
            set
            {
                _domainObject.Price = value; 
                OnPropertyChanged();
            }
        }

        public OrderClass SelectedOrder
        {
            get { return _selectedOrder; }
            set { _selectedOrder = value; }
        }

        public ObservableCollection<OrderClass> Orders
        {
            get { return _orders.Orders; }
        }

        //        public void AddOrder()   //This needs to add order to order collection singleton
        //        {
        //            _orders.AddOrder(_domainObject);
        //            _domainObject = new OrderClass(); //Dont know if i need to reset _domainobject to blank
        //        }




        public bool DoAdd()
        {
            //return (_domainObject != new OrderClass() && AddOrder());  //bool   //change product to item id later
            AddOrder();
            return true;
        }

        public void DoAddRelay()
        {
            DoAdd();
        }

        public bool OrderDomainObject()
        {
            //return _domainObject != new OrderClass();
            return true;
        }

        public ICommand AddCommand
        {
            get { return _AddCommand; }
        }

        public bool AddOrder()
        {
            _orders.AddOrder(_domainObject);
            OnPropertyChanged();
            return true;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
