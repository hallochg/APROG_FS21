using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;

namespace SW06_Person {
    internal enum GenderType {
        Male=0,
        Female,
        Generic
    }
    class Gender {
        private GenderType gender;
        public Gender(GenderType gender) {
            this.gender = gender;
        }

        private static Dictionary<GenderType, string> GenderSalutationResourceAssociation = new Dictionary<GenderType, string>() {
            {GenderType.Male, Constants.ResourcesSalutationMaleName },
            {GenderType.Female, Constants.ResourcesSalutationFenaleName},
            {GenderType.Generic, Constants.ResourcesSalutationGenericName}
        };

        public string GetSalutation() {
            return GetTextFromResourceWithCurrentCulter(GenderSalutationResourceAssociation[this.gender]);
        }

        private static string GetTextFromResourceWithCurrentCulter(string resourceName) {
            var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var assemblyName = executingAssembly.GetName().Name;
            return new ResourceManager($"{assemblyName}.Properties.language", executingAssembly).GetString(resourceName, Properties.language.Culture);
        }
    }
}
