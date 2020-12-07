using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BochkyLink.Common.Exception;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;
using BochkyLink.Source;

namespace BochkyLink.BL
{
    /// <summary>
    /// Класс адаптер между UI (Формирование клиентской спецификации) и DataBase. 
    /// </summary>
    public class SpecBusinessLayerImplt : DataBaseAdapter, ISpecService
    {
        ISettings Settings;
        CategoriesList CategoriesList;
        ModelList ModelList;
        Category CurrentCategory;
        Model CurrentModel;        

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settings">Настройки программы</param>
        

        public SpecBusinessLayerImplt(ISettings settings) 
            : base(new DataBase(settings.GetPropertyValue("DBConnectionString")))
           
        {           
            Settings = settings;           
        }

        /// <summary>
        /// Получения списка категорий
        /// </summary>
        /// <returns>Список категорий</returns>        
        public List<string> GetCateriesNameList()
        {
            CategoriesList = GetCategoriesList();
            return CategoriesList.ToNameList();
        }

        /// <summary>
        /// Получения списка моделей
        /// </summary>
        /// <returns>Список категорий</returns>        
        public List<string> GetModelNameList(string category)
        {
            if (category == "") throw new BusinessException("Не задана категория");
            SetCurrentCategory(category);            
            ModelList = GetModelListByCategory(CurrentCategory);     
            return ModelList.ToNameList();            
        }

        /// <summary>
        /// Бизнес-логика формирования файла спецификации
        /// </summary>
        /// <param name="model"></param>
        /// <param name="consumerFolderName"></param>
        public void FillConsumerFolder(string model, string consumerFolderName, string priorytyPath)
        {
            SetCurrentModel(model);
            List<SpecificationFile> specificationFiles = new List<SpecificationFile>();
            ConsumerFolder consumerFolder;
            Folder baseSpecFolder = GetSpecificationFolder(CurrentModel, Settings.GetPropertyValue("PathToCRMFolder"));

            IEnumerable<string> SpecFilesPath = baseSpecFolder.GetFilesByExtension(".xlsm", System.IO.SearchOption.TopDirectoryOnly);
            
            foreach (string s in SpecFilesPath)            
                specificationFiles.Add(new SpecificationFile(s));

            if (priorytyPath != "")
            {
                consumerFolder = new ConsumerFolder(priorytyPath, Settings.GetPropertyValue("PathToTemplateFolder"));
            }
            else
            {
                consumerFolder = new ConsumerFolder(Settings.GetPropertyValue("PathToConsumerFolder"),
                    Settings.GetPropertyValue("PathToTemplateFolder"), consumerFolderName);
            }            

            Folder consomerSpecFolder = new Folder(consumerFolder.FolderPath + Settings.GetPropertyValue("NameSpecConsumerFolder"));

            foreach(SpecificationFile sf in specificationFiles)            
                consomerSpecFolder.PutFileToFolder(sf.FullPathToFile);
            
            consomerSpecFolder.OpenFolder();
        }

        public void OpenTemplateDirectory (string model)
        {
            SetCurrentModel(model);            
            Folder baseSpecFolder = GetSpecificationFolder(CurrentModel, Settings.GetPropertyValue("PathToCRMFolder"));
            baseSpecFolder.OpenFolder();
        }

        /// <summary>
        /// Фиксация текущей категории
        /// </summary>
        /// <param name="category">Имя категории</param>
        private void SetCurrentCategory(string category)
        {
            if (CategoriesList == null) throw new BusinessException("Список категорий не был получен из базы данных");
            foreach (Category c in CategoriesList)
            {
                if (c.Name == category) CurrentCategory = c;
            }
            if (CurrentCategory is null) throw new BusinessException("Категория не найдена");
        }

        /// <summary>
        /// Фиксация текущей модели
        /// </summary>
        /// <param name="model">Имя модели</param>
        private void SetCurrentModel(string model)
        {
            if (ModelList == null) throw new BusinessException("Список моделей не был получен из базы данных");
            if (model == "" || model == null) throw new BusinessException("Модель не выбрана");

            foreach (Model m in ModelList)
            {
                if (m.Name == model) CurrentModel = m;
            }
            if (CurrentModel is null) throw new BusinessException("Модель не найдена");
        }        
    }
}
