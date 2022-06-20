using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SIAN.Models
{
    public partial class Status
    {
        public SolidColorBrush ColorStatus
        {
            get
            {
                SolidColorBrush color = new SolidColorBrush();
                if (ID_status == 1)
                {
                    color = Brushes.CornflowerBlue;
                }
                else if (ID_status== 2)
                {
                    color = Brushes.DarkGreen;
                }
                else if (ID_status == 3)
                {
                    color = Brushes.DarkGoldenrod;
                }
                else if (ID_status == 4)
                {
                    color = Brushes.LightGray;
                }
                else
                {
                    color = Brushes.LightGray;
                }
                return color;
            }
        }
    }
}
