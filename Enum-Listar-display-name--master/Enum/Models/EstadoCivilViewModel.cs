using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDispalyName.Enum.Models
{
    public class EstadoCivilViewModel : EnumViewModel
    {
        public override void SetEnum()
        {
            this.EnumValues = System.Enum.GetValues(typeof(EstadoCivil));
        }
    }
}
