using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class ItemExtended
    {
        public items item{ get; set; }

        public string ItemImagePath
        {
            get
            {
                string temp = "/Resources/picture.png";
                return temp;
            }
        }

        public double ItemCurrentPrice
        {
            get
            {
                return Math.Round(this.item.price * (100.0 - this.item.discount) / 100.0, 2);
            }
        }
    }
}
