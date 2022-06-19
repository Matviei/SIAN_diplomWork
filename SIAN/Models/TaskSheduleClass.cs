using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SIAN.Models
{
    public partial class TaskSchedule
    {
        public SolidColorBrush ColorTaskSchedule
        {
            get
            {
                SolidColorBrush color = new SolidColorBrush();
                if (ID_prioritet == 2)
                {
                    color = Brushes.Red;
                }
                if (ID_prioritet == 1)
                {
                    color = Brushes.LightGray;
                }
                if (Deadline != null)
                {
                   TimeSpan date = (TimeSpan)(Deadline - DateTime.Now);
                    if (date.Days < 5 )
                    {
                        color = Brushes.Red;
                    }
                }
                return color;
            }
        }
        public string CultureDateStart
        {
            get
            {
                var date = Date;
                return date.ToString("D",
                  CultureInfo.CreateSpecificCulture("ru-RU"));

            }
        }
        public string CultureDateEnd
        {
            get
            {
                if (Deadline.HasValue)
                {   
                    var dateend = Convert.ToDateTime(Deadline);
                    return dateend.ToString("D",CultureInfo.CreateSpecificCulture("ru-RU"));
                }
                else return null;

            }
        }
    }

}
