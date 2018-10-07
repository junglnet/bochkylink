using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Exception;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;
using BochkyLink.Source;

namespace BochkyLink.BL
{
    public class NewSpecBusinessLayerImplt : IAddNewSpecService
    {
        public ISettings Settings { get; private set; }
        public IDataBaseAdapter DBa { get; private set; }
        public CategoriesList CategoriesList { get; private set; }
        public ModelList ModelList { get; private set; }
        public Category CurrentCategory { get; private set; }
        public Model CurrentModel { get; private set; }
        public SpecificationFile TemplateSpec { get; private set; }
        
        
        public NewSpecBusinessLayerImplt(ISettings settings)
        {
            this.Settings = settings;
            DBa = new DataBaseAdapter(new DataBase(settings.DBConnectionString));
        }


        public void CreateNewCategory(string newCategoryName)
        {
            DBa.CreateNewCategory(newCategoryName);
            CategoriesList = DBa.GetCategoriesList();
        }

        public void CreateNewModel(Category category, string newModelName)
        {
            throw new NotImplementedException();
        }

        public void CreateNewSpec(SpecificationFile sFile, string path)
        {
            throw new NotImplementedException();
        }

        public List<string> GetCateriesNameList()
        {
            CategoriesList = DBa.GetCategoriesList();
            return CategoriesList.ToNameList();
        }

        public List<string> GetModelNameList(string category)
        {
            throw new NotImplementedException();
        }
    }
}
