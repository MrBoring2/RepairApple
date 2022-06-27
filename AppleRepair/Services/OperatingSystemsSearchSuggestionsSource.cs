using AppleRepair.Data;
using MaterialDesignExtensions.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleRepair.Services
{
    public class OperatingSystemsSearchSuggestionsSource : ISearchSuggestionsSource
    {
        private List<string> _operatingSystems;
        public OperatingSystemsSearchSuggestionsSource()
        {
            using (var db = new AppleRepairContext())
            {
                _operatingSystems = db.PhoneModel.Select(p=>p.ModelName + " " + p.Color).ToList();
            }
        }
        public IList<string> GetAutoCompletion(string searchTerm)
        {
            return _operatingSystems.Where(os => os.ToLower().Contains(searchTerm.ToLower())).ToList();
        }

        public IList<string> GetSearchSuggestions()
        {
            return _operatingSystems.Skip(_operatingSystems.Count - 10).Take(10).ToList();
        }
    }
}
