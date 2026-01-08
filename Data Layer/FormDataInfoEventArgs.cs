using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Consultant_25.Data_Layer
{
    public class FormDataInfoEventArgs : EventArgs
    {
        public string clientName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string BusinessName { get; set; }
    }
}
