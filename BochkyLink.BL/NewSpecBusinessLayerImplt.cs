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
    public class NewSpecBusinessLayerImplt : DataBaseAdapter, IAddNewSpecService
    {
        public ISettings Settings { get; private set; }      
     
        public SpecificationFile TemplateSpec { get; private set; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settings"></param>
        public NewSpecBusinessLayerImplt(ISettings settings) 
            : base(new DataBase(settings.DBTemplateConnectionString))

        {
            Settings = settings;
        }

        /// <summary>
        /// Получения списка категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        public List<string> GetCateriesNameList()
        {            
            return GetCategoriesList().ToNameList();
        }

        /// <summary>
        /// Получения списка моделей категории
        /// </summary>
        /// <param name="category">Категория</param>
        /// <returns></returns>
        public List<string> GetModelNameList(string category)
        {
            ModelList modelList;        
                        
            modelList = GetModelListByCategory(GetCategoriesList().FindCategoryByName(category));
            return modelList.ToNameList();
        }

        public void CreateNewCategory(string newCategoryName)
        {                      
            CreateNewCategory(new Category(newCategoryName));            
        }

        private void CreateNewModel(Category category, string newModelName)
        {      
            ModelList modelList = GetModelListByCategory(category);
            
            foreach (Model m in modelList)
            {
                if (m.Name == newModelName) throw new BusinessException("Имя модели совпадает с уже существующим именем в категории " + category.Name);
            }
            CreateNewModel(new Model(newModelName, category));
        }      
 

        public void CreateNewSpec(string priorityPath, string baseState, string newCategoryName, string newModelName, 
            string templateCategoryName, string templateModelName, string newFolderName)
        {
            Category newCategory = new Category(newCategoryName);
            Model newModel = new Model(newModelName, newCategory);
            
            CategoriesList categoriesList = GetCategoriesList();
            Folder endFolder, catFolder;           
               
                if (priorityPath != baseState)
                {
                  
                    catFolder = new Folder(Settings.PathToCRMFolder + newCategory.Name);
                    catFolder.CreateFolder(true);
                    endFolder = new Folder(catFolder.FolderPath + "\\" + newFolderName);
                    endFolder.CreateFolder(false);

                    endFolder.PutFileToFolder(priorityPath);
                }
                                    
                else
                {            
                    Folder templateFolder = GetSpecificationFolder(GetModelListByCategory(categoriesList.FindCategoryByName(templateCategoryName)).FindModelByName(templateModelName), Settings.PathToCRMFolder);

                    catFolder = new Folder(Settings.PathToCRMFolder + newCategory.Name);
                    catFolder.CreateFolder(true);
                    endFolder = new Folder(catFolder.FolderPath + "\\" + newFolderName);
                    endFolder.CreateFolder(false);

                    endFolder.CopyDir(templateFolder.FolderPath, endFolder.FolderPath);
                }

                CreateNewModel(categoriesList.FindCategoryByName(newCategory.Name), newModelName);

                CreateNewSpec(GetModelListByCategory(categoriesList.FindCategoryByName(newCategory.Name)).FindModelByName(newModelName).ID, newCategoryName + "\\" + newFolderName);

                endFolder.OpenFolder();         
                        
        }

        
    }
}
