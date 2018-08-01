using Newtonsoft.Json;
using System;

namespace Model
{
    public class Person : EntityBase
    {
        public string Name { get; set; }

        public int? Age{ get; set; }

        public bool VIP { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public override string ToString() =>
            JsonConvert.SerializeObject(this, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }
}
