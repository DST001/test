using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1Project
{
    public class OrderClass
    {
        private static int _orderNumber = 0;
        private int _myOrderNumber = 0;

        private string _product;
        private string _description;
        private string _price;
        private string _company;

        bool _bool1;
        bool _bool2;
        bool _bool3;
        bool _bool4;
        bool _bool5;  //Bools just an example need to add more

        public OrderClass()
        {
            _orderNumber++;
            this._myOrderNumber = _orderNumber;

            _product = "testing";
            _description = "words";
            _price = "$1";
        }

        public int OrderNumber
        {
            get { return _myOrderNumber; }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }


        //public override bool Equals(Object obj)  //Help
        //{
        //    if (this._product == obj._product && this._price == obj._price && this._description == obj._description)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public string Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }


    }
}
