using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Repositories
{
    public class StudyRepository
    {

        public Study getModel()
        {
            return ModelDataSource().FirstOrDefault();
        }


        public ObservableCollection<Study> getModels()
        {
            return ModelDataSource();
        }

        private ObservableCollection<Study> ModelDataSource() 
        {
            ObservableCollection<Study> studyCollection = new ObservableCollection<Study>
            {
                new Study(1, "First","First Study in List",false),
                new Study(2, "Second","Second Study in List",false),
                new Study(3, "Third","Third Study in List",false),
                new Study(4, "Fourth","Fourth Study in List",false),
                new Study(5, "Fifth","Fifth Study in List",false)
            };

            return studyCollection;
        }
    }
}
