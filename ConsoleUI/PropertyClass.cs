using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class PropertyClass
    {
        private string _isim;
        public string Isim
        {
            get
            {
                if (_isim.Length > 20)
                {
                    return "Aktarım sınırı aşıldı";
                }

                return _isim;
            }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("İsim uzunluğu yetersiz");
                }
                else
                {
                    _isim = value;
                }
            }
        }

        public PropertyClass()
        {
            _isim = "Mehmet";
        }

        public void FieldYaz()
        {
            Console.WriteLine(_isim);
        }

    }
}
