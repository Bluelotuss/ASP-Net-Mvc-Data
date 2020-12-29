using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public interface ILanguageService
    {
        public Language Add(CreateLanguageViewModel createLanguageViewModel);
        public List<Language> All();
        public Language FindBy(int id);
        public Language Edit(int id, Language language);
        public bool Remove(int id);
    }
}
