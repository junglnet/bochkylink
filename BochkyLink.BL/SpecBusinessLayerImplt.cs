using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public string Path { get; private set; }
        public string Model { get; private set; }
        public List<string> CategoriesNameList { get; set; }
        public List<string> ModelsNameList { get; set; }
        public string Category { get; set; }

        DataBase db;
        Settings settings;

        public SpecBusinessLayerImplt(DataBase db, Settings settings)
        {
            this.db = db;
            this.settings = settings;
        }

        /// <summary>
        /// Бизнес-логика получания списка категорий
        /// </summary>
        public List<string> GetCateriesNameList()
        {
            CategoriesNameList = new List<string>();
            
            try
            {              
                CategoriesNameList = db.GetCategoriesNameList();             
                return CategoriesNameList;
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Бизнес-логика получания списка моделей по названию категории
        /// </summary>
        public List<string> GetModelsNameListByCategory(String currentCategory)
        {
            if( currentCategory==null|| currentCategory =="")
            {
                return null;
                throw new BusinessException("Значение категории пусто, отобрать модели не возможно");                
            }
            else
            {
                this.Category = currentCategory;
                try
                {
                    ModelsNameList = db.GetModelsNameList(Category);
                    return ModelsNameList;
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }             
            }          
        }

        public void CreateConsumerFolder(string basePath)
        {
            
        }
        
        /// <summary>
        /// Бизнес-логика получания пути к файлу спецификации по названию модели
        /// </summary>
        public void FillConsumerFolder(string model, string consumerFolderName)
        {      
            this.Model = model;
           
            if (model == "" || model == null) throw new BusinessException("Значение модели пусто");            
            else
            {
                try
                {
                    SpecificationFile specFile = new SpecificationFile(settings.PathToCRMFolder + db.GetPatchToSpec(model));                    
                    ConsumerFolder consumerFolder = new ConsumerFolder(settings.PathToConsumerFolder, settings.PathToTemplateFolder, consumerFolderName);
                    Folder specFolder = new Folder(consumerFolder.FolderPath + settings.NameSpecConsumerFolder);
                    specFolder.PutFileToFolder(specFile.fullPathToFile);
                    specFolder.OpenFolder();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                   
                }
                
            }
        }

       
    }
}
