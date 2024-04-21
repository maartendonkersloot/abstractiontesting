
using abstractests.Models;

namespace abstractests.Domain
{
    public class RecordSetBaseDomain
    {
        public string name { get; set; }
        public type type { get; set; }

        public IEnumerable<baseRecordDomain> records { get; set; }
    }

    public abstract class baseRecordDomain
    {
        public string name { get; set; }

    }
    public class recordDomain : baseRecordDomain
    {
    }

    public class ARecordDomain : baseRecordDomain
    {
        public string ip4address { get; set; }
    }

    public class AAARecordDomain : baseRecordDomain
    {
        public string ip4address { get; set; }
        public string ip6address { get; set; }

    }
}
