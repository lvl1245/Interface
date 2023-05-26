using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Forms
{
    class DataGridController
    {
        public static DataGridController? _instance;
        public static DataGridView DataGrid { get; set; }

        public static DataGridController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataGridController();
            }
            return _instance;
        }
        
        DataGridController()
        {
            
        }
    }
}
