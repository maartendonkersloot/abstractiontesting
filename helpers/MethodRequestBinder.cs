using abstractests.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text;

namespace abstractests.helpers
{
    public class MethodRequestBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var stream = bindingContext.HttpContext.Request.Body;
            var readStream = new StreamReader(stream, Encoding.UTF8);
            var json = readStream.ReadToEnd();
            JObject stuff = JObject.Parse(json);
            var recordHolder = stuff.GetValue("records");
            stuff.Remove("records");

            var type = stuff.GetValue("type");
            type value = type.ToObject<type>();

            RecordSetBase album = stuff.ToObject<RecordSetBase>() ;
            album.records = ResolveBaseRecord(recordHolder, value);


            bindingContext.Result = ModelBindingResult.Success(album);
            return Task.CompletedTask;
        }

        public IEnumerable<baseRecord> ResolveBaseRecord(JToken baseRecords, type type)
        {
            IEnumerable<baseRecord> toreturn = null;
            switch (type)
            {
                case Models.type.UNRECOGNIZED:
                    break;
                case Models.type.A:
                    toreturn = baseRecords.ToObject<IEnumerable<ARecord>>();

                    break;
                case Models.type.AAA:
                    toreturn = baseRecords.ToObject<IEnumerable<AAARecord>>();
                    break;
                default:
                    break;
            }

            return toreturn;
        }
    }
}
