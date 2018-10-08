using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class Page
    {
        private int _rows;
        public int rows
        {
            get
            {
                if (this._rows <= 0)
                    return 10;
                return this._rows;
            }
            set
            {
                if (value <= 0)
                    this._rows = 10;
                this._rows = value;
            }
        }
        private int _page;
        public int page
        {
            get
            {
                if (this._page <= 0)
                    return 1;
                return this._page;
            }
            set
            {
                if (value <= 0)
                    this._page = 1;
                this._page = value;
            }
        }
        public string sort { get; set; }
        public string order { get; set; }

        public string ConvertSort
        {
            get 
            {
                switch (this.sort)
                {
                    case "DeviceStyleName": return "DeviceStyleID"; 
                    default :return this.sort;
                }
            }
        }
    }
}