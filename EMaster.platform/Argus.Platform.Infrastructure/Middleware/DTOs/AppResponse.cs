using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Middleware.DTOs
{
    public class AppResponse<T> where T : class
    {
        public T Data { get; set; }
        public Meta Meta { get; set; }
        public override string ToString()
        {
            // return JsonSerializer.Serialize(this);
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }


}
