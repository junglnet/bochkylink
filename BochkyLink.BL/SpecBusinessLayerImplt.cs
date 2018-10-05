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
    public class SpecBusinessLayerImplt : ISpecService
    {
        public ISettings Settings { private get; set; }
        public IDataBaseAdapter DBa { get; set; }

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
        {
            this.Settings = settings;           
            DBa = new DataBaseAdapter(new DataBase(settings.DBConnectionString));
        }

        /// <summary>
        /// Получения списка категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        /// 
        public List<string> GetCateriesNameList()
        {
            CategoriesList = DBa.GetCategoriesList();
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
            ModelList = DBa.GetModelListByCategory(CurrentCategory);     
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
            SpecificationFile specFile = DBa.GetSpecificationFile(CurrentModel, Settings.PathToCRMFolder);
            ConsumerFolder consumerFolder = new ConsumerFolder(Settings.PathToConsumerFolder, Settings.PathToTemplateFolder, consumerFolderName);
            Folder specFolder = new Folder(consumerFolder.FolderPath + Settings.NameSpecConsumerFolder);
            specFolder.PutFileToFolder(specFile.FullPathToFile);
            specFolder.OpenFolder();
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
        }        
    }
}
