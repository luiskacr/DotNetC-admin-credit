using NuGet.DependencyResolver;

namespace ClienteApi.Models
{
    public class States_CountryViewModel
    {
        public IEnumerable<CountryViewModel> country { get; set; }
        public IEnumerable<StateViewModel> state { get; set; }
    }
}
