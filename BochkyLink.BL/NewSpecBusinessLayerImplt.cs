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
            : base(new DataBase(settings.DBConnectionString))

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
            if (category == "") throw new BusinessException("Не задана категория");
            modelList = GetModelListByCategory(GetCategoriesList().FindCategoryByName(category));
            return modelList.ToNameList();
        }

        public override void CreateNewCategory(string newCategoryName)
        {
            if (newCategoryName == "") throw new BusinessException("Не указанно название новой категории");
            base.CreateNewCategory(newCategoryName);            
        }

        public override void CreateNewModel(Category category, string newModelName)
        {            
            if (newModelName == "") throw new BusinessException("Не указанно название новой модели");
            
            ModelList modelList = GetModelListByCategory(category);
            
            foreach (Model m in modelList)
            {
                if (m.Name == newModelName) throw new BusinessException("Имя модели совпадает с уже существующим именем в категории " + category.Name);
            }
            base.CreateNewModel(category, newModelName);
        }      
 

        public void CreateNewSpec(string priorityPath, string baseState, string newCategoryName, string newModelName, 
            string templateCategoryName, string templateModelName, string newFolderName)
        {
            if(newCategoryName == "" || newCategoryName == null)
                throw new BusinessException("Название категории не заданно");
            if (newModelName == "" || newModelName == null)
                throw new BusinessException("Название новой модели не заданно");

            CategoriesList categoriesList = GetCategoriesList();
            Folder endFolder, catFolder;
            try
            {
               
                if (priorityPath != baseState)
                {
                    TemplateSpec = new SpecificationFile(priorityPath);
                    catFolder = new Folder(Settings.PathToCRMFolder + newCategoryName);
                    catFolder.CreateFolder(true);
                    endFolder = new Folder(catFolder.FolderPath + "\\" + newFolderName);
                    endFolder.CreateFolder(false);

                    endFolder.PutFileToFolder(TemplateSpec.FullPathToFile);
                }
                    
                
                else
                {                   
                    TemplateSpec = GetSpecificationFile(GetModelListByCategory(categoriesList.FindCategoryByName(templateCategoryName)).FindModelByName(templateModelName), 
                        Settings.PathToCRMFolder);

                    catFolder = new Folder(Settings.PathToCRMFolder + newCategoryName);
                    catFolder.CreateFolder(true);
                    endFolder = new Folder(catFolder.FolderPath + "\\" + newFolderName);
                    endFolder.CreateFolder(false);

                    endFolder.CopyDir(TemplateSpec.FolderPath, endFolder.FolderPath);
                }

                CreateNewModel(categoriesList.FindCategoryByName(newCategoryName), newModelName);
                CreateNewSpec(GetModelListByCategory(categoriesList.FindCategoryByName(newCategoryName)).FindModelByName(newModelName).ID,TemplateSpec.FolderPath);
            }
            catch (Exception ex)
            {

                throw new BusinessException("Ошибка при создании файла спецификации: " + ex.Message);
            }
            
            
        }

        
    }
}
