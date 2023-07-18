using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{
    public interface ISpecialization : ICourse
    {

        public static new int Id { get; set; }
        public static new string Title { get; set; } = string.Empty;
        public static new string Description { get; set; } = string.Empty;
        public static new bool Status { get; set; }
        
        public static double Rating { get; set; }

    }

    public class SpecializationModel : ISpecialization
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        
        public double Rating { get; set; }
        public double Progress { get; set; }

        public List<SpecializationModel> CreateSpecializationModelList()
        {
            List<SpecializationModel> specializationModels = new List<SpecializationModel>();
            
            SpecializationModel frontSpecializationModel = new SpecializationModel();
            frontSpecializationModel.Id = 1;
            frontSpecializationModel.Title = "Font-end Developer";
            frontSpecializationModel.Description = "Font-end Developer Description";
            frontSpecializationModel.Progress = 1;
            frontSpecializationModel.Status = true;
            frontSpecializationModel.Rating = 3.5;

            SpecializationModel backSpecializationModel = new SpecializationModel();
            backSpecializationModel.Id = 2;
            backSpecializationModel.Title = "Back-end Developer";
            backSpecializationModel.Description = "Back-end Developer Description";
            backSpecializationModel.Progress = 1;
            backSpecializationModel.Status = true;
            backSpecializationModel.Rating = 4.5;

            SpecializationModel fullSpecializationModel = new SpecializationModel();
            fullSpecializationModel.Id = 3;
            fullSpecializationModel.Title = "Full Stack Developer";
            fullSpecializationModel.Description = "Full Stack Developer Description";
            fullSpecializationModel.Progress = 0.0;
            fullSpecializationModel.Status = false;
            fullSpecializationModel.Rating = 1.0;
            
            SpecializationModel appSpecializationModel = new SpecializationModel();
            appSpecializationModel.Id = 4;
            appSpecializationModel.Title = "Application Developer";
            appSpecializationModel.Description = "Application Developer Description";
            appSpecializationModel.Progress = 0.0;
            appSpecializationModel.Status = false;
            appSpecializationModel.Rating = 5.0;

            specializationModels.Add(backSpecializationModel);
            specializationModels.Add(frontSpecializationModel);
            specializationModels.Add(fullSpecializationModel);
            specializationModels.Add(appSpecializationModel);


            return specializationModels;

        }
    }
    
}
