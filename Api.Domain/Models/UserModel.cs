using System;

namespace Api.Domain.Models
{
    public class LegalCaseModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _CourtName;
        public string CourtName
        {
            get { return _CourtName; }
            set { _CourtName = value; }
        }

    }
}
