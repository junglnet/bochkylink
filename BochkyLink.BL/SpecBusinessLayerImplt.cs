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
    /// Реализация слоя бизнес-логики отбора спецификаци
    /// </summary>  
    public class SpecBusinessLayerImplt : DataBaseAdapter, ISpecService
    {
        public ISettings Settings { get; private set; }       

        public CategoriesList CategoriesList { get; private set; }
        public ModelList ModelList { get; private set; }

        public Category CurrentCategory { get; private set; }
        public Model CurrentModel { get; private set; }

        // На сколько было бы правильно реализовать инкапсцляцию свойств??

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settings">Настройки программы</param>

        public SpecBusinessLayerImplt(ISettings settings) 
            : base(new DataBase(settings.DBConnectionString))
           
        {
            Settings = settings;           
        }

        /// <summary>
        /// Получения списка категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        /// 
        public List<string> GetCateriesNameList()
        {
            CategoriesList = GetCategoriesList();
            return CategoriesList.ToNameList();
        }

        /// <summary>
        /// Получения списка моделей
        /// </summary>
        /// <returns>Список категорий</returns>
        /// 
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
        public void FillConsumerFolder(string model, string consumerFolderName)
        {
            SetCurrentModel(model);
            List<SpecificationFile> specificationFiles = new List<SpecificationFile>();
            
            Folder baseSpecFolder = GetSpecificationFolder(CurrentModel, Settings.PathToCRMFolder);

            IEnumerable<string> SpecFilesPath = baseSpecFolder.GetFilesByExtension(".xlsm", System.IO.SearchOption.TopDirectoryOnly);
            
            foreach (string s in SpecFilesPath)            
                specificationFiles.Add(new SpecificationFile(s));

            ConsumerFolder consumerFolder = new ConsumerFolder(Settings.PathToConsumerFolder, Settings.PathToTemplateFolder, consumerFolderName);

            Folder consomerSpecFolder = new Folder(consumerFolder.FolderPath + Settings.NameSpecConsumerFolder);

            foreach(SpecificationFile sf in specificationFiles)            
                consomerSpecFolder.PutFileToFolder(sf.FullPathToFile);
            
            consomerSpecFolder.OpenFolder();
        }

        public void OpenTemplateDirectory (string model)
        {
            SetCurrentModel(model);            
            Folder baseSpecFolder = GetSpecificationFolder(CurrentModel, Settings.PathToCRMFolder);
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
