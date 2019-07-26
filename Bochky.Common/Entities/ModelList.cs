using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochkyLink.Common.Entities
{
    public class ModelList
    {
        private List<Model> Models { get; set; }

        public ModelList()
        {
            Models = new List<Model>();
        }

        public int Length
        {
            get { return Models.Count; }
        }

        public Model this[int index]
        {
            get
            {
                return Models[index];
            }
            set
            {
                Models[index] = value;
            }
        }
        // ? Почему не смог реализовать через интерфейс IEnumerable
        public IEnumerator<Model> GetEnumerator()
        {
            return Models.GetEnumerator();
        }

        public void Add(Model newModel)
        {
            Models.Add(newModel);
        }

        public void Sort()
        {
            Models.Sort();
        }
        public List<string> ToNameList()
        {            
            if (Models.Count > 0)
                return Models.Select(c => c.Name).ToList();        

            else return null;
            
        }
        public Model FindModelByName(string name)
        {
            foreach (Model m in Models)
            {
                if (m.Name == name) return m;
            }
            return null;
        }
    }
}
